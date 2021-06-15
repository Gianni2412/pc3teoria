using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pc3teoria.Data;
using pc3teoria.Models;

namespace pc3teoria.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var productos = _context.Productos.Include(x => x.Categoria).Where(x => x.FechaRegistro.AddDays(5) >= DateTime.Now).ToList();
            return View(productos);
        }









    }
}
