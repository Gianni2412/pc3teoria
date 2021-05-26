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
            return View();
        }



        //PRODUCTOS
        public IActionResult Productos()
        {
            var productos = _context.Productos.Include(x => x.Categoria).OrderBy(r => r.Nombre).ToList();
            return View(productos);
        }

        public IActionResult NuevoProducto()
        {
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


        /// CONTACTOS

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult NuevoContacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NuevoContacto(Usuario u)
        {
            if (ModelState.IsValid)
            {
                _context.Add(u);
                _context.SaveChanges();

                return RedirectToAction("ListarContactos");
            }
            return View(u);
        }

        public ActionResult ListarContactos()
        {
            var contactos = _context.Usuarios.ToList();
            return View(contactos);
        }


        public ActionResult ContactoConfirmacion()
        {
            return View();
        }





    }
}
