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
        }
        public class Client
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Lastname { get; set; }
            public string SacondName { get; set; }

            public Passport Passport { get; set; }


        }
        public class Disk 
        {
            [Key]
            public int Id { get; set; }
            [SetLength(1000)]
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
        }
        //JIEXA
        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
        }
        public class Country
        {
            public string CountryName { get; set; }
        }
    }
}
