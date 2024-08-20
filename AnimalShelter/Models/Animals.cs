using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models;

public class Animals
{
    // Each Animal would be given an Id based on its type
    [Key]
    public int AnimalId { get; set; }

    public string Type { get; set; }
    // A Type could be a dog, cat bunny or any other animal

    
}