using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolucionParcial.Data;
using SolucionParcial.Interfaces;

namespace SolucionParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetencyController : ControllerBase
    {
        private readonly ICompetencyRepository _competencyRepository;

        public CompetencyController(ICompetencyRepository competencyRepository)
        {
            _competencyRepository = competencyRepository;
        }
        [HttpGet()]
        public async Task<IActionResult> GetCompetencies()
        {
            var competencies = await _competencyRepository.GetCompetencies();
            return Ok(competencies);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Competency competency)
        {
            int competencyId = await _competencyRepository.Insert(competency);
            return Ok(competencyId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Competency competency)
        {
            if (id != competency.Id) return BadRequest();
            var result = await _competencyRepository.Update(competency);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _competencyRepository.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }





    }
}
