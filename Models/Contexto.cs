using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ProjetoFundacaoCrianca.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AssistenteSocial> AssistentesSociais { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Chamada> Chamadas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<DadoFamilia> DadosFamilias { get; set; }
        public DbSet<Encaminhamento> Encaminhamentos { get; set; }
        public DbSet<Entidade> Entidades { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<PerfilSocioEconomico> PerfisSociosEconomicos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }



    }
}
