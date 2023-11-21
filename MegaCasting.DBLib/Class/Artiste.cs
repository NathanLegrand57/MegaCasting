using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Artiste
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateTime DateNaissance { get; set; }

    public sbyte NumTel { get; set; }

    public string Email { get; set; } = null!;

    public int MetierId { get; set; }

    public virtual Metier Metier { get; set; } = null!;
}
