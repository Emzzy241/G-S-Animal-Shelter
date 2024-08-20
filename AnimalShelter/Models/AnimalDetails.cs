using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models;

public class AnimalDetails
{
    // Explicityly marking AnimalDetailId as a Primary key
    [Key]
    public int AnimalDetailId { get; set; }
    
    public string Name { get; set; }
    public string Date_of_Admittance { get; set; }
    public string Breed { get; set; }
    
    

    
    
    
    
    
    
    
}