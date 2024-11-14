using Microsoft.AspNetCore.Mvc;

namespace ProjetoFundacaoCrianca.Controllers
{
    public class DadosController : Controller
    {
        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;
        }
    }

    public IActionResult Aluno()
    {
        contexto.Database.ExecuteSqlRaw("delete from alunos");
        contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('alunoss', RESEED, 0)");

        Random randNum = new Random();

        string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
        string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
        string[] vEmail = { "julia.alves654@gmail.com", "beatriz.santos487@gmail.com", "larissa.martins495@gmail.com", "carla.pereira392@gmail.com", "gabriel.pereira857@gmail.com", "beatriz.rodrigues757@gmail.com", "joao.silva912@gmail.com", "gabriel.melo741@gmail.com", "rafael.melo289@gmail.com", "bruno.cardoso262@gmail.com", "pedro.ferreira596@gmail.com", "leticia.dias722@gmail.com", "thais.cardoso831@gmail.com", "gabriel.cardoso907@gmail.com", "maria.silva562@gmail.com", "thais.dias541@gmail.com", "gabriel.gomes311@gmail.com", "beatriz.oliveira531@gmail.com", "amanda.alves264@gmail.com", "ana.pereira522@gmail.com", "matheus.batista31@gmail.com", "larissa.batista22@gmail.com", "gabriel.pereira509@gmail.com", "bruno.rodrigues387@gmail.com", "beatriz.rodrigues142@gmail.com", "gustavo.dias407@gmail.com", "carla.costa879@gmail.com", "ana.batista395@gmail.com", "ana.souza51@gmail.com", "beatriz.dias324@gmail.com", "thais.melo912@gmail.com", "joao.pereira808@gmail.com", "gabriel.batista700@gmail.com", "beatriz.souza911@gmail.com", "joao.gomes995@gmail.com", "gustavo.dias366@gmail.com", "joao.melo141@gmail.com", "ana.dias130@gmail.com", "andre.pereira108@gmail.com", "bruno.rodrigues558@gmail.com", "thais.melo48@gmail.com", "pedro.alves47@gmail.com", "larissa.alves172@gmail.com", "maria.silva126@gmail.com", "bruno.barbosa18@gmail.com", "leticia.santos21@gmail.com", "bruno.ribeiro791@gmail.com", "laura.machado589@gmail.com", "matheus.rodrigues292@gmail.com", "maria.lima667@gmail.com", "fernando.pereira956@gmail.com", "julia.melo115@gmail.com", "larissa.silva909@gmail.com", "leticia.lima205@gmail.com", "carla.rodrigues890@gmail.com", "lucas.gomes234@gmail.com", "joao.pereira21@gmail.com", "rafael.santos401@gmail.com", "fernando.lima605@gmail.com", "maria.costa303@gmail.com", "rafael.ribeiro791@gmail.com", "gustavo.moraes588@gmail.com", "fernando.ribeiro397@gmail.com", "larissa.melo778@gmail.com", "amanda.ribeiro192@gmail.com", "joao.pereira958@gmail.com", "bruno.rodrigues765@gmail.com", "julia.silva146@gmail.com", "laura.gomes490@gmail.com", "rafael.martins721@gmail.com", "carla.barbosa560@gmail.com", "bruno.batista957@gmail.com", "maria.pereira865@gmail.com", "matheus.barbosa478@gmail.com", "maria.ribeiro775@gmail.com", "bruno.pereira753@gmail.com", "gabriel.rodrigues338@gmail.com", "bruno.ribeiro609@gmail.com", "fernando.rodrigues622@gmail.com", "fernando.martins604@gmail.com", "leticia.souza806@gmail.com", "amanda.oliveira601@gmail.com", "thais.lima211@gmail.com", "julia.alves356@gmail.com", "larissa.rodrigues883@gmail.com", "pedro.oliveira688@gmail.com", "bruno.ribeiro448@gmail.com", "matheus.rodrigues458@gmail.com", "maria.alves618@gmail.com", "lucas.pereira108@gmail.com", "carla.dias171@gmail.com", "ana.martins168@gmail.com", "laura.alves118@gmail.com", "rafael.melo219@gmail.com", "matheus.dias709@gmail.com", "thais.silva823@gmail.com", "pedro.gomes951@gmail.com", "leticia.oliveira170@gmail.com", "bruno.moraes801@gmail.com", "gabriel.moraes591@gmail.com" }
}

        for (int i = 0; i < 100; i++)
        {
            Aluno aluno = new Aluno();

            aluno.dadofamiliaID = randNum.Next(1,100);
            aluno.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
            aluno.cpf = randNum.Next(11111111111, 99999999999);
            aluno.genero = (genero)randNum.Next(2);
            aluno.escolaridade = (escolaridade)randNum.Next(2);
            int ano = randNum.Next(2005, 2024 + 1);
            int mes = randNum.Next(1, 13);
            int dia = randNum.Next(1, 31);
            aluno.DatadeNascimento = (dia, mes, ano);
            aluno.email = vEmail[i];
        }
        contexto.SaveChanges();

        return View(contexto.alunos.OrderBy(o => o.nome).ToList());
    }
}
}