using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class Repuesto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}
