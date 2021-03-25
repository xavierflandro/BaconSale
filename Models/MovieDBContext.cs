﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaconSale.Models
{
    public class MovieDBContext : DbContext 
    {
        public MovieDBContext (DbContextOptions<MovieDBContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
