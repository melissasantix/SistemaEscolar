using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Nota
{
    public int IdNota { get; set; }

    public DateOnly? AtividadeEntrega { get; set; }

    public string? Observacao { get; set; }

    public int? IdTurma { get; set; }

    public int? IdAluno { get; set; }

    public virtual Aluno? IdAlunoNavigation { get; set; }

    public virtual Turma? IdTurmaNavigation { get; set; }
}
