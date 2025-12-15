using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeFit.Web.Models;
public class Cwiczenie

{
  public int Id { get; set; }

  [Display(Name = "Series Count")]
  [Required, Range(1, 100)]
  public int LiczbaSerii { get; set; }

  [Display(Name = "Weight (kg)")]
  [Required, Column(TypeName = "decimal(5, 2)")]
  [Range(0.1, 1000, ErrorMessage = "Weight must be a positive value.")]
  public decimal Obciazenie { get; set; }

  public int TypCwiczeniaId { get; set; }
  [Display(Name = "Excercise Type")]
  public TypCwiczenia? TypCwiczenia { get; set; } 

  public int SesjaTreningowaId { get; set; }
  public SesjaTreningowa? SesjaTreningowa { get; set; }
}