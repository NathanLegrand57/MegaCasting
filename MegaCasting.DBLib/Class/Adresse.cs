﻿using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Adresse
{
    public int Id { get; set; }

    public string Rue { get; set; } = null!;

    public int VilleId { get; set; }

    public virtual Ville Ville { get; set; } = null!;
}
