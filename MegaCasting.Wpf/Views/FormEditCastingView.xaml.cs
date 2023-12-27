using MegaCasting.Wpf.ViewModels;
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

namespace MegaCasting.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class FormEditCastingView : Window
    {

        public int MyProperty { get; set; }
        public FormEditCastingView(ViewModelCasting viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void UpdateCastingButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelCasting)this.DataContext).SelectedCasting != null)
            {
                ((ViewModelCasting)this.DataContext).UpdateCasting();
                this.Close();

            }
            
        }

        private void annuler_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
