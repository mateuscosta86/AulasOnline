
using System;
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
    [Route("/api/aulas")]
    public class AulasController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public AulasController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AulaResource>> GetAulas()
        {
            var aulas = await context.Aulas
            .Include(a => a.Curso)
            .Include(a => a.Disciplina)
            .Include(a => a.Materia)
            .Include(a => a.Professor)
            .ToListAsync();
            
            return mapper.Map<List<Aula>, List<AulaResource>>(aulas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAula(int id) {

            var aula = await context.Aulas
            .Include(a => a.Curso)
            .Include(a => a.Disciplina)
            .Include(a => a.Materia)
            .Include(a => a.Professor)
            .SingleOrDefaultAsync(a => a.Id == id);

            if(aula == null)
                return NotFound();

            var result = mapper.Map<Aula, AulaResource>(aula);

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAula([FromBody] SaveAulaResource aulaResource) {

            var aula = mapper.Map<SaveAulaResource, Aula>(aulaResource);
            
            context.Aulas.Add(aula);
            await context.SaveChangesAsync();

            aula = await context.Aulas
            .Include(a => a.Curso)
            .Include(a => a.Disciplina)
            .Include(a => a.Materia)
            .Include(a => a.Professor)
            .SingleOrDefaultAsync(a => a.Id == aula.Id);
            
            var result = mapper.Map<Aula, AulaResource>(aula);

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAula(int id, [FromBody] SaveAulaResource aulaResource) {

            var aula = await context.Aulas.FindAsync(id);
            if(aula == null) {
                return NotFound();
            }                

            mapper.Map<SaveAulaResource, Aula>(aulaResource, aula);
                        
            await context.SaveChangesAsync();  

            aula = await context.Aulas
            .Include(a => a.Curso)
            .Include(a => a.Disciplina)
            .Include(a => a.Professor)
            .Include(a => a.Materia)
            .FirstOrDefaultAsync(a => a.Id == aula.Id);          

            var result = mapper.Map<Aula, AulaResource>(aula);

            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAula(int id) {

            var aula = await context.Aulas.FindAsync(id);
            if(aula == null)
                NotFound();

            context.Remove(aula);
            await context.SaveChangesAsync();

            return Ok(id);
        }

    }
}