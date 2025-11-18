using System;
using System.Collections.Generic;

namespace Academico_.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();
}
