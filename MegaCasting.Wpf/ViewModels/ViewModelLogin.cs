using MegaCasting.Core;
using MegaCasting.DBLib.Class;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Wpf.ViewModels
{
    internal class ViewModelLogin : ObservableObject
    {
        #region Fields

        /// <summary>
        /// Utilisateur
        /// </summary>
        private string? _NomUtilisateur;

        /// <summary>
        /// Mot de passe
        /// </summary>
        private string? _MotDePasse;

        /// <summary>
        /// Message
        /// </summary>
        private string? _Message;

        /// <summary>
        /// Indique si l'utilisateur est connecté ou non.
        /// </summary>
        private bool? _IsLoggedIn;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini <see cref="_NomUtilisateur"/>
        /// </summary>
        public string? NomUtilisateur { get => _NomUtilisateur; set => _NomUtilisateur = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_MotDePasse"/>
        /// </summary>
        public string? MotDePasse { get => _MotDePasse; set => _MotDePasse = value; }

        /// <summary>
        /// Obtient ou défini <see cref="_Message"/>
        /// Vu qu'on veut actualisé la vue lors du changement, on utilise <see cref="ObservableObject.SetProperty{T}(string, ref T, T, bool)"/>
        /// </summary>
        public string? Message { get => _Message; set => SetProperty(nameof(Message), ref _Message, value); }

        /// <summary>
        /// Obtient ou défini <see cref="_IsLoggedIn"/>
        /// </summary>
        public bool? IsLoggedIn { get => _IsLoggedIn; private set => SetProperty(nameof(IsLoggedIn), ref _IsLoggedIn, value); }

        #endregion


        #region Constructors

        /// <summary>
        ///  Constructeur
        /// </summary>
        public ViewModelLogin()
        {
            IsLoggedIn = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Méthode de d'authentification d'un utilisateur
        /// </summary>
        internal void Authenticate()
        {
            // Outil de hashage
            PasswordHasher hasher = new PasswordHasher();

            PasswordVerificationResult result = PasswordVerificationResult.Failed;

            // L'utilisateur récupéré
            Utilisateur? utilisateur = null;
            // On recherche l'utilisateur par son identifiant
            using (MegacastingContext context = new())
                utilisateur = context.Utilisateurs.FirstOrDefault(utilisateurTemp => utilisateurTemp.NomUtilisateur.Equals(NomUtilisateur));

            // Si il n'existe pas, on renvoie une erreur
            if (utilisateur == null)
                Message = "Impossible de trouver l'utilisateur";
            else if (MotDePasse == null)
                result = PasswordVerificationResult.Failed;
            else
                result = hasher.VerifyHashedPassword(utilisateur.MotDePasse, MotDePasse);

            switch (result)
            {
                case PasswordVerificationResult.Failed:
                    Message = "Mot de passe incorrect";
                    break;
                case PasswordVerificationResult.Success:
                    // On défini le logging à true. La vue observe cette propriété et va se cacher si IsLogging = true.
                    IsLoggedIn = true;
                    break;
                default:
                    break;
            }
        }

        #endregion


    }
}
