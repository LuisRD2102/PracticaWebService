using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.DAO.DAOSchool
{
    public interface ISchoolDAO
    {
        public SchoolDTO AddSchoolDAO(School school);
        public SchoolDTO UpdateSchoolDAO(School school, int id);
        public List<ShowSchoolDTO> ListSchoolDAO();
        public SchoolDTO DeleteSchoolDAO(int id);
    }
}
