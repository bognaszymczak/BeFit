using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Web.Models;

namespace BeFit.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
 
    public DbSet<TypCwiczenia> TypyCwiczen { get; set; }
    public DbSet<Cwiczenie> Cwiczenia { get; set; }
    public DbSet<SesjaTreningowa> SesjeTreningowe { get; set; }
}