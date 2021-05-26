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
    public class ContactoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactoController(ApplicationDbContext context)
        {
            _context = context;
        }

        





    }
}
