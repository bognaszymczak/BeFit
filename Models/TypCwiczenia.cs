using System.ComponentModel.DataAnnotations;

namespace BeFit.Web.Models;

public class TypCwiczenia
{
  public int Id { get; set; }

  [Display(Name = "Excercie Name")]
  [Required(ErrorMessage = "Name is required.")]
  [StringLength(100, MinimumLength = 4)]
  public string Nazwa { get; set; } = "";

  public ICollection<Cwiczenie> Cwiczenia { get; set; } = new List<Cwiczenie>();
}