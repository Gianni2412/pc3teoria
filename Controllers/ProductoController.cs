using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pc3teoria.Data;
using pc3teoria.Models;
using Microsoft.AspNetCore.Identity;

namespace pc3teoria.Controllers
{
    public class ProductoController : Controller
    {

        private readonly SignInManager<IdentityUser> _sim;

        private readonly UserManager<IdentityUser> _um;

        private readonly ApplicationDbContext _context;



        public ProductoController(ApplicationDbContext context, SignInManager<IdentityUser> sim,
         UserManager<IdentityUser> um)
        {
            _context = context;
            _sim = sim;
            _um = um;
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
