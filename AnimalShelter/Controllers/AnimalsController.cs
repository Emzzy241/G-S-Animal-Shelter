using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AnimalShelter.Models;
public class AnimalsController : Controller
{
    [HttpGet("/animals")]
    public IActionResult Index()
    {
        return View();
    }
}