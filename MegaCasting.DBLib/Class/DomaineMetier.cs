using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class DomaineMetier
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Metier> Metiers { get; set; } = new List<Metier>();
}
