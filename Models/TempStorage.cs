using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaconSale.Models
{
    public class TempStorage
    {
        //  I don't really understand this all completely
        private static List<Movie> movies = new List<Movie>();

        public static IEnumerable<Movie> Movies => movies;

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
