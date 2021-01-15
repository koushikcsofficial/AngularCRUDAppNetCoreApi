using Customer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Customer.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<CustomerDetail> Customers { get; set; }
    }
}
