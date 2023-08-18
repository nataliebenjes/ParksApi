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
    public string Type { get; set; }
    [Required]
    [Range(0, 2023, ErrorMessage = "This park hasn't been founded yet")]
    public int FoundedIn { get; set; }
  }
}