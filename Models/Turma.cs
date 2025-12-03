using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Turma
{
    public int IdTurma { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
