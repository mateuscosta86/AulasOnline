using AulasOnline.Models;
using AulasOnline.Models.Resources;
using AutoMapper;

namespace AulasOnline.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoResource>();
            CreateMap<Aula, AulaResource>();
            CreateMap<Materia, MateriaResource>();
            CreateMap<Disciplina, DisciplinaResource>();
        }
    }
}