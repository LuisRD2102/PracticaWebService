using Microsoft.AspNetCore.Mvc;
using PracticaWebServices.BussinesLogic.DAO.DAOSection;
using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.SectionMapper;
using PracticaWebServices.Exceptions;
using PracticaWebServices.Response;

namespace PracticaWebServices.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionDAO _daoSection;

        public SectionController(ISectionDAO dao)
        {
            _daoSection = dao;
        }
        [HttpPost]
        [Route("AddSection/")]
        public ApplicationResponse<SectionDTO> AddSection([FromBody] SectionDTO dto1)
        {
            var response = new ApplicationResponse<SectionDTO>();
            try
            {
                response.Data = _daoSection.AddSectionDAO(MapperPerson.DtoToEntity(dto1));
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
        [Route("UpdateSection/{id}")]
        public ApplicationResponse<SectionDTO> UpdateSection([FromBody] SectionDTO dto1, [FromRoute] int id)
        {
            var response = new ApplicationResponse<SectionDTO>();
            try
            {
                response.Data = _daoSection.UpdateSectionDAO(MapperPerson.DtoToEntity_Update(dto1), id);
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
        [Route("ListSection/")]
        public ApplicationResponse<List<ShowSectionDTO>> ConsultarDepartamento()
        {
            var response = new ApplicationResponse<List<ShowSectionDTO>>();
            try
            {
                response.Data = _daoSection.ListSectionDAO();
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
        [Route("DeleteSection/{id}")]
        public ApplicationResponse<SectionDTO> DeleteSection([FromRoute] int id)
        {
            var response = new ApplicationResponse<SectionDTO>();
            try
            {
                response.Data = _daoSection.DeleteSectionDAO(id);
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
