using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.Mapper.SchoolMapper
{
    public class MapperSection
    {
        public static SchoolDTO EntityToDTO(School d)
        {
            return new SchoolDTO()
            {
                name = d.name, 
                description = d.description,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O")),
                id_faculty = d.id_faculty
            };
        }

        public static School DtoToEntity(SchoolDTO d)
        {
            return new School()
            {
                name = d.name,
                description = d.description,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O")),
                id_faculty = d.id_faculty
            };
        }

        public static School DtoToEntity_Update(SchoolDTO d)
        {
            return new School()
            {
                name = d.name,
                description = d.description,
                status = d.status,
                created_date = d.created_date,
                id_faculty = d.id_faculty


            };
        }
    
    }
}
