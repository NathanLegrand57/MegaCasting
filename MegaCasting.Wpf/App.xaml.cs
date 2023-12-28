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
                AddMockupVilles();
                AddMockupAdresses();
                AddMockupClients();
                AddMockupPartenaires();
                AddMockupCastings();
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
        private void AddMockupVilles()
        {

            Ville villeTest = new Ville()
            {
                CodePostal = 44190,
                Nom = "Clisson",

        };

            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Villes.Add(villeTest);
                context.SaveChanges();
            }
        }
        private void AddMockupAdresses()
        {

            Adresse adresseTest = new Adresse()
            {
                Rue = "1 Rue Paul Verlaine",
                VilleId = 1,

        };

            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Adresses.Add(adresseTest);
                context.SaveChanges();
            }
        }
        private void AddMockupClients()
        {

            Client clientTest = new Client()
            {
                Libelle = "TF1 production",
                AdresseId = 1,
        };

            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Clients.Add(clientTest);
                context.SaveChanges();
            }
        }
        private void AddMockupPartenaires()
        {

            Partenaire partenaireTest = new Partenaire()
            {
                Libelle = "Indeed",
        };

            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Partenaires.Add(partenaireTest);
                context.SaveChanges();
            }
        }
        private void AddMockupCastings()
        {
            var currentTime = SystemTime.Now;

            Casting castingTest = new Casting()
            {
                Type = "Cinéma",
                Libelle = "Cadreur",
                Description = "Nous recherchons un cadreur compétent et motivé disposé à rejoindre une équipe technique dans le cinéma",
                Date = currentTime,
                AdresseId= 1,
                ClientId= 1,
                PartenaireId= 1,

        };

            using (MegacastingContext context = new())
            {
                // On supprime la base de données
                context.Castings.Add(castingTest);
                context.SaveChanges();
            }
        }

        #endregion

        #endregion

    }
}
