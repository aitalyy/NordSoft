using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace KinoSoft
{
    class models
    {
        //A|/|TAJI
        public class Movie
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Disk> Disks;
            public Genre Genre { get; set; }
        }
        public class Client
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Lastname { get; set; }
            public string SecondName { get; set; }
            public string PhoneNumber { get; set; }
            public Passport Passport { get; set; }


        }
        public class Disk 
        {
            [Key]
            public int Id { get; set; }
            [StringLength(1000)]
            public string Name { get; set; }
            public virtual ICollection<Movie> Movies;
            public virtual ICollection<Order> Orders;
        }
        //BOBA
        public class Passport
        {
            [Key]
            public int number { get; set; }
            public int series { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
            public int ClientId { get; set; }
            public Client Client { get; set; }
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; } 
        }
        public class Order
        {
            public string Date { get; set; }
            public string Info { get; set; }
            public virtual ICollection<Disk> Disks;
            public int ClientId{get;set;}
            [ForeignKey("ClientId")]
            public Client Client{get;set;}
        }
        public class Genre
        {
            [Key]
            public string Genre { get; set; }
        }
        //BJIAD
        public class Actor
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
        }
        public class Producer
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
        }
        public class Report
        {
            [Key]
            public int Id { get; set; }
            public string Date { get; set; }
            public string Text { get; set; }

            public int EmployeetId { get; set; }
            [ForeignKey("EmployeeId")]
            public Employee Employee { get; set; }
        }
        //JIEXA
        public class Employee
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
            public string Login { get; set; }
            public string Passport { get; set; }
            public Passport Passport { get; set; }
        }
        public class Country
        {
            [Key]
            public string CountryName { get; set; }
        }
    }
}
