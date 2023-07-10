using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.SectionMapper;
using PracticaWebServices.Data;
using PracticaWebServices.Entities;
using PracticaWebServices.Exceptions;
using System.Globalization;

namespace PracticaWebServices.BussinesLogic.DAO.DAOSection
{
    public class SectionDAO : ISectionDAO
    {
        private readonly DataContext _context;

        public SectionDAO(DataContext context)
        {
            _context = context;
        }

        public SectionDTO AddSectionDAO(Section section)
        {
            try
            {

                section.status = "Enable";
                section.created_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);


                _context.Sections.Add(section);
                _context.SaveChanges();
                

                var data = _context.Sections.Where(u => u.id == section.id).First();
                return MapperPerson.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en agregar Seccion:" + " ", ex);
            }
        }

        public SectionDTO UpdateSectionDAO(Section section, int id)
        {
            try
            {
                var objeto = _context.Sections.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Seccion con el Id especificado.");
                }

                objeto.name = section.name;
                objeto.description = section.description;
                objeto.uc  = section.uc;
                objeto.type = section.type;
                objeto.semester = section.semester;
                objeto.ht = section.ht;
                objeto.hp = section.hp;
                objeto.hl = section.hl;
                objeto.id_school = section.id_school;     

                _context.SaveChanges();

                return MapperPerson.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Seccion:" + " ", ex);
            }
        }

        public List<ShowSectionDTO> ListSectionDAO()
        {
            try
            {
                var lista = _context.Sections.Select(
                    u => new ShowSectionDTO
                    {
                        id = u.id,
                        name = u.name,
                        description = u.description,
                        uc = u.uc,
                        type = u.type,
                        semester = u.semester,
                        ht = u.ht,
                        hp = u.hp,
                        hl = u.hl,
                        status = u.status,
                        created_date = u.created_date,
                        id_school = u.id_school,
                        school = u.school.status.ToLower() == "disabled" ? null : u.school,
                        enrollments = u.enrollments.Where(x => x.status.ToLower() != "disabled").ToList()

                    }
                );

                return lista.Where(x=> x.status.ToLower() != "disabled").ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public SectionDTO DeleteSectionDAO(int id)
        {
            try
            {
                var objeto = _context.Sections.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Seccion con el Id especificado.");
                }

                objeto.deleted_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);
                objeto.status = "Disabled";

                _context.SaveChanges();

                return MapperPerson.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Seccion:" + " ", ex);
            }
        }
    }
}
