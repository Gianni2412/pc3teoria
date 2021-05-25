using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using pc3teoria.Models;

namespace pc3teoria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


    }
}
