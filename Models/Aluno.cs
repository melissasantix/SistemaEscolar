using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Aluno
{
    public int IdAluno { get; set; }

    public string? Nome { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public int? IdTurma { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Turma? IdTurmaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}
