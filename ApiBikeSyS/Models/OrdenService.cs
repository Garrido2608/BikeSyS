using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class OrdenService
{
    public int Id { get; set; }

    public int IdBicicleta { get; set; }

    public DateTime FechaRecepcion { get; set; }

    public string Motivo { get; set; } = null!;

    public decimal TotalGeneral { get; set; }
}
