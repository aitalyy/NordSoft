using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoSoft.Forms
{
    class LogicMovie
    {
        Contex My = new Contex();
        public void AddMovie(string name)
        {
            Movie disk = new Movie
            {
                Name = name
            };

            My.Movies.Add(disk);
            My.SaveChanges();
        }
    }
}
