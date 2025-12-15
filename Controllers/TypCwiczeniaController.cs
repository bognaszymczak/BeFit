using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeFit.Web.Data;
using BeFit.Web.Models;

namespace BeFit.Web.Controllers;

public class TypyCwiczenController : Controller
{
    private readonly ApplicationDbContext _context;

    public TypyCwiczenController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _context.TypyCwiczen.ToListAsync());
    }
}