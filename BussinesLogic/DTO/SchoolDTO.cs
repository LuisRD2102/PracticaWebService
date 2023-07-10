using PracticaWebServices.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PracticaWebServices.BussinesLogic.DTO
{
    public class SchoolDTO
    {
        public string name { get; set; }
        public string description { get; set; }

        [JsonIgnore]
        public string status { get; set; }

        [JsonIgnore]
        public DateTimeOffset created_date { get; set; }
        public int? id_faculty { get; set; }
    }

    public class ShowSchoolDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }      
        public DateTimeOffset created_date { get; set; }
        public int? id_faculty { get; set; }
        public Faculty faculty { get; set; }
        public ICollection<Section>? sections { get; set; }
    }
}
