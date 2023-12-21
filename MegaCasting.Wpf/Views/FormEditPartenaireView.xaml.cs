﻿using MegaCasting.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MegaCasting.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour FormEditPartenaireView.xaml
    /// </summary>
    public partial class FormEditPartenaireView : Window
    {
        public FormEditPartenaireView(ViewModelPartenaire viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void UpdatePartenaireButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelPartenaire)this.DataContext).SelectedPartenaire != null)
            {
                ((ViewModelPartenaire)this.DataContext).UpdatePartenaire();
                this.Close();

            }

        }

        private void annuler_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
