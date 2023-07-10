using Microsoft.AspNetCore.Mvc;
using PracticaWebServices.BussinesLogic.DAO.DAOPerson;
using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.BussinesLogic.Mapper.PersonMapper;
using PracticaWebServices.Exceptions;
using PracticaWebServices.Response;

namespace PracticaWebServices.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonDAO _daoPerson;

        public PersonController(IPersonDAO dao)
        {
            _daoPerson = dao;
        }
        [HttpPost]
        [Route("AddPerson/")]
        public ApplicationResponse<PersonDTO> AddPerson([FromBody] PersonDTO dto1)
        {
            var response = new ApplicationResponse<PersonDTO>();
            try
            {
                response.Data = _daoPerson.AddPersonDAO(MapperPerson.DtoToEntity(dto1));
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
        [Route("UpdatePerson/{id}")]
        public ApplicationResponse<PersonDTO> UpdatePerson([FromBody] PersonDTO dto1, [FromRoute] int id)
        {
            var response = new ApplicationResponse<PersonDTO>();
            try
            {
                response.Data = _daoPerson.UpdatePersonDAO(MapperPerson.DtoToEntity_Update(dto1), id);
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
        [Route("ListPerson/")]
        public ApplicationResponse<List<ShowPersonDTO>> ListPerson()
        {
            var response = new ApplicationResponse<List<ShowPersonDTO>>();
            try
            {
                response.Data = _daoPerson.ListPersonDAO();
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
        [Route("DeletePerson/{id}")]
        public ApplicationResponse<PersonDTO> DeletePerson([FromRoute] int id)
        {
            var response = new ApplicationResponse<PersonDTO>();
            try
            {
                response.Data = _daoPerson.DeletePersonDAO(id);
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
        [Route("ListStudent/{id_section}")]
        public ApplicationResponse<List<ShowPersonDTO>> ListStudent([FromRoute] int id_section)
        {
            var response = new ApplicationResponse<List<ShowPersonDTO>>();
            try
            {
                response.Data = _daoPerson.ListStudentsDAO(id_section);
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
        [Route("ListTeacher/{id_section}")]
        public ApplicationResponse<List<ShowPersonDTO>> ListTeacher([FromRoute] int id_section)
        {
            var response = new ApplicationResponse<List<ShowPersonDTO>>();
            try
            {
                response.Data = _daoPerson.ListTeacherDAO(id_section);
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
