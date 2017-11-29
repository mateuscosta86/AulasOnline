using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AulasOnline.Models;
using AulasOnline.Models.Resources;
using AulasOnline.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulasOnline.Controllers
{
    [Route("/api/alunos")]
    public class AlunosController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public AlunosController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoResource>> GetAlunos()
        {
            var alunos = await context.Alunos
            .Include(a => a.Compras).ThenInclude(a => a.Aluno)
            .Include(a => a.Compras).ThenInclude(c => c.Curso)
            .ToListAsync();

            foreach(var aluno in alunos) {
                foreach (var compra in aluno.Compras)
                    Console.WriteLine(compra.Aluno);
            }
            
            return mapper.Map<List<Aluno>, List<AlunoResource>>(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAluno(int id) {

            var aluno = await context.Alunos
            .Include(a => a.Compras).ThenInclude(a => a.Aluno)
            .Include(a => a.Compras).ThenInclude(c => c.Curso)
            .SingleOrDefaultAsync(a => a.Id == id);

            if(aluno == null)
                return NotFound();

            var result = mapper.Map<Aluno, AlunoResource>(aluno);

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAluno([FromBody] SaveAlunoResource alunoResource) {

            var aluno = mapper.Map<SaveAlunoResource, Aluno>(alunoResource);
            
            context.Alunos.Add(aluno);
            await context.SaveChangesAsync();

            aluno = await context.Alunos
            .Include(a => a.Compras)
            .SingleOrDefaultAsync(a => a.Id == aluno.Id);
            
            var result = mapper.Map<Aluno, AlunoResource>(aluno);

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody] SaveAlunoResource alunoResource) {

            var aluno = await context.Alunos.FindAsync(id);
            if(aluno == null) {
                return NotFound();
            }                

            mapper.Map<SaveAlunoResource, Aluno>(alunoResource, aluno);
                        
            await context.SaveChangesAsync();  

            aluno = await context.Alunos
            .Include(a => a.Compras)
            .FirstOrDefaultAsync(a => a.Id == aluno.Id);          

            var result = mapper.Map<Aluno, AlunoResource>(aluno);

            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id) {

            var aluno = await context.Alunos.FindAsync(id);
            if(aluno == null)
                NotFound();

            context.Remove(aluno);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}