using Microsoft.AspNetCore.Mvc;
using PracticaWebServices.BussinesLogic.DAO.DAOFaculty;
using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.FacultyMapper;
using PracticaWebServices.Exceptions;
using PracticaWebServices.Response;

namespace PracticaWebServices.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyDAO _daoFaculty;

        public FacultyController(IFacultyDAO dao)
        {
            _daoFaculty = dao;
        }
        [HttpPost]
        [Route("AddFaculty/")]
        public ApplicationResponse<FacultyDTO> AddFaculty([FromBody] FacultyDTO dto1)
        {
            var response = new ApplicationResponse<FacultyDTO>();
            try
            {
                response.Data = _daoFaculty.AddFacultyDAO(MapperSchool.DtoToEntity(dto1));
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPut]
        [Route("UpdateFaculty/{id}")]
        public ApplicationResponse<FacultyDTO> UpdateFaculty([FromBody] FacultyDTO dto1, [FromRoute] int id)
        {
            var response = new ApplicationResponse<FacultyDTO>();
            try
            {
                response.Data = _daoFaculty.UpdateFacultyDAO(MapperSchool.DtoToEntity_Update(dto1), id);
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
        [Route("ListFaculty/")]
        public ApplicationResponse<List<ShowFacultyDTO>> ConsultarDepartamento()
        {
            var response = new ApplicationResponse<List<ShowFacultyDTO>>();
            try
            {
                response.Data = _daoFaculty.ListFacultyDAO();
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
        [Route("DeleteFaculty/{id}")]
        public ApplicationResponse<FacultyDTO> DeleteFaculty([FromRoute] int id)
        {
            var response = new ApplicationResponse<FacultyDTO>();
            try
            {
                response.Data = _daoFaculty.DeleteFacultyDAO(id);
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
