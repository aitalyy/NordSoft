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

                //MovieCategory movieCategory = new MovieCategory
                //{
                //    Category = "18+",
                //};
                //db.MovieCategory.Add(movieCategory);

                //Movie movie10 = db.Movies.Where(k => k.Id == 3).FirstOrDefault();
                //Movie movie11 = db.Movies.Where(k => k.Id == 5).FirstOrDefault();
                //Movie movie12 = db.Movies.Where(k => k.Id == 6).FirstOrDefault();
                //Movie movie13 = db.Movies.Where(k => k.Id == 7).FirstOrDefault();
                //movie10.Category = movieCategory;
                //movie11.Category = movieCategory;
                //movie12.Category = movieCategory;
                //movie13.Category = movieCategory;
                //movie10.CategoryId = movieCategory.Id;
                //movie11.CategoryId = movieCategory.Id;
                //movie12.CategoryId = movieCategory.Id;
                //movie13.CategoryId = movieCategory.Id;

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
                            MovieId = movieId,
                            Movie = movie,
                            DiskId = diskId,
                            Disk = disk,
                        };
                        movie.Disks.Add(movieDisk);
                        My.MovieDisks.Add(movieDisk);
                    }
                    My.SaveChanges();
                }
            }
        }
    }
}