using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Ville
{
    public int Id { get; set; }

    public int CodePostal { get; set; }

    public string Nom { get; set; } = null!;
}
