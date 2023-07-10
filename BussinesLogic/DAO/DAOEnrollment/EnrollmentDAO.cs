using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.EnrollmentMapper;
using PracticaWebServices.Data;
using PracticaWebServices.Entities;
using PracticaWebServices.Exceptions;
using System.Globalization;

namespace PracticaWebServices.BussinesLogic.DAO.DAOEnrollment
{
    public class EnrollmentDAO : IEnrollmentDAO
    {
        private readonly DataContext _context;

        public EnrollmentDAO(DataContext context)
        {
            _context = context;
        }

        public EnrollmentDTO AddEnrollmentDAO(Enrollment enrollment)
        {
            try
            {
                var existe = _context.Enrollments.Where(s => s.id_persona == enrollment.id_persona && s.status.ToLower() != "disabled")
                    .First();

                if (existe == null)
                {
                    var section = _context.Sections.Where(s => s.id == enrollment.id_section).First();


                    enrollment.status = "Enable";
                    enrollment.created_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);
                    if (section.enrollments == null)
                    {
                        section.enrollments = new List<Enrollment>();
                    }
                    section.enrollments.Add(enrollment);


                    _context.Enrollments.Add(enrollment);
                    _context.SaveChanges();


                    var data = _context.Enrollments.Where(u => u.id == enrollment.id).First();
                    return MapperEnrollment.EntityToDTO(data);
                }
                else throw new ExceptionsControl("Ya existe la persona");

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en agregar Inscripcion:" + " ", ex);
            }
        }
             

        public List<ShowEnrollmentDTO> ListEnrollmentDAO()
        {
            try
            {
                var lista = _context.Enrollments.Select(
                    u => new ShowEnrollmentDTO
                    {
                        id = u.id,
                        type = u.type,
                        status = u.status,
                        created_date = u.created_date,
                        sections = u.sections.Where(u => u.status.ToLower() != "disabled").ToList(),                        
                        person = u.person.status.ToLower() == "disabled" ? null : u.person
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

        public EnrollmentDTO DeleteEnrollmentDAO(int id)
        {
            try
            {
                var objeto = _context.Enrollments.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Inscripcion con el Id especificado.");
                }

                objeto.deleted_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);
                objeto.status = "Disabled";

                _context.SaveChanges();

                return MapperEnrollment.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Inscripcion:" + " ", ex);
            }
        }


    }
}
