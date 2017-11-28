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

        [HttpPost]
        public async Task<IActionResult> CreateCurso([FromBody] SaveMateriaResource materiaResource) {

            var materia = mapper.Map<SaveMateriaResource, Materia>(materiaResource);
            

            context.Materias.Add(materia);
            await context.SaveChangesAsync();
            
            var result = mapper.Map<Materia, SaveMateriaResource>(materia);

            return Ok(result);
        }
/*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, [FromBody] CursoResource cursoResource) {

            var curso = await context.Cursos.FindAsync(id);
            if(curso == null)
                NotFound();

            mapper.Map<CursoResource, Curso>(cursoResource, curso);
                        
            await context.SaveChangesAsync();

            var result = mapper.Map<Curso, CursoResource>(curso);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id) {

            var curso = await context.Cursos.FindAsync(id);
            if(curso == null)
                NotFound();

            context.Remove(curso);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurso(int id) {

            var curso = await context.Cursos.Include(c => c.Aulas).SingleOrDefaultAsync(c => c.Id == id);
            if(curso == null)
                NotFound();

            var result = mapper.Map<Curso, CursoResource>(curso);

            return Ok(result);
        }
        */
    }    
}