using System;
using System.Collections.Generic;

namespace Academico_.Models;

public partial class Professor
{
    public int IdProfessor { get; set; }

    public string? Nome { get; set; }

    public int? IdTurma { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Turma? IdTurmaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
