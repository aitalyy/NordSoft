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

namespace KinoSoft
{
    public class ArrayMoviesDisk
    {
        public static ArrayList arrayList;
        public static List<Movie> movies;
    }

    public class EditMovieDisk
    {
        public static Disk disk;
        public static bool check = false;
    }

    class LogicDisk
    {
        public void AddDisk(string name, string format, int copy, int cost)
        {
            using (Contex db = new Contex())
            {
                Disk disk = new Disk
                {
                    Name = name,
                    cost = cost,
                    format = format,
                    copy = copy,
                    
                };
                //diskGl = disk;
                db.Disks.Add(disk);
                db.SaveChanges();
                /*using (Contex My = new Contex())
                {*/
                    for (int i = 0; i < ArrayMoviesDisk.movies.Count; i++)
                    {
                        //var movie = ArrayMoviesDisk.movies[i];
                        int movieId = Convert.ToInt32(ArrayMoviesDisk.arrayList[i]);
                        //int movieId = movie.Id;
                        //Movie movie2 = My.Movies.Include(s => s.).First
                        //MessageBox.Show(movie2.Name);
                        Movie movie2 = db.Movies.First(s => s.Id == movieId);
                        MessageBox.Show(movie2.Name);
                        //Movie movie = My.Movies.Where(k => k.Id == movieId).FirstOrDefault();
                        //Movie movie1 = movie;
                        int diskId = disk.Id;

                        MovieDisk movieDisk = new MovieDisk
                        {
                            MovieId = movieId,
                            DiskId = diskId,
                        };
                        db.MovieDisks.Add(movieDisk);
                    }
                    db.SaveChanges();
                //}
            }
            
        }
    }
}