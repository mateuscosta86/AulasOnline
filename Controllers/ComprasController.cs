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
    [Route("/api/compras")]
    public class ComprasController : Controller
    {
        private readonly IMapper mapper;
        private readonly AulasOnlineDbContext context;
        public ComprasController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompraResource>> GetCompras()
        {
            var compras = await context.Compras
            .Include(c => c.Curso)
            .Include(c => c.Aluno)
            .ToListAsync();

            return mapper.Map<List<Compra>, List<CompraResource>>(compras);
        }

        [HttpGet("{id}/{idd}")]
        public async Task<IActionResult> GetCompra(int id, int idd)
        {

            var compra = await context.Compras
            .Include(c => c.Curso)
            .Include(c => c.Aluno)
            .SingleOrDefaultAsync(a => a.AlunoId == id && a.CursoId == idd);

            if (compra == null)
                return NotFound();

            var result = mapper.Map<Compra, CompraResource>(compra);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] SaveCompraResource compraResource)
        {

            var compra = mapper.Map<SaveCompraResource, Compra>(compraResource);

            context.Compras.Add(compra);

            await context.SaveChangesAsync();

            compra = await context.Compras
            .Include(c => c.Aluno)
            .Include(c => c.Curso)
            .SingleOrDefaultAsync(a => a.AlunoId == compra.AlunoId && a.CursoId == compra.CursoId);

            var result = mapper.Map<Compra, CompraResource>(compra);

            return Ok(result);
        }

        [HttpDelete("{id}/{idd}")]
        public async Task<IActionResult> DeleteCompra(int id, int idd)
        {
            
            var compra = await context.Compras.FindAsync(id, idd);
            if (compra == null)
                NotFound();

            context.Remove(compra);
            await context.SaveChangesAsync();

            return Ok(id);
        }
    }
}