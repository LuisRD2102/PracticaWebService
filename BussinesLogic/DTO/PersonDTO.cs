using PracticaWebServices.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PracticaWebServices.BussinesLogic.DTO
{
    public class PersonDTO
    {
        public string ci { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        [JsonIgnore]
        public string status { get; set; }

        [JsonIgnore]
        public DateTimeOffset created_date { get; set; }

    }

    public class ShowPersonDTO
    {
        public int id { get; set; }
        public string ci { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string status { get; set; }      
        public DateTimeOffset created_date { get; set; }
        public ICollection<Enrollment>? enrollments { get; set; }

    }
}
