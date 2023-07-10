using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.Mapper.EnrollmentMapper
{
    public class MapperEnrollment
    {
        public static EnrollmentDTO EntityToDTO(Enrollment d)
        {
            return new EnrollmentDTO()
            {
                id_persona = d.id_persona,
                type = d.type, 
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O")),
                id_section = d.id_section
            };
        }

        public static Enrollment DtoToEntity(EnrollmentDTO d)
        {
            return new Enrollment()
            {
                id_persona = d.id_persona,
                type = d.type,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O")),
                id_section = d.id_section
            };
        }

        public static Enrollment DtoToEntity_Update(EnrollmentDTO d)
        {
            return new Enrollment()
            {              

                id_persona = d.id_persona,
                status = d.status,
                created_date = d.created_date,
                type = d.type,
                id_section = d.id_section


            };
        }
    
    }
}
