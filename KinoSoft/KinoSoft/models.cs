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
    }
}
