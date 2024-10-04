using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Afrodite_Sistema.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimentoCliente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SexoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCliente = table.Column<int>(type: "int", nullable: false),
                    TelCliente = table.Column<int>(type: "int", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.FormaPagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                columns: table => new
                {
                    ProcedimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProcedimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorProcedimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimento", x => x.ProcedimentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoClube",
                columns: table => new
                {
                    TipoClubeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoClube = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClube", x => x.TipoClubeId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlano",
                columns: table => new
                {
                    TipoPlanoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoPlano = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlano", x => x.TipoPlanoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProcedimento",
                columns: table => new
                {
                    TipoProcedimentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoProcedimento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProcedimento", x => x.TipoProcedimentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProfissional",
                columns: table => new
                {
                    TipoProfissionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProfissional", x => x.TipoProfissionalId);
                });

            migrationBuilder.CreateTable(
                name: "Clube",
                columns: table => new
                {
                    ClubeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeClube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoClubeId = table.Column<int>(type: "int", nullable: false),
                    TipoPlanoId = table.Column<int>(type: "int", nullable: false),
                    DetalhesClube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorClube = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clube", x => x.ClubeId);
                    table.ForeignKey(
                        name: "FK_Clube_TipoClube_TipoClubeId",
                        column: x => x.TipoClubeId,
                        principalTable: "TipoClube",
                        principalColumn: "TipoClubeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clube_TipoPlano_TipoPlanoId",
                        column: x => x.TipoPlanoId,
                        principalTable: "TipoPlano",
                        principalColumn: "TipoPlanoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProfissionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.ProfissionalId);
                    table.ForeignKey(
                        name: "FK_Profissional_TipoProfissional_TipoProfissionalId",
                        column: x => x.TipoProfissionalId,
                        principalTable: "TipoProfissional",
                        principalColumn: "TipoProfissionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssinaturaClube",
                columns: table => new
                {
                    AssinaturaClubeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClubeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssinaturaClube", x => x.AssinaturaClubeId);
                    table.ForeignKey(
                        name: "FK_AssinaturaClube_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssinaturaClube_Clube_ClubeId",
                        column: x => x.ClubeId,
                        principalTable: "Clube",
                        principalColumn: "ClubeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedimentoId = table.Column<int>(type: "int", nullable: false),
                    DataHoraAgendamentoId = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    ObservacaoAgendamentoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Procedimento_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimento",
                        principalColumn: "ProcedimentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissional",
                        principalColumn: "ProfissionalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoAssinatura",
                columns: table => new
                {
                    PagamentoAssinaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssinaturaClubeId = table.Column<int>(type: "int", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoAssinatura", x => x.PagamentoAssinaturaId);
                    table.ForeignKey(
                        name: "FK_PagamentoAssinatura_AssinaturaClube_AssinaturaClubeId",
                        column: x => x.AssinaturaClubeId,
                        principalTable: "AssinaturaClube",
                        principalColumn: "AssinaturaClubeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoAssinatura_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "FormaPagamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagamentoAgendamento",
                columns: table => new
                {
                    PagamentoAgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgendamentoId = table.Column<int>(type: "int", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoAgendamento", x => x.PagamentoAgendamentoId);
                    table.ForeignKey(
                        name: "FK_PagamentoAgendamento_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "AgendamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoAgendamento_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "FormaPagamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClienteId",
                table: "Agendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ProcedimentoId",
                table: "Agendamento",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_AssinaturaClube_ClienteId",
                table: "AssinaturaClube",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AssinaturaClube_ClubeId",
                table: "AssinaturaClube",
                column: "ClubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clube_TipoClubeId",
                table: "Clube",
                column: "TipoClubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clube_TipoPlanoId",
                table: "Clube",
                column: "TipoPlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAgendamento_AgendamentoId",
                table: "PagamentoAgendamento",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAgendamento_FormaPagamentoId",
                table: "PagamentoAgendamento",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAssinatura_AssinaturaClubeId",
                table: "PagamentoAssinatura",
                column: "AssinaturaClubeId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAssinatura_FormaPagamentoId",
                table: "PagamentoAssinatura",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissional_TipoProfissionalId",
                table: "Profissional",
                column: "TipoProfissionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoAgendamento");

            migrationBuilder.DropTable(
                name: "PagamentoAssinatura");

            migrationBuilder.DropTable(
                name: "TipoProcedimento");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "AssinaturaClube");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Procedimento");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Clube");

            migrationBuilder.DropTable(
                name: "TipoProfissional");

            migrationBuilder.DropTable(
                name: "TipoClube");

            migrationBuilder.DropTable(
                name: "TipoPlano");
        }
    }
}
