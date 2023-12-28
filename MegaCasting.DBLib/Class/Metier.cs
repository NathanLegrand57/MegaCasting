using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Metier
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public int DomaineMetierId { get; set; }
}
