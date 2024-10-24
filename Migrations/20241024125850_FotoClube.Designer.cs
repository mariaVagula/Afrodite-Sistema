﻿// <auto-generated />
using System;
using Afrodite_Sistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Afrodite_Sistema.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241024125850_FotoClube")]
    partial class FotoClube
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Afrodite_Sistema.Models.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgendamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraAgendamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataHoraAgendamento");

                    b.Property<string>("ObservacaoAgendamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObservacaoAgendamento");

                    b.Property<int>("ProcedimentoId")
                        .HasColumnType("int");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("int");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProcedimentoId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.AssinaturaClube", b =>
                {
                    b.Property<int>("AssinaturaClubeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AssinaturaClubeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssinaturaClubeId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ClubeId")
                        .HasColumnType("int");

                    b.HasKey("AssinaturaClubeId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ClubeId");

                    b.ToTable("AssinaturaClube");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<int>("CpfCliente")
                        .HasColumnType("int")
                        .HasColumnName("CpfCliente");

                    b.Property<DateTime>("DataNascimentoCliente")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimentoCliente");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailCliente");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeCliente");

                    b.Property<string>("SenhaCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SenhaCliente");

                    b.Property<string>("SexoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SexoCliente");

                    b.Property<int>("TelCliente")
                        .HasColumnType("int")
                        .HasColumnName("TelCliente");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Clube", b =>
                {
                    b.Property<int>("ClubeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClubeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubeId"));

                    b.Property<string>("DetalhesClube")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DetalhesClube");

                    b.Property<string>("FotoClube")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FotoClube");

                    b.Property<string>("NomeClube")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeClube");

                    b.Property<int>("TipoClubeId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPlanoId")
                        .HasColumnType("int");

                    b.Property<int>("ValorClube")
                        .HasColumnType("int")
                        .HasColumnName("ValorClube");

                    b.HasKey("ClubeId");

                    b.HasIndex("TipoClubeId");

                    b.HasIndex("TipoPlanoId");

                    b.ToTable("Clube");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.FormaPagamento", b =>
                {
                    b.Property<int>("FormaPagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FormaPagamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormaPagamentoId"));

                    b.Property<string>("NomeFormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeFormaPagamento");

                    b.HasKey("FormaPagamentoId");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.PagamentoAgendamento", b =>
                {
                    b.Property<int>("PagamentoAgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PagamentoAgendamentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoAgendamentoId"));

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("int");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("int");

                    b.HasKey("PagamentoAgendamentoId");

                    b.HasIndex("AgendamentoId");

                    b.HasIndex("FormaPagamentoId");

                    b.ToTable("PagamentoAgendamento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.PagamentoAssinatura", b =>
                {
                    b.Property<int>("PagamentoAssinaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PagamentoAssinaturaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagamentoAssinaturaId"));

                    b.Property<int>("AssinaturaClubeId")
                        .HasColumnType("int");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("int");

                    b.HasKey("PagamentoAssinaturaId");

                    b.HasIndex("AssinaturaClubeId");

                    b.HasIndex("FormaPagamentoId");

                    b.ToTable("PagamentoAssinatura");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Procedimento", b =>
                {
                    b.Property<int>("ProcedimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProcedimentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcedimentoId"));

                    b.Property<string>("NomeProcedimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeProcedimento");

                    b.Property<int>("ValorProcedimento")
                        .HasColumnType("int")
                        .HasColumnName("ValorProcedimento");

                    b.HasKey("ProcedimentoId");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Profissional", b =>
                {
                    b.Property<int>("ProfissionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfissionalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfissionalId"));

                    b.Property<string>("FotoProfissional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FotoProfissional");

                    b.Property<string>("NomeProfissional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeProfissional");

                    b.Property<int>("TipoProfissionalId")
                        .HasColumnType("int");

                    b.HasKey("ProfissionalId");

                    b.HasIndex("TipoProfissionalId");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.TipoClube", b =>
                {
                    b.Property<int>("TipoClubeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoClubeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoClubeId"));

                    b.Property<string>("NomeTipoClube")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoClube");

                    b.HasKey("TipoClubeId");

                    b.ToTable("TipoClube");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.TipoPlano", b =>
                {
                    b.Property<int>("TipoPlanoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoPlanoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoPlanoId"));

                    b.Property<string>("NomeTipoPlano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoPlano");

                    b.HasKey("TipoPlanoId");

                    b.ToTable("TipoPlano");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.TipoProcedimento", b =>
                {
                    b.Property<int>("TipoProcedimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoProcedimentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoProcedimentoId"));

                    b.Property<string>("NomeTipoProcedimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoProcedimento");

                    b.HasKey("TipoProcedimentoId");

                    b.ToTable("TipoProcedimento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.TipoProfissional", b =>
                {
                    b.Property<int>("TipoProfissionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoProfissionalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoProfissionalId"));

                    b.Property<string>("NomeTipoProfissional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoProfissional");

                    b.HasKey("TipoProfissionalId");

                    b.ToTable("TipoProfissional");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Agendamento", b =>
                {
                    b.HasOne("Afrodite_Sistema.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afrodite_Sistema.Models.Procedimento", "Procedimento")
                        .WithMany()
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afrodite_Sistema.Models.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Procedimento");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.AssinaturaClube", b =>
                {
                    b.HasOne("Afrodite_Sistema.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afrodite_Sistema.Models.Clube", "Clube")
                        .WithMany()
                        .HasForeignKey("ClubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Clube");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Clube", b =>
                {
                    b.HasOne("Afrodite_Sistema.Models.TipoClube", "TipoClube")
                        .WithMany()
                        .HasForeignKey("TipoClubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afrodite_Sistema.Models.TipoPlano", "TipoPlano")
                        .WithMany()
                        .HasForeignKey("TipoPlanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoClube");

                    b.Navigation("TipoPlano");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.PagamentoAgendamento", b =>
                {
                    b.HasOne("Afrodite_Sistema.Models.Agendamento", "Agendamento")
                        .WithMany()
                        .HasForeignKey("AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afrodite_Sistema.Models.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");

                    b.Navigation("FormaPagamento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.PagamentoAssinatura", b =>
                {
                    b.HasOne("Afrodite_Sistema.Models.AssinaturaClube", "AssinaturaClube")
                        .WithMany()
                        .HasForeignKey("AssinaturaClubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Afrodite_Sistema.Models.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssinaturaClube");

                    b.Navigation("FormaPagamento");
                });

            modelBuilder.Entity("Afrodite_Sistema.Models.Profissional", b =>
                {
                    b.HasOne("Afrodite_Sistema.Models.TipoProfissional", "TipoProfissional")
                        .WithMany()
                        .HasForeignKey("TipoProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProfissional");
                });
#pragma warning restore 612, 618
        }
    }
}
