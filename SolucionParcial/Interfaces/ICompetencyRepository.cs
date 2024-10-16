using SolucionParcial.Data;

namespace SolucionParcial.Interfaces
{
    public interface ICompetencyRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Competency>> GetCompetencies();
        Task<int> Insert(Competency competency);
        Task<bool> Update(Competency competency);
    }
}