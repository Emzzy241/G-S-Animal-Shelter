using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; //add the necessary using directive so that we have access to SelectList.
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;

namespace AnimalShelter.Models;

public class AnimalDetailsController : Controller
{

    private readonly AnimalShelterContext _db;

    public AnimalDetailsController(AnimalShelterContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        ViewBag.PageTitle = "View all Animals and their details";
        List<AnimalDetail> model = _db.AnimalDetails
                                        .Include(animal => animal.Animal)
                                        .ToList();

        return View(model);
    }

   public ActionResult Create()
   {
        ViewBag.PageTitle = "Create an Animal's detail";
        ViewBag.AnimalId = new SelectList(_db.AllAnimals, "AnimalId", "Type");
        return View();

        /* When we create and edit our animal's detail, we want them to belong to types that already exist. We do this by creating a ViewBag.AnimalId property and we assign it a SelectList object
         A SelectList will provide a list of the data needed to create an html <select> list of all Animals in our database. The displayed text will be the Animal's Type property, and the value of the <option> will be the Animal's AnimalId. That way, a user can select the type of Animal from the dropdown to associate with the AnimalDetail we are creating or editting.

         SelectList takes 3 arguments:
            1. First argument represents the data that will populate our SelectList's <option> elements: a list of animals from our database
            2. Second argument is the value of the every <option> element: the Animal's AnimalId
            3. Third argument is the displayed text of every <option> element: the type of the animal(e.g: Dog, Cat, Bunny)
            
        */
   }

   [HttpPost]
   public ActionResult Create(AnimalDetail detail)
   {
        if (detail.AnimalId == 0)
        {
            return RedirectToAction("Create");
        }
        _db.AnimalDetails.Add(detail);
        _db.SaveChanges();
        return RedirectToAction("Index");
        /*
            In the Post method for Create, the 2 methos .Add(), and .SaveChanges.... 
            .Add() is a DbSet method we run on our DbSet and then sync those changes to the database AnimalShelterContext.
            SaveChanges() is a DbContext method that we run on AnimalShelterContext itsel(which extends the the DbContext class)
            Together, both the .Add() and .SaveChanges() method update the DbSet and then sync those changes to the database AnimalShelterContext represents. Once again, EF Core is at work for us 
            The if statement checks the value of AnimalId. By default, the AnimalId will be 0 if no category is selected fro the form, and so it redirects users back to the Create GET action and view it. 
        */
   }

//    The Details() action
    public ActionResult Details(int id)
    {
        ViewBag.PageTitle = "View an Animal's detail";
        AnimalDetail thisDetail = _db.AnimalDetails
                                     .Include(detail => detail.Animal)
                                     .FirstOrDefault(detail => detail.AnimalDetailId == id);
        return View(thisDetail);
    }

    // The Edit() Action
    public ActionResult Edit(int id)
    {
        ViewBag.PageTitle = "Edit an Animal's detail";
        AnimalDetail thisAnimalDetail = _db.AnimalDetails.FirstOrDefault(detail => detail.AnimalDetailId == id);
        ViewBag.AnimalId = new SelectList(_db.AllAnimals, "AnimalId", "Type");
        return View(thisAnimalDetail);

    }

    [HttpPost]
    public ActionResult Edit(AnimalDetail detail)
    {
        _db.AnimalDetails.Update(detail);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Delete() Action
    public ActionResult Delete(int id)
    {
        ViewBag.PageTitle = "Delete an Animals's detail";
        AnimalDetail thisDetail = _db.AnimalDetails.FirstOrDefault(detail => detail.AnimalDetailId == id);
        return View(thisDetail);
    }

    // Post method for the Delete() Action
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        AnimalDetail thisDetail = _db.AnimalDetails.FirstOrDefault(detail => detail.AnimalDetailId == id);
        _db.AnimalDetails.Remove(thisDetail);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}