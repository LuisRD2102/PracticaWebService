using PracticaWebServices.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PracticaWebServices.BussinesLogic.DTO
{
    public class EnrollmentDTO
    {
        public string type { get; set; }

        [JsonIgnore]
        public string status { get; set; }

        [JsonIgnore]
        public DateTimeOffset created_date { get; set; }
        public int id_persona { get; set; }
        public int id_section { get; set; }

    }

    public class ShowEnrollmentDTO
    {
        public int id { get; set; }
        public string status { get; set; }
        public DateTimeOffset created_date { get; set; }
        public string type { get; set; }
        public ICollection<Section>? sections { get; set; }
        public Person person { get; set; }

    }
}
