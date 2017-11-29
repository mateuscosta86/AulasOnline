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
    [Route("/api/cursos")]
    public class CursosController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public CursosController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CursoResource>> GetCursos()
        {
            var cursos = await context.Cursos
            .Include(m => m.Aulas)
            .ThenInclude(a => a.Materia)
            .Include(m => m.Aulas)
            .ThenInclude(a => a.Disciplina)
            .Include(m => m.Aulas)
            .ThenInclude(a => a.Professor)
            .ToListAsync();
            
            return mapper.Map<List<Curso>, List<CursoResource>>(cursos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurso([FromBody] SaveCursoResource cursoResource) {

            var curso = mapper.Map<SaveCursoResource, Curso>(cursoResource);
            
            curso.DataCriacao = DateTime.Now;

            context.Cursos.Add(curso);
            await context.SaveChangesAsync();

            var result = mapper.Map<Curso, CursoResource>(curso);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, [FromBody] SaveCursoResource cursoResource) {

            var curso = await context.Cursos
            .Include(c => c.Aulas)
            .FirstOrDefaultAsync(c => c.Id == cursoResource.Id);

            if(curso == null)
                NotFound();

            mapper.Map<SaveCursoResource, Curso>(cursoResource, curso);
                        
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
    }
}