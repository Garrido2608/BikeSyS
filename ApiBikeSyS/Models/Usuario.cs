using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdRol { get; set; }
}