using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.DAO.DAOEnrollment
{
    public interface IEnrollmentDAO
    {
        public EnrollmentDTO AddEnrollmentDAO(Enrollment enrollment);
        public List<ShowEnrollmentDTO> ListEnrollmentDAO();
        public EnrollmentDTO DeleteEnrollmentDAO(int id);
    }
}
