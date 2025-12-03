using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Presenca
{
    public int IdPresenca { get; set; }

    public DateOnly? Dia { get; set; }

    public TimeOnly? HoraChegada { get; set; }

    public TimeOnly? HoraSaida { get; set; }

    public int? IdTurma { get; set; }

    public int? IdAluno { get; set; }

    public virtual Aluno? IdAlunoNavigation { get; set; }

    public virtual Turma? IdTurmaNavigation { get; set; }
}
