using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq; // The namespace housing the ToList() method

namespace AnimalShelter.Models;
public class AnimalsController : Controller
{
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        
        List<Animal> model = _db.AllAnimals.ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
        _db.AllAnimals.Add(animal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        ViewBag.PageTitle = "Animal Details";

        Animal thisAnimal = _db.AllAnimals
                            .Include(animal => animal.Animals)  // Including the Animals property(a list under the Animal class; parent class) which helps in Telling EF Core to fetch every AnimalDetail object belonging to this Animal
                            .FirstOrDefault(animal => animal.AnimalId == id);
        return View(thisAnimal);
    }

    public ActionResult Edit(int id)
    {
        ViewBag.PageTitle = "Editing Animal";
        Animal thisAnimal = _db.AllAnimals.FirstOrDefault(animal => animal.AnimalId == id);
        return View(thisAnimal);
    }

    // Post method that actually does the real editting
    [HttpPost]
    public ActionResult Edit(Animal animal)
    {
        // Updating the database with the new editted change
        _db.AllAnimals.Update(animal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

     public ActionResult Delete(int id)
        {
            Animal thisAnimal = _db.AllAnimals.FirstOrDefault(animal => animal.AnimalId == id);
             ViewBag.PageTitle = "Delete Animal?";
            return View(thisAnimal);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal thisAnimal = _db.AllAnimals.FirstOrDefault(animal => animal.AnimalId == id);
            _db.AllAnimals.Remove(thisAnimal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    
}