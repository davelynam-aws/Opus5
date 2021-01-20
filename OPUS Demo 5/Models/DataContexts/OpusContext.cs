using Microsoft.EntityFrameworkCore;
using OPUS_Demo_5.Models.QuoteMatrix;
using OPUS_Demo_5.Models.CustomerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OPUS_Demo_5.Models.UserIdentity;

namespace OPUS_Demo_5.Models.DataContexts
{
    public class OpusContext : DbContext
    {
        // Constructor for the OPUS Database Context.
        public OpusContext(DbContextOptions<OpusContext> options) : base(options)
        {
        }



        // Quote Related related record sets.
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<BifoldItem> BifoldItems { get; set; }
        public DbSet<ExtraItem> ExtraItems { get; set; }
        public DbSet<GlassItem> GlassItems { get; set; }
        public DbSet<PeripheralItem> PeripheralItems { get; set; }


        // Quote Matrix related record sets.
        public DbSet<BifoldStyle> BifoldStyles { get; set; }
        public DbSet<GlassOption> GlassOption { get; set; }
        public DbSet<HardwareColour> HardwareColours { get; set; }
        public DbSet<PeripheralOption> PeripheralOptions { get; set; }
        public DbSet<PricingFactor> PricingFactors { get; set; }
        public DbSet<ProfileColour> ProfileColours { get; set; }


        // Customer related record sets.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }



        // Identity related record sets.
        public DbSet<DemoUserIdentity> UserIdentities { get; set; }
        public DbSet<DemoRole> Roles { get; set; }
        //public DbSet<DemoUserRole> UserRoles { get; set; }
        //public DbSet<DemoUserCompanyPermission> UserCompanyPermissions { get; set; }


    }
}
