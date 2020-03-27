using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace KinoSoft
{
        public enum OrderStatus { Open, Closed, Extended, Expired }
        //A|/|TAJI
        public class Movie
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<MovieGenre> Genres { get; set; }
            public virtual ICollection<MovieDisk> Disks { get; set; }
            public virtual ICollection<MovieProducer> Producers { get; set; }
            public virtual ICollection<MovieActor> Actors { get; set; }
            public virtual ICollection<MovieCountry> Contries { get; set; }
            public virtual MovieDescription Description { get; set; }
            public virtual MovieDate Date { get; set; }
            public virtual MovieCategory Category { get; set; }
            
        }
        public class MovieCategory
        {
            [Key]
            public int Id { get; set; }

            public string category { get; set; }
            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public virtual Movie Movie { get; set; }
        }
        public class MovieDate
        {
            [Key]
            public DateTime date { get; set; }
            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public virtual Movie Movie { get; set; }
        }
        public class MovieDescription
        {
            [Key]
            public string Description { get; set; }
            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public virtual Movie Movie { get; set; }

        }
        public class MovieActor
        {
            [Key]
            public int Id { get; set; }

            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public Movie Movie { get; set; }

            public int ActorId { get; set; }
            [ForeignKey("ActorId")]
            public Actor Actor { get; set; }
        }
        public class MovieProducer
        {
            [Key]
            public int Id { get; set; }

            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public Movie Movie { get; set; }

            public int ProducerId { get; set; }
            [ForeignKey("ProducerId")]
            public Producer Producer { get; set; }
        }
        public class MovieGenre
        {
            [Key]
            public int Id { get; set; }

            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public Movie Movie { get; set; }

            public int GenreId { get; set; }
            [ForeignKey("GenreId")]
            public Genre Genre { get; set; }
        }
        public class MovieDisk
        {
            [Key]
            public int Id { get; set; }

            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public Movie Movie { get; set; }

            public int DiskId { get; set; }
            [ForeignKey("DiskId")]
            public Disk Disk { get; set; }
        }
        public class MovieCountry
        {
            [Key]
            public int Id { get; set; }

            public int MovieId { get; set; }
            [ForeignKey("MovieId")]
            public Movie Movie { get; set; }

            public int CountryId { get; set; }
            [ForeignKey("CountryId")]
            public Country Country { get; set; }
        }
        public class Client : Person
        {
            public string PhoneNumber { get; set; }
            public bool InBalckList { get; set; }
            public virtual ICollection<Order> Orders { get; set; }
        }
        public class Disk 
        {
            [Key]
            public int Id { get; set; }
            [StringLength(1000)]
            public string Name { get; set; }
            public int cost { get; set; }
            public string format { get; set; }
            public int copy { get; set; }
            public virtual ICollection<MovieDisk> Movies { get; set; }
            public virtual ICollection<DiskOrder> Orders { get; set; }
        }
        public class DiskOrder
        {
            [Key]
            public int Id { get; set; }

            public int DiskId { get; set; }
            [ForeignKey("DiskId")]
            public Movie Disk { get; set; }

            public int OrderId { get; set; }
            [ForeignKey("OrderId")]
            public Order Order { get; set; }
        }
        public class Person 
        {
            [Key]
            public int Id { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SecondName { get; set; }
            public int? PassportId { get; set; }
            [ForeignKey("PassportId")]
            public Passport Passport { get; set; }
        }
        //BOBA
        public class Passport
        {
            [Key]
            public int Id { get; set; }

            public int number { get; set; }
            public int series { get; set; }
            /*public int PersonId { get; set; }
            [ForeignKey("PersonId")]
            public Person Person { get; set; }*/
        }
        public class Order
        {
            [Key]
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public DateTime EndDate { get; set; }
            public OrderStatus Status { get; set; }
            public virtual ICollection<DiskOrder> Disks { get; set; }
            public int ClientId{get;set;}
            [ForeignKey("ClientId")]
            public Client Client{get;set;}
        }
        public class Genre
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<MovieGenre> Movies { get; set; }
        }
        public class Actor : Person
        {
            public virtual ICollection<MovieActor> Movies { get; set; }
        }
        public class Producer : Person
        {
            public virtual ICollection<MovieProducer> Movies { get; set; }
        }
        public class Report
        {
            [Key]
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Text { get; set; }

            public int EmployeeId { get; set; }
            [ForeignKey("EmployeeId")]
            public Employee Employee { get; set; }
        }
        public class Employee:Person
        {
            [Key]
            public string Login { get; set; }
            public string Password { get; set; }

            public int RoleId { get; set; }
            [ForeignKey("RoleId")]
            public Role UserRole { get; set; }
        }
        public class Role
        {
            public string Name { get; set; }
            public ICollection<Employee> employees { get; set; }
        }
        public class Country
        {
            [Key]
            public int Id { get; set; }
            public string CountryName { get; set; }
            public virtual ICollection<MovieCountry> Movies { get; set; }
        }
}