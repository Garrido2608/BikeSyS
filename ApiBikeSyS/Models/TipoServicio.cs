using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class TipoServicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }
}
