using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticaWebServices.Entities
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string status { get; set; }
        public DateTimeOffset created_date { get; set; }
        public DateTimeOffset? deleted_date { get; set; }
        public string ci { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public ICollection<Enrollment>? enrollments { get; set; }
    }


}
