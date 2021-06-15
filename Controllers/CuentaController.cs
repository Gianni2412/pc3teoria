using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace pc3teoria.Controllers
{
    public class CuentaController : Controller
    {
        private readonly SignInManager<IdentityUser> _sim;

        private readonly UserManager<IdentityUser> _um;

        public CuentaController(SignInManager<IdentityUser> sim,
         UserManager<IdentityUser> um)
        {
            _sim = sim;
            _um = um;

        }

        public IActionResult CrearCuenta()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CrearCuenta(string email, string password)
        {
            var usuario = new IdentityUser(email);
            var resultado = _um.CreateAsync(usuario, password).Result;

            if (resultado.Succeeded)
            {
                return RedirectToAction("Registro", "Producto");
            }
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();

        }

        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]

        public ActionResult IniciarSesion(string usuario, string password)
        {
            var result = _sim.PasswordSignInAsync(usuario, password, false, false).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Registro", "Producto");
            }

            ModelState.AddModelError("", "Los datos son incorrectos");
            return View();
        }

        public async Task<ActionResult> CerrarSesion()
        {
            await _sim.SignOutAsync();
            return RedirectToAction("sesioncerrada", "Home");

        }







    }
}
