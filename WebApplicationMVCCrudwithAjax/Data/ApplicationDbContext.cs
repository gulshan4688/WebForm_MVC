using Microsoft.EntityFrameworkCore;
using System;
using WebApplicationMVCCrudwithAjax.Models;

namespace WebApplicationMVCCrudwithAjax.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                   new Employee
               {
                   Id = 1,
                   Name = "Alice",
                   Code = 101,
                   Dob = new DateTime(1990, 5, 12),
                   City = "Mumbai",
                   Gender = "Female",
                   Active = "Yes",
                   Image = "alice.jpg"
               },
                   new Employee
                   {
                       Id = 2,
                       Name = "Bob",
                       Code = 102,
                       Dob = new DateTime(1985, 8, 23),
                       City = "Delhi",
                       Gender = "Male",
                       Active = "Yes",
                       Image = "bob.jpg"
                   },
                   new Employee
                   {
                       Id = 3,
                       Name = "Charlie",
                       Code = 103,
                       Dob = new DateTime(1992, 3, 15),
                       City = "Bangalore",
                       Gender = "Male",
                       Active = "No",
                       Image = "charlie.jpg"
                   },
                   new Employee
                   {
                       Id = 4,
                       Name = "Diana",
                       Code = 104,
                       Dob = new DateTime(1995, 12, 5),
                       City = "Chennai",
                       Gender = "Female",
                       Active = "Yes",
                       Image = "diana.jpg"                   }
                );
        }
    }
}
