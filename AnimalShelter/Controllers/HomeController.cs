using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AnimalShelter.Controllers;

public class HomeController : Controller
{
    // Default Home Page
    public IActionResult Index()
    {
        ViewBag.PageTitle = "G~S Animal Shelter. We offer the best care";
        
        return View();
    }

}