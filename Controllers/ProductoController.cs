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
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Registro()
        {


            ViewBag.Categorias = _context.Categorias.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Producto p)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(p);

            }

        }




    }
}
