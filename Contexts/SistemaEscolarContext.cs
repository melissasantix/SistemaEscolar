using System;
using System.Collections.Generic;
using SistemaEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaEscolar.Contexts;

public partial class SistemaEscolarContext : DbContext
{
    public SistemaEscolarContext()
    {
    }

    public SistemaEscolarContext(DbContextOptions<SistemaEscolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Nota> Nota { get; set; }

    public virtual DbSet<Presenca> Presencas { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sistema_escolar;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.IdAluno).HasName("PK__aluno__0C5BC849DB46E36D");

            entity.ToTable("aluno");

            entity.Property(e => e.IdAluno).HasColumnName("idAluno");
            entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
            entity.Property(e => e.IdTurma).HasColumnName("idTurma");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.Alunos)
                .HasForeignKey(d => d.IdTurma)
                .HasConstraintName("FK__aluno__idTurma__6A30C649");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Alunos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__aluno__idUsuario__6B24EA82");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PK__nota__AD5F462E5EE20ECA");

            entity.ToTable("nota");

            entity.Property(e => e.IdNota)
                .ValueGeneratedNever()
                .HasColumnName("idNota");
            entity.Property(e => e.AtividadeEntrega).HasColumnName("atividadeEntrega");
            entity.Property(e => e.IdAluno).HasColumnName("idAluno");
            entity.Property(e => e.IdTurma).HasColumnName("idTurma");
            entity.Property(e => e.Observacao)
                .HasColumnType("text")
                .HasColumnName("observacao");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK__nota__idAluno__72C60C4A");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdTurma)
                .HasConstraintName("FK__nota__idTurma__71D1E811");
        });

        modelBuilder.Entity<Presenca>(entity =>
        {
            entity.HasKey(e => e.IdPresenca).HasName("PK__presenca__44CEA427A24B8FFA");

            entity.ToTable("presenca");

            entity.Property(e => e.IdPresenca)
                .ValueGeneratedNever()
                .HasColumnName("idPresenca");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.HoraChegada).HasColumnName("horaChegada");
            entity.Property(e => e.HoraSaida).HasColumnName("horaSaida");
            entity.Property(e => e.IdAluno).HasColumnName("idAluno");
            entity.Property(e => e.IdTurma).HasColumnName("idTurma");

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.Presencas)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK__presenca__idAlun__6EF57B66");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.Presencas)
                .HasForeignKey(d => d.IdTurma)
                .HasConstraintName("FK__presenca__idTurm__6E01572D");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.IdProfessor).HasName("PK__professo__4E7C3C6DE21EC098");

            entity.ToTable("professor");

            entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");
            entity.Property(e => e.IdTurma).HasColumnName("idTurma");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.Professors)
                .HasForeignKey(d => d.IdTurma)
                .HasConstraintName("FK__professor__idTur__656C112C");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Professors)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__professor__idUsu__66603565");
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.IdTurma).HasName("PK__turma__AA0683103D233798");

            entity.ToTable("turma");

            entity.Property(e => e.IdTurma)
                .ValueGeneratedNever()
                .HasColumnName("idTurma");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__645723A6C1D48878");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
