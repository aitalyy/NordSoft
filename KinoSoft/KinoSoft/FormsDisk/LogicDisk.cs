using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace KinoSoft
{
    public class ArrayMoviesDisk
    {
        public static ArrayList arrayList;
        public static List<Movie> movies;
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
                    copy = copy
                };

                db.Disks.Add(disk);
                db.SaveChanges();

                using (Contex My = new Contex())
                {
                    for (int i = 0; i < ArrayMoviesDisk.movies.Count; i++)
                    {
                        //var movie = ArrayMoviesDisk.movies[i];
                        int movieId = Convert.ToInt32(ArrayMoviesDisk.arrayList[i]);
                        //int movieId = movie.Id;
                        Movie movie = My.Movies.Where(k => k.Id == movieId).FirstOrDefault();
                        int diskId = disk.Id;
                        MovieDisk movieDisk = new MovieDisk
                        {
                            Movie = movie,
                            MovieId = movieId,
                            Disk = disk,
                            DiskId = diskId
                        };
                        My.MovieDisks.Add(movieDisk);
                    }
                    My.SaveChanges();
                }



            }


            
            
        }
    }
}