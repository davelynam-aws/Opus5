using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPUS_Demo_5.Models.DataContexts
{
    public class OpusContext : DbContext
    {
        // Constructor for the OPUS Database Context
        public OpusContext(DbContextOptions<OpusContext> options) : base(options)
        {
        }
       
        //s
        public DbSet<Quote> Quotes { get; set; }



    }
}
