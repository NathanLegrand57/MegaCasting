using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Utilisateur
{
    public int Id { get; set; }

    public string NomUtilisateur { get; set; } = null!;

    public string MotDePasse { get; set; } = null!;
}
