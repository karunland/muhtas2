using Entity.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=muhtas2;" +
                "integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Mcu> Mcu { get; set; }
    }
}
