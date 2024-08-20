using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AnimalShelter.Controllers;

public class HomeController : Controller
{
    // Default Home Page
    public IActionResult Index()
    {
        return View();
    }

}