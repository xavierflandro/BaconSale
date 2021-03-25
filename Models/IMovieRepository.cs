using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaconSale.Models
{
    public class IMovieRepository
    {
        //  creates a queryable object of movie objects
        IQueryable<Movie> Movies { get; }
    }
}
