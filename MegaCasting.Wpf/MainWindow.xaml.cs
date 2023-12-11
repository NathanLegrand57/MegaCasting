using MegaCasting.DBLib.Class;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MegaCasting.Wpf.ViewModels;
using MegaCasting.Wpf.Views;

namespace MegaCasting.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// MahApps.Metro.Controls.MetroWindow
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelCasting();
        }
        private void creer_Click(object sender, RoutedEventArgs e)
        {
            FormOffer formOffer = new FormOffer();

            formOffer.ShowDialog();

            //formOffer.MyProperty;
        }
        private void modif_Click(object sender, RoutedEventArgs e)
        {
            FormModif formModif = new FormModif();

            formModif.ShowDialog();

            //formModif.MyProperty;
        }

        private void DeleteCastingButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelCasting)this.DataContext).RemoveCasting();
        }
    }
}
