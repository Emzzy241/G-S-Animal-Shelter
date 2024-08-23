using AnimalShelter.Models;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models;

public class AnimalDetail
{
    // Explicityly marking AnimalDetailId as a Primary key
    [Key]
    public int AnimalDetailId { get; set; }
    
    public string Name { get; set; }
    public string Date_of_Admittance { get; set; }
    public string Breed { get; set; }
    
    
    // Updating the relationship between Animal and AnimalDetail class
    public int AnimalId { get; set; }
    public Animal Animal { get; set; }

    // Since every AnimalDetail will be associated with an Animal, the AnimalDetail class now has an Animal Property and an AnimalId property, it is this AnimalId property that will serve as the foreign key in our animals database that connects each AnimalDetail with an Animal. oreign keys are used to show the relationship between 2 entities
    // We also included an Animal property set to the Animal object that the AnimalDetail belongs to.
    // The Animal property is the navigation property in our AnimalDetail model that creates the one-to-many relationsip between the Animal object and the AnimalDetail object
    // More specifically, the Animal property here is called the reference navigation property, because it holds a reference to a single related entity
    // Now with the Animal object in place, we can fetch the actual Animal object when we fetch the AnimalDetail object from the database
    
    

    
    
    
    
    
    
    
}