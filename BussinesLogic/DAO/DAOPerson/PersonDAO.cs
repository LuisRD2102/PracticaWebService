using Microsoft.EntityFrameworkCore;
using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.PersonMapper;
using PracticaWebServices.Data;
using PracticaWebServices.Entities;
using PracticaWebServices.Exceptions;
using System.Globalization;
using static System.Collections.Specialized.BitVector32;

namespace PracticaWebServices.BussinesLogic.DAO.DAOPerson
{
    public class PersonDAO : IPersonDAO
    {
        private readonly DataContext _context;

        public PersonDAO(DataContext context)
        {
            _context = context;
        }

        public PersonDTO AddPersonDAO(Person person)
        {
            try
            {

                person.status = "Enable";
                person.created_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);


                _context.Persons.Add(person);
                _context.SaveChanges();
                

                var data = _context.Persons.Where(u => u.id == person.id).First();
                return MapperPerson.EntityToDTO(data);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en agregar Persona:" + " ", ex);
            }
        }

        public PersonDTO UpdatePersonDAO(Person person, int id)
        {
            try
            {
                var objeto = _context.Persons.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Persona con el Id especificado.");
                }

                objeto.ci = person.ci;
                objeto.first_name = person.first_name;
                objeto.last_name = person.last_name;          

                _context.SaveChanges();

                return MapperPerson.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Persona:" + " ", ex);
            }
        }

        public List<ShowPersonDTO> ListPersonDAO()
        {
            try
            {
                var lista = _context.Persons.Select(
                    d => new ShowPersonDTO
                    {
                        id = d.id,
                        ci = d.ci,
                        first_name = d.first_name,
                        last_name = d.last_name,
                        created_date = d.created_date,
                        status = d.status,
                        enrollments = d.enrollments.Where(x => x.status.ToLower() != "disabled").ToList()

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

        public PersonDTO DeletePersonDAO(int id)
        {
            try
            {
                var objeto = _context.Persons.Find(id);
                if (objeto == null)
                {
                    throw new ExceptionsControl("No se encontró la Persona con el Id especificado.");
                }

                objeto.deleted_date = DateTimeOffset.ParseExact(DateTimeOffset.Now.ToString("O"), "O", CultureInfo.InvariantCulture);
                objeto.status = "Disabled";

                _context.SaveChanges();

                return MapperPerson.EntityToDTO(objeto);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en actualizar Persona:" + " ", ex);
            }
        }

        public List<ShowPersonDTO> ListStudentsDAO(int id_seccion)
        {
            try
            {
                var lista = _context.Persons.Where(x => x.enrollments.Any(x => x.type.ToLower() == "student" && x.sections.Any(x => x.id == id_seccion))).Select(
                    d => new ShowPersonDTO
                    {
                        id = d.id,
                        ci = d.ci,
                        first_name = d.first_name,
                        last_name = d.last_name,
                        created_date = d.created_date,
                        status = d.status,
                        enrollments = d.enrollments.Where(x => x.status.ToLower() != "disabled").ToList()

                    });                

                return lista.ToList();              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public List<ShowPersonDTO> ListTeacherDAO(int id_seccion)
        {
            try
            {
                var lista = _context.Persons.Where(x => x.enrollments.Any(x => x.type.ToLower() == "teacher" && x.sections.Any(x => x.id == id_seccion))).Select(
                    d => new ShowPersonDTO
                    {
                        id = d.id,
                        ci = d.ci,
                        first_name = d.first_name,
                        last_name = d.last_name,
                        created_date = d.created_date,
                        status = d.status,
                        enrollments = d.enrollments.Where(x => x.status.ToLower() != "disabled").ToList()

                    });

                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }
    }
}
