
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
    public class AulasController : Controller
    {
        private readonly AulasOnlineDbContext context;
        private readonly IMapper mapper;
        public AulasController(AulasOnlineDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/aulas")]
        public async Task<IEnumerable<AulaResource>> GetAulas()
        {
            var aulas = await context.Aulas.Include(m => m.Materia).ToListAsync();
            
            return mapper.Map<List<Aula>, List<AulaResource>>(aulas);
        }
    }
}