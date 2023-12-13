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

        private void Show_Details_Casting(object sender, RoutedEventArgs e)
        {
            ViewModelDetails detailsview = new ViewModelDetails();

            detailsview.ShowDialog();

            //detailsview.MyProperty;
        }

        private void Create_Casting_Click(object sender, RoutedEventArgs e)
        {
            FormCreateCastingView formCreateCastingView = new FormCreateCastingView();

            formCreateCastingView.ShowDialog();

            //formCreateCastingView.MyProperty;
        }
        private void Edit_Casting_Click(object sender, RoutedEventArgs e)
        {
            FormEditCasting formModif = new FormEditCasting();

            formModif.ShowDialog();

            //formModif.MyProperty;
        }

        private void Delete_Casting_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelCasting)this.DataContext).RemoveCasting();
        }
    }
}
