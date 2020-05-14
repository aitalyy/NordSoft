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
            using (Contex db = new Contex())
            {
                Disk disk = new Disk
                {
                    Name = name,
                    cost = cost,
                    format = format,
                    copy = copy,
                    
                };

                db.Disks.Add(disk);
                for (int i = 0; i < ArrayMoviesDisk.movies.Count; i++)
                {
                    //var movie = ArrayMoviesDisk.movies[i];
                    int movieId = Convert.ToInt32(ArrayMoviesDisk.arrayList[i]);
                    //int movieId = movie.Id;
                    Movie movie = db.Movies.Where(k => k.Id == movieId).FirstOrDefault()
                    int diskId = disk.Id;
                    MovieDisk movieDisk = new MovieDisk
                    {
                        MovieId = movieId,
                        Movie = movie,
                        DiskId = diskId,
                        Disk = disk,
                    };
                    db.MovieDisks.Add(movieDisk);
                }
                db.SaveChanges();
            }
        }
    }
}