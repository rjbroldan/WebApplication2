using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieGenres MovieGenre { get; set; }
        public int MovieGenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }

}