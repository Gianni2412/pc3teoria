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

        

        public IActionResult Productos(){
            var productos = _context.Productos.Include(x => x.Categoria).OrderBy(r => r.Nombre).ToList();
            return View(productos);
        }

        public IActionResult NuevoProducto(){
            ViewBag.Categorias = _context.Categorias.ToList().Select(c => new SelectListItem(c.Nombre, c.Id.ToString()));
            return View();
        }

    [HttpPost]
      public IActionResult NuevoProducto(Producto p) //da igual xd objeto p es libre su escritura
        {
            if (ModelState.IsValid)
            {
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("NuevoProductoConfirmacion");
            }
            return View(p);
        }

         public IActionResult NuevoProductoConfirmacion()
        {
            return View();
        }





    }
}
