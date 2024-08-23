using AnimalShelter.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models;

public class Animal
{
    // Each Animal would be given an Id based on its type
    [Key]
    public int AnimalId { get; set; }

    public string Type { get; set; }
    // A Type could be a dog, cat bunny or any other animal

    // Adding functionality that will ensure that I can add an animal into a database
    // Using a List that is capable of storing multiple Animal
    public List<AnimalDetail> Animals { get; set; }
    
}