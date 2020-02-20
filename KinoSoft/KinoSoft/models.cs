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
            public string name { get; set; }
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
    }
}
