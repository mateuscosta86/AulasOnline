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
            CreateMap<Aula, AulaResource>();
            CreateMap<Aluno, AlunoResource>()
            .ForMember(ar => ar.Compras, opt => opt.MapFrom( a => a.Compras.Select( c => new CursoResource { Id = c.Curso.Id, Nome = c.Curso.Nome, Preco = c.Curso.Preco, DataCriacao = c.Curso.DataCriacao} )));

            CreateMap<Curso, CursoResource>();            
            CreateMap<Materia, MateriaResource>();
            CreateMap<Disciplina, DisciplinaResource>();            
            CreateMap<Professor, ProfessorResource>();

            // API Resource to Domain
            CreateMap<CursoResource, Curso>();
            CreateMap<SaveCursoResource, Curso>()
            .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<DisciplinaResource, Disciplina>();
            CreateMap<SaveDisciplinaResource, Disciplina>()
            .ForMember(d => d.Id, opt => opt.Ignore());            

            CreateMap<MateriaResource, Materia>();          
            CreateMap<SaveMateriaResource, Materia>()
            .ForMember(m => m.Id, opt => opt.Ignore());       

        }
    }
}