using Microsoft.AspNetCore.Mvc;
using PracticaWebServices.BussinesLogic.DAO.DAOEnrollment;
using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.EnrollmentMapper;
using PracticaWebServices.Exceptions;
using PracticaWebServices.Response;

namespace PracticaWebServices.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentDAO _daoEnrollment;

        public EnrollmentController(IEnrollmentDAO dao)
        {
            _daoEnrollment = dao;
        }
        [HttpPost]
        [Route("AddEnrollment/")]
        public ApplicationResponse<EnrollmentDTO> AddEnrollment([FromBody] EnrollmentDTO dto1)
        {
            var response = new ApplicationResponse<EnrollmentDTO>();
            try
            {
                response.Data = _daoEnrollment.AddEnrollmentDAO(MapperEnrollment.DtoToEntity(dto1));
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

   
        [HttpGet]
        [Route("ListEnrollment/")]
        public ApplicationResponse<List<ShowEnrollmentDTO>> ConsultarDepartamento()
        {
            var response = new ApplicationResponse<List<ShowEnrollmentDTO>>();
            try
            {
                response.Data = _daoEnrollment.ListEnrollmentDAO();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteEnrollment/{id}")]
        public ApplicationResponse<EnrollmentDTO> DeleteEnrollment([FromRoute] int id)
        {
            var response = new ApplicationResponse<EnrollmentDTO>();
            try
            {
                response.Data = _daoEnrollment.DeleteEnrollmentDAO(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}
