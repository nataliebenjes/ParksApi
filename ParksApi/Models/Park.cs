using System.ComponentModel.DataAnnotations;

namespace ParkApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    [Range(0, 200, ErrorMessage = "Age must be between 0 and 200.")]
    public int FoundedIn { get; set; }
  }
}