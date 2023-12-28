﻿using MegaCasting.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.Wpf.ViewModels
{

    public class ViewModelCasting
    {
        internal void AddCasting()
        {
            
            using (MegacastingContext context = new())
            {
                context.Add(this.SelectedCasting);//J'ajoute le casting au contexte
                this.SelectedCasting.Adresse.VilleId = SelectedVille.Id;
                this.SelectedCasting.PartenaireId = SelectedPartenaire.Id;
                context.SaveChanges(); // Je sauvegarde les modification du contexte en base de données
                this.Castings.Add(this.SelectedCasting); // Si j'ai une liste pour la vue, je l'y ajoute pour qu'elle s'affiche
            }
        }


        //-------------------------------------------------------------------------------------------------------------


        public Ville? SelectedVille { get; set; }

        public Partenaire? SelectedPartenaire { get; set; }

        public ObservableCollection<Casting> Castings { get; set; }

        public ObservableCollection<Ville> Villes { get; set; }
        
        public ObservableCollection<Partenaire> Partenaires { get; set; }


        public Casting? SelectedCasting { get; set; }

        public ViewModelCasting(bool isNew = false)
        {

            if (isNew) { 
            
                SelectedCasting = new Casting();
                SelectedCasting.Adresse = new Adresse();

            }

            using (MegacastingContext mg = new MegacastingContext())
            {
                Castings = new ObservableCollection<Casting>(mg.Castings.Include(p=>p.Adresse).ThenInclude(a=>a.Ville).Include(b=>b.Partenaire).ToList());
                Villes = new ObservableCollection<Ville>(mg.Villes.ToList());
                Partenaires = new ObservableCollection<Partenaire>(mg.Partenaires.ToList());
            }
        }
        internal void UpdateCasting()
        {
            if (this.SelectedCasting is not null)
            {
                using (MegacastingContext context = new())
                {
                    context.Update(this.SelectedCasting);
                    context.SaveChanges();
                }
                
            }
        }
        internal void RemoveCasting()
        {
            if (this.SelectedCasting.Libelle is null || this.SelectedCasting.Type is null) // Ne fonctionne pas avec les clés étrangères
            {
                string text = "Impossible de supprimer une ligne vide";
                MessageBox.Show(text);
            } else
            {
                using (MegacastingContext context = new())
                {
                    context.Remove(this.SelectedCasting);
                    context.SaveChanges();
                }
                this.Castings?.Remove(this.SelectedCasting);
            }
        }
    }
}
