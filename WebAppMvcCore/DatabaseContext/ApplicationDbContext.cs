using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMvcCore.Models;

namespace WebAppMvcCore.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=RAKTIM-PC;Database=TrainingCenterDB;Trusted_Connection=true");
        //}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
