using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class HistorialEstado
{
    public int Id { get; set; }

    public int IdOrdenService { get; set; }

    public int IdEstado { get; set; }

    public DateTime Fecha { get; set; }
}
