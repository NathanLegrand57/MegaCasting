using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class TypeContrat
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Contrat> Contrats { get; set; } = new List<Contrat>();

    static void Main()
    {
        string connectionString = "Server=localhost;Database=megacasting;User ID=root;Password=";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Définissez votre instruction SQL d'insertion
                string query = "INSERT INTO type_contrat (id, libelle) VALUES (@valeur1, @valeur2)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Remplacez les paramètres avec les valeurs réelles
                    cmd.Parameters.AddWithValue("@valeur1", "?");
                    cmd.Parameters.AddWithValue("@valeur2", "Test2");

                    // Exécutez la commande
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Données insérées avec succès !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }
    }
}
