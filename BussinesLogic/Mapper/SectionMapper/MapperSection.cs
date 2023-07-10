using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.Mapper.SectionMapper
{
    public class MapperPerson
    {
        public static SectionDTO EntityToDTO(Section d)
        {
            return new SectionDTO()
            {
                name = d.name, 
                description = d.description,
                uc = d.uc,
                type = d.type,
                semester = d.semester,
                ht = d.ht,
                hp = d.hp,
                hl = d.hl,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O")),
                id_school = d.id_school
            };
        }

        public static Section DtoToEntity(SectionDTO d)
        {
            return new Section()
            {
                name = d.name,
                description = d.description,
                uc = d.uc,
                type = d.type,
                semester = d.semester,
                ht = d.ht,
                hp = d.hp,
                hl = d.hl,
                created_date = DateTime.Parse(DateTime.UtcNow.ToString("O")),
                id_school = d.id_school
            };
        }

        public static Section DtoToEntity_Update(SectionDTO d)
        {
            return new Section()
            {
                name = d.name,
                description = d.description,
                uc = d.uc,
                type = d.type,
                semester = d.semester,
                ht = d.ht,
                hp = d.hp,
                hl = d.hl,
                status = d.status,
                created_date = d.created_date,
                id_school = d.id_school


            };
        }
    
    }
}
