using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaWebServices.Entities
{
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string status { get; set; }
        public DateTimeOffset created_date { get; set; }
        public DateTimeOffset? deleted_date { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? id_faculty { get; set; }

        [ForeignKey("id_faculty")]
        public Faculty faculty { get; set; }
        public ICollection<Section>? sections { get; set; }
    }
}
