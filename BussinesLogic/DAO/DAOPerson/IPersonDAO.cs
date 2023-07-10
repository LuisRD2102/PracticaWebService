using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.DAO.DAOPerson
{
    public interface IPersonDAO
    {
        public PersonDTO AddPersonDAO(Person person);
        public PersonDTO UpdatePersonDAO(Person person, int id);
        public List<ShowPersonDTO> ListPersonDAO();
        public PersonDTO DeletePersonDAO(int id);
        public List<ShowPersonDTO> ListStudentsDAO(int id_seccion);
        public List<ShowPersonDTO> ListTeacherDAO(int id_seccion);
    }
}
