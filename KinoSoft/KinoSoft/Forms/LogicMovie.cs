using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoSoft.Forms
{
    class LogicMovie
    {
        public class ProducerAdd
        {
            public static int FIO { get; set; }
        }
        Contex My = new Contex();
        public void AddMovie(string name, DateTime god, /*MovieCategory category,/* MovieCountry country */ICollection<KinoSoft.MovieProducer> producer,/* string actor*/ ICollection<KinoSoft.MovieGenre> genre)
        {
            Movie movie = new Movie
            {
                Name = name,
                Genres = genre,
                Producers = producer,
                Date = god,
                //Category = category,
                //Contries = country,
                //Actors = actor           
            };

            My.Movies.Add(movie);
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
        public void addCategory(string name)
        {
            My.MovieCategory.Add(new KinoSoft.MovieCategory
            {
                Category = name,
            });
            My.SaveChanges();
        }
        public void RemoveGenre(int id)
        {
            Genre genre = My.Genres.Where(k => k.Id == id).FirstOrDefault();
            My.Genres.Remove(genre);
            My.SaveChanges();
        }
        public void addProducer(string name, string family, string ot4)
        {
            My.Producers.Add(new Producer { FirstName = name, SecondName = family, LastName = ot4 });
            My.SaveChanges();
        }
        public void RemoveProducer(int id)
        {
            Producer producer = My.Producers.Where(k => k.Id == id).FirstOrDefault();
            My.Producers.Remove(producer);
            My.SaveChanges();
        }
    }
}
