using MegaCasting.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MegaCasting.Wpf.ViewModels
{

    public class ViewModelCasting
    {
          internal void AddCasting()
          {

            using (MegacastingContext context = new())
              {
                if (this.NewCasting == null)
                {
                    this.NewCasting = new Casting();
                    this.NewCasting.Adresse = new Adresse();
                }

                context.Add(this.NewCasting);//J'ajoute le casting au contexte
                this.NewCasting.Adresse.VilleId = SelectedVille.Id;
                this.NewCasting.PartenaireId = SelectedPartenaire.Id;
                this.NewCasting.ClientId = SelectedClient.Id;
                  //this.SelectedCasting.ClientId = SelectedClient.Id;
                context.SaveChanges(); // Je sauvegarde les modification du contexte en base de données
                this.Castings.Add(this.NewCasting); // Si j'ai une liste pour la vue, je l'y ajoute pour qu'elle s'affiche
                this.SelectedCasting = this.NewCasting;
                context.Castings
                    .Include(p => p.Adresse)
                    .ThenInclude(a => a.Ville)
                    .First(c => c.Id == this.NewCasting.Id);
              }
          }


        //-------------------------------------------------------------------------------------------------------------


        public Ville? SelectedVille { get; set; }

        public Partenaire? SelectedPartenaire { get; set; }
        public Client? SelectedClient { get; set; }

        public ObservableCollection<Casting> Castings { get; set; }

        public ObservableCollection<Ville> Villes { get; set; }
        
        public ObservableCollection<Partenaire> Partenaires { get; set; }

        public ObservableCollection<Client> Clients { get; set; }


        public Casting? SelectedCasting { get; set; }

        public Casting? NewCasting { get; set; }

        public ViewModelCasting()
        {
            if (this.NewCasting == null)
            {
                this.NewCasting = new Casting();
                this.NewCasting.Adresse = new Adresse();
            }


            using (MegacastingContext mg = new MegacastingContext())
            {
                Castings = new ObservableCollection<Casting>(mg.Castings.Include(p=>p.Adresse).ThenInclude(a=>a.Ville).Include(b=>b.Partenaire).ToList());
                Villes = new ObservableCollection<Ville>(mg.Villes.ToList());
                Partenaires = new ObservableCollection<Partenaire>(mg.Partenaires.ToList());
                Clients = new ObservableCollection<Client>(mg.Clients.ToList());
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
