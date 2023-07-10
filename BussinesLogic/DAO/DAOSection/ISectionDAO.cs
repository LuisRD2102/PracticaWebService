using PracticaWebServices.BussinesLogic.DTO;
using PracticaWebServices.Entities;

namespace PracticaWebServices.BussinesLogic.DAO.DAOSection
{
    public interface ISectionDAO
    {
        public SectionDTO AddSectionDAO(Section section);
        public SectionDTO UpdateSectionDAO(Section section, int id);
        public List<ShowSectionDTO> ListSectionDAO();
        public SectionDTO DeleteSectionDAO(int id);
    }
}
