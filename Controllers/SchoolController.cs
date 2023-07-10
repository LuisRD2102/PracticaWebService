using Microsoft.AspNetCore.Mvc;
using PracticaWebServices.BussinesLogic.DAO.DAOSchool;
using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.SchoolMapper;
using PracticaWebServices.Exceptions;
using PracticaWebServices.Response;

namespace PracticaWebServices.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolDAO _daoSchool;

        public SchoolController(ISchoolDAO dao)
        {
            _daoSchool = dao;
        }
        [HttpPost]
        [Route("AddSchool/")]
        public ApplicationResponse<SchoolDTO> AddSchool([FromBody] SchoolDTO dto1)
        {
            var response = new ApplicationResponse<SchoolDTO>();
            try
            {
                response.Data = _daoSchool.AddSchoolDAO(MapperSection.DtoToEntity(dto1));
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
        [Route("UpdateSchool/{id}")]
        public ApplicationResponse<SchoolDTO> UpdateSchool([FromBody] SchoolDTO dto1, [FromRoute] int id)
        {
            var response = new ApplicationResponse<SchoolDTO>();
            try
            {
                response.Data = _daoSchool.UpdateSchoolDAO(MapperSection.DtoToEntity_Update(dto1), id);
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
        [Route("ListSchool/")]
        public ApplicationResponse<List<ShowSchoolDTO>> ListSchool()
        {
            var response = new ApplicationResponse<List<ShowSchoolDTO>>();
            try
            {
                response.Data = _daoSchool.ListSchoolDAO();
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
        [Route("DeleteSchool/{id}")]
        public ApplicationResponse<SchoolDTO> DeleteSchool([FromRoute] int id)
        {
            var response = new ApplicationResponse<SchoolDTO>();
            try
            {
                response.Data = _daoSchool.DeleteSchoolDAO(id);
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
