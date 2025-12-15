using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeFit.Web.Models;

public class SesjaTreningowa
{
  public int Id { get; set; }

  [Display(Name = "Session Title")]
  [Required]
  [StringLength(200)]
  public string Nazwa { get; set; } = "";

  [Display(Name = "Session Title")]
  [Required]
  [DataType(DataType.DateTime)]
  public DateTime CzasRozpoczecia { get; set; }

  [Display(Name = "Session Title")]
  [Required]
  [DataType(DataType.DateTime)]
  public DateTime? CzasZakonczenia { get; set; }

  public string UzytkownikId { get; set; } = "";

  public ICollection<Cwiczenie> Cwiczenia { get; set; } = new List<Cwiczenie>();
}