using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KinoSoft
{
    public class ArrayMoviesDisk
    {
        public static ArrayList arrayList;
        public static List<Movie> movies;
    }

    class LogicDisk
    {
        Contex My = new Contex();
        public void AddDisk(string name, string format, int copy, int cost)
        {
            Disk disk = new Disk
            {
                Name = name,
                cost = cost,
                format = format,
                copy = copy
            };

            My.Disks.Add(disk);
            My.SaveChanges();

            for(int i=0; i < ArrayMoviesDisk.movies.Count; i++)
            {
                Movie movie = ArrayMoviesDisk.movies[i];
                int movieId = movie.Id;
                int diskId = disk.Id;
                My.SaveChanges();
                MovieDisk movieDisk = new MovieDisk
                {
                    Movie = movie,
                    MovieId = movieId,
                    Disk = disk,
                    DiskId = diskId
                };
                My.SaveChanges();
                My.MovieDisks.Add(movieDisk);
                My.SaveChanges();

            }
            My.SaveChanges();
        }
    }
}