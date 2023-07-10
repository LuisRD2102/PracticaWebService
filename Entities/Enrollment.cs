using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PracticaWebServices.Entities
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string status { get; set; }
        public DateTimeOffset created_date { get; set; }
        public DateTimeOffset? deleted_date { get; set; }
        public string type { get; set; }
        public ICollection<Section>? sections { get; set; }
        public int id_persona { get; set; }

        [ForeignKey("id_persona")]
        public Person person { get; set; }

        [NotMapped]
        public int id_section { get; set; }
    }

   
}
