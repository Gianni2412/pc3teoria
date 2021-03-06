using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pc3teoria.Models;

namespace pc3teoria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<pc3teoria.Models.Categoria> Categorias { get; set; }

        public DbSet<pc3teoria.Models.Producto> Productos { get; set; }


    }
}
