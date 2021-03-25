using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaconSale.Models;

namespace BaconSale.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDBContext _context;

        public EFMovieRepository (MovieDBContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
