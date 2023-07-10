using Microsoft.EntityFrameworkCore;
using PracticaWebServices.Entities;

namespace PracticaWebServices.Data
{
    public interface IDataContext
    {
        DbContext DbContext { get; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
