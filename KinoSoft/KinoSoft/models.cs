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
        public class Movie
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Client
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Lastname { get; set; }
            public string SacondName { get; set; }
        }
        public class Disk 
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Movie> Movie;
        }

        public class Passport
        {
            [Key]
            public int number { get; set; }
            public int series { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
            
        }
        //Actor, Producer, Report
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
    }
}
