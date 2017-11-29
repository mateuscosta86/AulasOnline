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
    [Route("/api/materias")]
    public class MateriasController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public MateriasController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MateriaResource>> GetMaterias()
        {
            var materias = await context.Materias.Include(m => m.Aulas).ToListAsync();
            
            return mapper.Map<List<Materia>, List<MateriaResource>>(materias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria(int id) {

            var materia = await context.Materias.Include(c => c.Aulas).SingleOrDefaultAsync(c => c.Id == id);
            if(materia == null)
                return NotFound();

            var result = mapper.Map<Materia, MateriaResource>(materia);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMateria([FromBody] SaveMateriaResource materiaResource) {

            var materia = mapper.Map<SaveMateriaResource, Materia>(materiaResource);
            

            context.Materias.Add(materia);
            await context.SaveChangesAsync();
            
            var result = mapper.Map<Materia, SaveMateriaResource>(materia);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMateria(int id, [FromBody] SaveMateriaResource materiaResource) {

            var materia = await context.Materias.FindAsync(id);
            if(materia == null) {                
                return NotFound();
            }                

            mapper.Map<SaveMateriaResource, Materia>(materiaResource, materia);
                        
            await context.SaveChangesAsync();

            var result = mapper.Map<Materia, MateriaResource>(materia);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id) {

            var materia = await context.Materias.FindAsync(id);
            if(materia == null)
                NotFound();

            context.Remove(materia);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }    
}