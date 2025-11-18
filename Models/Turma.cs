using System;
using System.Collections.Generic;

namespace Academico_.Models;

public partial class Turma
{
    public int IdTurma { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();

    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
