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
        public void AddMovie(string name, DateTime god, string category, string country, string producer, string actor, string genre)
        {
            Movie disk = new Movie
            {
                //Name = name,
                //Genres = genre,
                //Producers = producer,
                //Date = god,
                //Category = category,
                //Contries = country,
                //Actors = actor           
                //Actors = actor
            };

            My.Movies.Add(disk);
            My.SaveChanges();
        }
        public void addGenre(string name)
        {
            My.Genres.Add(new KinoSoft.Genre
            {
                Name = name,
            });
            My.SaveChanges();
        }
        public void RemoveGenre(int id)
        {
            Genre genre = My.Genres.Where(k => k.Id == id).FirstOrDefault();
            My.Genres.Remove(genre);
            My.SaveChanges();
        }
    }
}
