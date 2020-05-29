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

    class LogicDisk
    {
        public void AddDisk(string name, string format, int copy, int cost)
        {
            Disk diskGl;
            using (Contex db = new Contex())
            {
                Disk disk = new Disk
                {
                    Name = name,
                    cost = cost,
                    format = format,
                    copy = copy,
                    
                };
                diskGl = disk;
                db.Disks.Add(disk);
                using (Contex My = new Contex())
                {
                    System.Diagnostics.Debugger.NotifyOfCrossThreadDependency();
                    for (int i = 0; i < ArrayMoviesDisk.movies.Count; i++)
                    {
                        //var movie = ArrayMoviesDisk.movies[i];
                        int movieId = Convert.ToInt32(ArrayMoviesDisk.arrayList[i]);
                        //int movieId = movie.Id;

                        Movie movie = My.Movies.Where(k => k.Id == movieId).FirstOrDefault();
                        Movie movie1 = movie;
                        int diskId = diskGl.Id;

                        MovieDisk movieDisk = new MovieDisk
                        {
                            MovieId = movieId,
                            Movie = movie1,
                            DiskId = diskId,
                            Disk = diskGl,
                        };
                        movieDisk.Movie = movie;
                        My.MovieDisks.Add(movieDisk);
                    }
                    My.SaveChanges();
                }
            }
            
        }
    }
}