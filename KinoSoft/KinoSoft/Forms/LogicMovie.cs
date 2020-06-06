using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.ObjectModel;

namespace KinoSoft.Forms
{
    //--------------------------------------------------------------------------------------------- /Класс для добавления продюссера из дочернего окна
    public class ProducerAdd
    {
        public static List<Producer> id;
    }
    //--------------------------------------------------------------------------------------------- /Класс для добавления актёров из дочернего окна
    public class ActorAdd
    {
        public static List<Actor> id;
    }
    //--------------------------------------------------------------------------------------------- /Класс для добавления страны из дочернего окна
    public class CountryAdd
    {
        public static List<Country> id;
    }
    //--------------------------------------------------------------------------------------------- /Класс для добавления жанра из дочернего окна
    public class GenreAdd
    {
        public static List<Genre> id;
    }
    //--------------------------------------------------------------------------------------------- /LogicMovie
    class LogicMovie
    {
        Contex My = new Contex();
        //--------------------------------------------------------------------------------------------- // Добавление фильма
        public void AddMovie(string name, DateTime god, string category, ICollection<KinoSoft.MovieCountry> country ,ICollection<KinoSoft.MovieProducer> producer, ICollection<KinoSoft.MovieActor> actor, ICollection<KinoSoft.MovieGenre> genre, string opisanie)
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
        //--------------------------------------------------------------------------------------------- // Добавление жанра
        public void addGenre(string name)
        {
            My.Genres.Add(new KinoSoft.Genre
            {
                Name = name,
            });
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Удаление жанра
        public void RemoveGenre(int id)
        {
            Genre genre = My.Genres.Where(k => k.Id == id).FirstOrDefault();
            My.Genres.Remove(genre);
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Добавление категории
        public void addCategory(string name)
        {
            My.MovieCategory.Add(new KinoSoft.MovieCategory
            {
                Category = name,
            });
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Добавление режиссёра
        public void addProducer(string name, string family, string ot4)
        {
            My.Producers.Add(new Producer { FirstName = name, SecondName = family, LastName = ot4 });
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Удаление режиссёра
        public void RemoveProducer(int id)
        {
            Producer producer = My.Producers.Where(k => k.Id == id).FirstOrDefault();
            My.Producers.Remove(producer);
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Добавление актёра
        public void addActor(string name, string family, string ot4)
        {
            My.Actors.Add(new Actor { FirstName = name, SecondName = family, LastName = ot4 });
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Удаление актёра
        public void RemoveActor(int id)
        {
            Actor actor = My.Actors.Where(k => k.Id == id).FirstOrDefault();
            My.Actors.Remove(actor);
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Добавление страны
        public void addCountry(string name)
        {
            My.Countrys.Add(new Country { CountryName = name });
            My.SaveChanges();
        }
        //--------------------------------------------------------------------------------------------- // Удаление страны
        public void RemoveCountry(int id)
        {
            Country country = My.Countrys.Where(k => k.Id == id).FirstOrDefault();
            My.Countrys.Remove(country);
            My.SaveChanges();
        }
    }
}
