using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace KinoSoft
{
    public class Contex : DbContext
    {
        public Contex() : base("KinoSoft2") { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countrys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
