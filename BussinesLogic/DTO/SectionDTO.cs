using PracticaWebServices.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PracticaWebServices.BussinesLogic.DTO
{
    public class SectionDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public int uc { get; set; }
        public int semester { get; set; }
        public string type { get; set; }
        public float ht { get; set; }
        public float hp { get; set; }
        public float hl { get; set; }

        [JsonIgnore]
        public string status { get; set; }

        [JsonIgnore]
        public DateTimeOffset created_date { get; set; }
        public int? id_school { get; set; }

       
       
       
    }

    public class ShowSectionDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int uc { get; set; }
        public int semester { get; set; }
        public string type { get; set; }
        public float ht { get; set; }
        public float hp { get; set; }
        public float hl { get; set; }
        public string status { get; set; }      
        public DateTimeOffset created_date { get; set; }
        public int? id_school { get; set; }
        public School school { get; set; }
        public ICollection<Enrollment>? enrollments { get; set; }

    }
}
