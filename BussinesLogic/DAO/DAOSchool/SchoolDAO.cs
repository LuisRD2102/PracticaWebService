using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.SchoolMapper;
using PracticaWebServices.Data;
using PracticaWebServices.Entities;
using PracticaWebServices.Exceptions;
using System.Globalization;

namespace PracticaWebServices.BussinesLogic.DAO.DAOSchool
{
    public class SchoolDAO : ISchoolDAO
    {
        private readonly DataContext _context;

        public SchoolDAO(DataContext context)
        {
            _context = context;
        }

        public SchoolDTO AddSchoolDAO(School school)
        {
            try
            {

                school.status = "Enable";
                school.created_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);


                _context.Schools.Add(school);
                _context.SaveChanges();
                

                var data = _context.Schools.Where(u => u.id == school.id).First();
                return MapperSection.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en agregar Escuela:" + " ", ex);
            }
        }

        public SchoolDTO UpdateSchoolDAO(School school, int id)
        {
            try
            {
                var objeto = _context.Schools.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Escuela con el Id especificado.");
                }

                objeto.name = school.name;
                objeto.description = school.description;
                objeto.id_faculty = school.id_faculty;

                _context.SaveChanges();

                return MapperSection.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Escuela:" + " ", ex);
            }
        }

        public List<ShowSchoolDTO> ListSchoolDAO()
        {
            try
            {
                var lista = _context.Schools.Select(
                    u => new ShowSchoolDTO
                    {
                        id = u.id,
                        name = u.name,
                        description = u.description,
                        status = u.status,
                        created_date = u.created_date,
                        id_faculty = u.id_faculty,
                        faculty = u.faculty.status.ToLower() == "disabled" ? null : u.faculty,
                        sections = u.sections.Where(x => x.status.ToLower() != "disabled").ToList()

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

        public SchoolDTO DeleteSchoolDAO(int id)
        {
            try
            {
                var objeto = _context.Schools.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Escuela con el Id especificado.");
                }

                objeto.deleted_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);
                objeto.status = "Disabled";

                _context.SaveChanges();

                return MapperSection.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Escuela:" + " ", ex);
            }
        }
    }
}
