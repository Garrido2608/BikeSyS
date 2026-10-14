using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class RepuestoUsado
{
    public int Id { get; set; }

    public int IdOrdenService { get; set; }

    public int IdRepuesto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }
}
