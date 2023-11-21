using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Partenaire
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Casting> Castings { get; set; } = new List<Casting>();
}
