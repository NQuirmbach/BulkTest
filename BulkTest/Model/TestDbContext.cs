using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkTest.Model
{
    public class TestDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
        }
    }
}
