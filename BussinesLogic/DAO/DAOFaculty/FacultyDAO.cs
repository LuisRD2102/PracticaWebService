using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.FacultyMapper;
using PracticaWebServices.Data;
using PracticaWebServices.Entities;
using PracticaWebServices.Exceptions;
using System.Globalization;

namespace PracticaWebServices.BussinesLogic.DAO.DAOFaculty
{
    public class FacultyDAO : IFacultyDAO
    {
        private readonly DataContext _context;

        public FacultyDAO(DataContext context)
        {
            _context = context;
        }

        public FacultyDTO AddFacultyDAO(Faculty faculty)
        {
            try
            {

                faculty.status = "Enable";
                faculty.created_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);


                _context.Faculties.Add(faculty);
                _context.SaveChanges();
                

                var data = _context.Faculties.Where(u => u.id == faculty.id).First();
                return MapperSchool.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en agregar Facultad:" + " ", ex);
            }
        }

        public FacultyDTO UpdateFacultyDAO(Faculty faculty, int id)
        {
            try
            {
                var objeto = _context.Faculties.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Facultad con el Id especificado.");
                }

                objeto.name = faculty.name;
                objeto.description = faculty.description;

                _context.SaveChanges();

                return MapperSchool.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Facultad:" + " ", ex);
            }
        }

        public List<ShowFacultyDTO> ListFacultyDAO()
        {
            try
            {
                var lista = _context.Faculties.Select(
                    u => new ShowFacultyDTO
                    {
                        id = u.id,
                        name = u.name,
                        description = u.description,
                        status = u.status,
                        created_date = u.created_date,
                        schools = u.schools.Where(u => u.status.ToLower() != "disabled").ToList()

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

        public FacultyDTO DeleteFacultyDAO(int id)
        {
            try
            {
                var objeto = _context.Faculties.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Facultad con el Id especificado.");
                }

                objeto.deleted_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);
                objeto.status = "Disabled";

                _context.SaveChanges();

                return MapperSchool.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Facultad:" + " ", ex);
            }
        }
    }
}
