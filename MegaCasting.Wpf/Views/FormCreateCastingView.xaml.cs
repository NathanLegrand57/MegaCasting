﻿using System;
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
using static System.Net.Mime.MediaTypeNames;

namespace MegaCasting.Wpf
{
    /// <summary>
    /// Logique d'interaction pour FormOffer.xaml
    /// </summary>
    public partial class FormCreateCastingView : Window
    {

        public int MyProperty { get; set; }
        public FormCreateCastingView()
        {
            InitializeComponent();
        }


        private void valider_click(object sender, RoutedEventArgs e)
        {

        }

        private void annuler_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
