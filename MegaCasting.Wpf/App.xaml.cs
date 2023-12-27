using MegaCasting.DBLib.Class;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Fields

        private bool _IsLoggedIn;


        #endregion


        #region Properties

        public bool IsLoggedIn { get => _IsLoggedIn; set => _IsLoggedIn = value; }

        #endregion

        #region Constructors


        /// <summary>
        /// Surcharge de l'instanciation de l'App.
        /// On s'en sert pour détruire et recréé la base de données.
        /// </summary>
        public App() : base()
        {
            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Database.EnsureDeleted();

                // Puis on la recréé.
                context.Database.EnsureCreated();

                // Ajout des utilisateurs de tests.
                AddMockupUsers();
            }
        }


        #endregion

        #region Methods

        #region Mockups datas

        /// <summary>
        /// Génère des utilisateurs de test.
        /// </summary>
        private void AddMockupUsers()
        {

            // Outil de hashage
            PasswordHasher hasher = new PasswordHasher();

            Utilisateur userTest = new Utilisateur()
            {
                NomUtilisateur = "Test",
                MotDePasse = hasher.HashPassword("test"),
            };

            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Utilisateurs.Add(userTest);
                context.SaveChanges();
            }
        }

        #endregion

        #endregion

    }
}
