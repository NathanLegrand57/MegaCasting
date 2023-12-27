using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Casting
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Libelle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public int AdresseId { get; set; }

    public int ClientId { get; set; }

    public int PartenaireId { get; set; }

    public virtual Adresse Adresse { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Partenaire Partenaire { get; set; } = null!;
}
