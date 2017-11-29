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
    [Route("/api/disciplinas")]
    public class DisciplinasController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public DisciplinasController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<DisciplinaResource>> GetDisciplinas()
        {
            var disciplinas = await context.Disciplinas.Include(m => m.Aulas).ToListAsync();
            
            
            return mapper.Map<List<Disciplina>, List<DisciplinaResource>>(disciplinas);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisciplina(int id) {

            var disciplina = await context.Disciplinas.Include(c => c.Aulas).SingleOrDefaultAsync(c => c.Id == id);
            if(disciplina == null)
                return NotFound();

            var result = mapper.Map<Disciplina, DisciplinaResource>(disciplina);

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateDisciplina([FromBody] SaveDisciplinaResource disciplinaResource) {

            var disciplina = mapper.Map<SaveDisciplinaResource, Disciplina>(disciplinaResource);
            

            context.Disciplinas.Add(disciplina);
            await context.SaveChangesAsync();
            
            var result = mapper.Map<Disciplina, DisciplinaResource>(disciplina);

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisciplina(int id, [FromBody] SaveDisciplinaResource disciplinaResource) {

            var disciplina = await context.Disciplinas.FindAsync(id);
            if(disciplina == null) {
                return NotFound();
            }                

            mapper.Map<SaveDisciplinaResource, Disciplina>(disciplinaResource, disciplina);
                        
            await context.SaveChangesAsync();            

            var result = mapper.Map<Disciplina, DisciplinaResource>(disciplina);

            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplina(int id) {

            var disciplina = await context.Disciplinas.FindAsync(id);
            if(disciplina == null)
                NotFound();

            context.Remove(disciplina);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    
    }
}