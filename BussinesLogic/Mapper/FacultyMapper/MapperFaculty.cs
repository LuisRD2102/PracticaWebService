using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.Mapper.FacultyMapper
{
    public class MapperSchool
    {
        public static FacultyDTO EntityToDTO(Faculty d)
        {
            return new FacultyDTO()
            {
                name = d.name, 
                description = d.description,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O"))
            };
        }

        public static Faculty DtoToEntity(FacultyDTO d)
        {
            return new Faculty()
            {
                name = d.name,
                description = d.description,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O"))
        };
        }

        public static Faculty DtoToEntity_Update(FacultyDTO d)
        {
            return new Faculty()
            {
                name = d.name,
                description = d.description,
                status = d.status,
                created_date = d.created_date
              

            };
        }
    
    }
}
