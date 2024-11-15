using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFundacaoCrianca.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssistentesSociais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistentesSociais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    DataAtividade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duracaoAtividade = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    periodo = table.Column<int>(type: "int", nullable: false),
                    CargaHoraria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DadosFamilias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeMae = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    DatadeNascimentoMae = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefoneMae = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    nomePai = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    DatadeNascimentoPai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefonePai = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    HistoricoFamiliar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosFamilias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEntidade = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    statusContrato = table.Column<int>(type: "int", nullable: false),
                    DatadeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatadoFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    especializacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cursoID = table.Column<int>(type: "int", nullable: false),
                    nomeTurma = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    serie = table.Column<int>(type: "int", nullable: false),
                    maximoAluno = table.Column<int>(type: "int", nullable: false),
                    minimoAluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_cursoID",
                        column: x => x.cursoID,
                        principalTable: "Cursos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dadofamiliaID = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    escolaridade = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    DatadeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alunos_DadosFamilias_dadofamiliaID",
                        column: x => x.dadofamiliaID,
                        principalTable: "DadosFamilias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assistenteSocialID = table.Column<int>(type: "int", nullable: false),
                    dadofamiliaID = table.Column<int>(type: "int", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_AssistentesSociais_assistenteSocialID",
                        column: x => x.assistenteSocialID,
                        principalTable: "AssistentesSociais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_DadosFamilias_dadofamiliaID",
                        column: x => x.dadofamiliaID,
                        principalTable: "DadosFamilias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfisSociosEconomicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dadofamiliaID = table.Column<int>(type: "int", nullable: false),
                    rendafamilia = table.Column<float>(type: "real", nullable: false),
                    situacaofamilia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    profissaoPai = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    profissaoMae = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfisSociosEconomicos", x => x.id);
                    table.ForeignKey(
                        name: "FK_PerfisSociosEconomicos_DadosFamilias_dadofamiliaID",
                        column: x => x.dadofamiliaID,
                        principalTable: "DadosFamilias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assistenteSocialID = table.Column<int>(type: "int", nullable: false),
                    dadofamiliaID = table.Column<int>(type: "int", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Visitas_AssistentesSociais_assistenteSocialID",
                        column: x => x.assistenteSocialID,
                        principalTable: "AssistentesSociais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_DadosFamilias_dadofamiliaID",
                        column: x => x.dadofamiliaID,
                        principalTable: "DadosFamilias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encaminhamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entidadeID = table.Column<int>(type: "int", nullable: false),
                    assistentesocialID = table.Column<int>(type: "int", nullable: false),
                    alunoID = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatadeEncaminhamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encaminhamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Encaminhamentos_Alunos_alunoID",
                        column: x => x.alunoID,
                        principalTable: "Alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encaminhamentos_AssistentesSociais_assistentesocialID",
                        column: x => x.assistentesocialID,
                        principalTable: "AssistentesSociais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encaminhamentos_Entidades_entidadeID",
                        column: x => x.entidadeID,
                        principalTable: "Entidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turmaID = table.Column<int>(type: "int", nullable: false),
                    alunoID = table.Column<int>(type: "int", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_alunoID",
                        column: x => x.alunoID,
                        principalTable: "Alunos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Turmas_turmaID",
                        column: x => x.turmaID,
                        principalTable: "Turmas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chamadas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matriculaID = table.Column<int>(type: "int", nullable: false),
                    DatadeChamada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Presenca = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamadas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chamadas_Matriculas_matriculaID",
                        column: x => x.matriculaID,
                        principalTable: "Matriculas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_dadofamiliaID",
                table: "Alunos",
                column: "dadofamiliaID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_assistenteSocialID",
                table: "Atendimentos",
                column: "assistenteSocialID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_dadofamiliaID",
                table: "Atendimentos",
                column: "dadofamiliaID");

            migrationBuilder.CreateIndex(
                name: "IX_Chamadas_matriculaID",
                table: "Chamadas",
                column: "matriculaID");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamentos_alunoID",
                table: "Encaminhamentos",
                column: "alunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamentos_assistentesocialID",
                table: "Encaminhamentos",
                column: "assistentesocialID");

            migrationBuilder.CreateIndex(
                name: "IX_Encaminhamentos_entidadeID",
                table: "Encaminhamentos",
                column: "entidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_alunoID",
                table: "Matriculas",
                column: "alunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_turmaID",
                table: "Matriculas",
                column: "turmaID");

            migrationBuilder.CreateIndex(
                name: "IX_PerfisSociosEconomicos_dadofamiliaID",
                table: "PerfisSociosEconomicos",
                column: "dadofamiliaID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_cursoID",
                table: "Turmas",
                column: "cursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_assistenteSocialID",
                table: "Visitas",
                column: "assistenteSocialID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_dadofamiliaID",
                table: "Visitas",
                column: "dadofamiliaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Chamadas");

            migrationBuilder.DropTable(
                name: "Encaminhamentos");

            migrationBuilder.DropTable(
                name: "PerfisSociosEconomicos");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "AssistentesSociais");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "DadosFamilias");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
