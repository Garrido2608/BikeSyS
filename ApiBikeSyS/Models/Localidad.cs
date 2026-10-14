using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class Localidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdProvincia { get; set; }
}
