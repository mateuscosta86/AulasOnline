using System.Linq;
using AulasOnline.Models;
using AulasOnline.Models.Resources;
using AutoMapper;

namespace AulasOnline.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Domain to API Resource
            CreateMap<Curso, CursoResource>();
            CreateMap<Aula, AulaResource>();
            CreateMap<Materia, MateriaResource>();
            CreateMap<Disciplina, DisciplinaResource>();

            // API Resource to Domain
            CreateMap<CursoResource, Curso>()
            .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}