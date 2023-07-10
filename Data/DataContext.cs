using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PracticaWebServices.Entities;

namespace PracticaWebServices.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //Creacion de los DbSeT

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Section> Sections { get; set; }
    
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

    }
}

