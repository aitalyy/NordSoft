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
        public class ActorAdd
        {
            public static int FIO { get; set; }
        }
        public class CountryAdd
        {
            public static int Name { get; set; }
        }
        Contex My = new Contex();
        public void AddMovie(string name, DateTime god, MovieCategory category, ICollection<KinoSoft.MovieCountry> country ,ICollection<KinoSoft.MovieProducer> producer, ICollection<KinoSoft.MovieActor> actor, ICollection<KinoSoft.MovieGenre> genre, string opisanie)
        {
            Movie movie = new Movie
            {
                Name = name,
                Genres = genre,
                Producers = producer,
                Date = god,
                Category = category,
                Contries = country,
                Actors = actor,
                Description = opisanie
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
        public void addActor(string name, string family, string ot4)
        {
            My.Actors.Add(new Actor { FirstName = name, SecondName = family, LastName = ot4 });
            My.SaveChanges();
        }
        public void RemoveProducer(int id)
        {
            Producer producer = My.Producers.Where(k => k.Id == id).FirstOrDefault();
            My.Producers.Remove(producer);
            My.SaveChanges();
        }
        public void addCountry(string name)
        {
            My.Countrys.Add(new Country { CountryName = name });
            My.SaveChanges();
        }
        public void RemoveCountry(int id)
        {
            Country country = My.Countrys.Where(k => k.Id == id).FirstOrDefault();
            My.Countrys.Remove(country);
            My.SaveChanges();
        }
    }
}
