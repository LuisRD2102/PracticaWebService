using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaWebServices.Entities
{
    public class Section
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string status { get; set; }
        public DateTimeOffset created_date { get; set; }
        public DateTimeOffset? deleted_date { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int uc { get; set; }
        public int semester { get; set; }
        public string type { get; set; }
        public float ht { get; set; }
        public float hp { get; set; }
        public float hl { get; set; }
        public int? id_school { get; set; }

        [ForeignKey("id_school")]
        public School school { get; set; }
        public ICollection<Enrollment>? enrollments { get; set; }

    }
        
}
