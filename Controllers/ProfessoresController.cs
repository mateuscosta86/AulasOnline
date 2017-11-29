using System.Collections.Generic;
using System.Threading.Tasks;
using AulasOnline.Models;
using AulasOnline.Models.Resources;
using AulasOnline.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulasOnline.Controllers
{
    [Route("/api/professores")]
    public class ProfessoresController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public ProfessoresController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfessorResource>> GetProfessores()
        {
            var professores = await context.Professores.Include(m => m.Aulas).ToListAsync();
            
            
            return mapper.Map<List<Professor>, List<ProfessorResource>>(professores);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor(int id) {

            var professor = await context.Professores.Include(c => c.Aulas).SingleOrDefaultAsync(c => c.Id == id);
            if(professor == null)
                return NotFound();

            var result = mapper.Map<Professor, ProfessorResource>(professor);

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProfessor([FromBody] SaveProfessorResource professorResource) {

            var professor = mapper.Map<SaveProfessorResource, Professor>(professorResource);
            

            context.Professores.Add(professor);
            await context.SaveChangesAsync();
            
            var result = mapper.Map<Professor, ProfessorResource>(professor);

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, [FromBody] SaveProfessorResource professorResource) {

            var professor = await context.Professores.FindAsync(id);
            if(professor == null) {
                return NotFound();
            }                

            mapper.Map<SaveProfessorResource, Professor>(professorResource, professor);
                        
            await context.SaveChangesAsync();            

            var result = mapper.Map<Professor, ProfessorResource>(professor);

            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id) {

            var professor = await context.Professores.FindAsync(id);
            if(professor == null)
                NotFound();

            context.Remove(professor);
            await context.SaveChangesAsync();

            return Ok(id);
        }
        
    }
}