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
    public class CursosController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public CursosController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/cursos")]
        public async Task<IEnumerable<CursoResource>> GetCursos()
        {
            var cursos = await context.Curso.Include(m => m.Aulas).ThenInclude(a => a.Materia).Include(m => m.Aulas).ThenInclude(a => a.Disciplina).ToListAsync();
            
            return mapper.Map<List<Curso>, List<CursoResource>>(cursos);
        }
    }
}