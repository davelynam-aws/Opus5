
using Microsoft.EntityFrameworkCore;
using OPUS_Demo_5.Models;

namespace OPUS_Demo_5
{
    public class DBCtx : DbContext
    {
        public DBCtx(DbContextOptions<DBCtx> options) : base(options)
        {
        }

        public DbSet<TestCustomer> Customers { get; set; }
    }
}