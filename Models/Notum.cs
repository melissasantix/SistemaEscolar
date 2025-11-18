using System;
using System.Collections.Generic;

namespace Academico_.Models;

public partial class Notum
{
    public int IdNota { get; set; }

    public DateOnly? AtividadeEntrega { get; set; }

    public string? Observacao { get; set; }

    public int? IdTurma { get; set; }

    public int? IdAluno { get; set; }

    public virtual Aluno? IdAlunoNavigation { get; set; }

    public virtual Turma? IdTurmaNavigation { get; set; }
}
