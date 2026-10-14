using System;
using System.Collections.Generic;

namespace ApiBikeSyS.Models;

public partial class Bicicleta
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdMarca { get; set; }

    public int IdModelo { get; set; }

    public int IdTipoRueda { get; set; }
}
