﻿using MegaCasting.DBLib.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Wpf.ViewModels
{

    internal class ViewModelCasting
    {

        public ObservableCollection<Casting> Castings { get; set; }

        public Casting? SelectedCasting { get; set; }

        public ViewModelCasting()
        {

            using (MegacastingContext mg = new MegacastingContext())
            {
                Castings = new ObservableCollection<Casting>(mg.Castings.Include(p=>p.Adresse).ThenInclude(a=>a.Ville).ToList());
            }
        }
        internal void RemoveCasting()
        {
            if (this.SelectedCasting is not null)
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