using MegaCasting.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Wpf.ViewModels
{
    public class ViewModelPartenaire
    {
        public ObservableCollection<Partenaire> Partenaires { get; set; }

        public Partenaire? SelectedPartenaire { get; set; }


        public ViewModelPartenaire()
        {

            using (MegacastingContext mg = new MegacastingContext())
            {
                Partenaires = new ObservableCollection<Partenaire>(mg.Partenaires.ToList());
            }
        }
        internal void UpdatePartenaire()
        {
            if (this.SelectedPartenaire is not null)
            {
                using (MegacastingContext context = new())
                {
                    context.Update(this.SelectedPartenaire);
                    context.SaveChanges();
                }
            }
        }
        internal void RemovePartenaire()
        {
            if (this.SelectedPartenaire is not null)
            {
                using (MegacastingContext context = new())
                {
                    context.Remove(this.SelectedPartenaire);
                    context.SaveChanges();
                }
                this.Partenaires?.Remove(this.SelectedPartenaire);
            }
        }
    }
}
