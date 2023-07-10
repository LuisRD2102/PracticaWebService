using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.Mapper.PersonMapper
{
    public class MapperPerson
    {
        public static PersonDTO EntityToDTO(Person d)
        {
            return new PersonDTO()
            {
                ci = d.ci, 
                first_name = d.first_name,
                last_name = d.last_name,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O"))
            };
        }

        public static Person DtoToEntity(PersonDTO d)
        {
            return new Person()
            {
                ci = d.ci,
                first_name = d.first_name,
                last_name = d.last_name,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O"))
            };
        }

        public static Person DtoToEntity_Update(PersonDTO d)
        {
            return new Person()
            {
                ci = d.ci,
                first_name = d.first_name,
                last_name = d.last_name,
                created_date = d.created_date,
                status = d.status


            };
        }
    
    }
}
