using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.DAO.DAOFaculty
{
    public interface IFacultyDAO
    {
        public FacultyDTO AddFacultyDAO(Faculty faculty);
        public FacultyDTO UpdateFacultyDAO(Faculty faculty, int id);
        public List<ShowFacultyDTO> ListFacultyDAO();
        public FacultyDTO DeleteFacultyDAO(int id);
    }
}
