using Core.Entities;
using Microsoft.EntityFrameworkCore;
//using Queries.Persistence.EntityConfigurations;
//using System.Data.Entity;

namespace Infrastructure.Data
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
        {
        }

        //public PlutoContext()
        //    : base("name=PlutoContext")
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}
        public PlutoContext(DbContextOptions<PlutoContext> options) : base(options)
        {
            // this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Issue> Issues { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CourseConfiguration());
        //}
    }
}
