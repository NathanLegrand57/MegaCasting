﻿using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class TypeContrat
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Contrat> Contrats { get; set; } = new List<Contrat>();
}
