﻿using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Client
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public int AdresseId { get; set; }

    public int CastingId { get; set; }

    public virtual Adresse Adresse { get; set; } = null!;

    public virtual ICollection<Casting> Castings { get; set; } = new List<Casting>();
}
