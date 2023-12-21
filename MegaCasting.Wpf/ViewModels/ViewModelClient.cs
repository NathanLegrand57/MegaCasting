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
    public class ViewModelClient
    {
        public ObservableCollection<Client> Clients { get; set; }

        public Client? SelectedClient { get; set; }


        public ViewModelClient()
        {

            using (MegacastingContext mg = new MegacastingContext())
            {
                Clients = new ObservableCollection<Client>(mg.Clients.Include(p => p.Adresse).ThenInclude(a => a.Ville).ToList());
            }
        }
        internal void UpdateClient()
        {
            if (this.SelectedClient is not null)
            {
                using (MegacastingContext context = new())
                {
                    context.Update(this.SelectedClient);
                    context.SaveChanges();
                }
            }
        }
        internal void RemoveClient()
        {
            if (this.SelectedClient is not null)
            {
                using (MegacastingContext context = new())
                {
                    context.Remove(this.SelectedClient);
                    context.SaveChanges();
                }
                this.Clients?.Remove(this.SelectedClient);
            }
        }
    }
}
