using Microsoft.EntityFrameworkCore;
using SolucionParcial.Data;
using SolucionParcial.Interfaces;

namespace SolucionParcial.Repositories
{
    public class CompetencyRepository : ICompetencyRepository
    {
        private readonly Parcial20240221200022Context _dbContext;
        public CompetencyRepository(Parcial20240221200022Context dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Competency>> GetCompetencies()
        {
            var competencies = await _dbContext.Competency.ToListAsync();
            return competencies;
        }

        //Create category
        public async Task<int> Insert(Competency competency)
        {
            await _dbContext.Competency.AddAsync(competency);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0 ? competency.Id : -1;
        }

        //Update category
        public async Task<bool> Update(Competency competency)
        {
            _dbContext.Competency.Update(competency);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete category
        public async Task<bool> Delete(int id)
        {
            var competency = await _dbContext
                            .Competency
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (competency == null) return false;

            int rows = await _dbContext
                    .Competency
                    .Where(c => c.Id == id).ExecuteDeleteAsync();
            return (rows > 0);
            //_dbContext.Category.Remove(category);

        }

    }
}
