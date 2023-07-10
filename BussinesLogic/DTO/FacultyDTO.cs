using PracticaWebServices.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;

namespace PracticaWebServices.BussinesLogic.DTO
{
    public class FacultyDTO
    {
        public string name { get; set; }
        public string description { get; set; }

        [JsonIgnore]
        public string status { get; set; }

        [JsonIgnore]
        public DateTimeOffset created_date { get; set; }

    }

    public class ShowFacultyDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }      
        public DateTimeOffset created_date { get; set; }
        public ICollection<School>? schools { get; set; }
      

    }
}
