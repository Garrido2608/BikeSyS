using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Dni { get; set; }

    public string? Calle { get; set; }

    public int? Nro { get; set; }

    public string? Email { get; set; }

    public string Telefono { get; set; } = null!;

    public int? IdLocalidad { get; set; }
}
