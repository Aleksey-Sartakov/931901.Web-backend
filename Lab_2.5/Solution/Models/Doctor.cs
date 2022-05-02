using System.ComponentModel.DataAnnotations;

namespace Solution.Models;

public class Doctor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Specialization is required")]
    public string Specialization { get; set; }
}