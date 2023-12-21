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
using System.Windows.Shapes;

namespace MegaCasting.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour CastingView.xaml
    /// </summary>
    public partial class CastingView : UserControl
    {
        public CastingView()
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
            FormEditCastingView formModif = new FormEditCastingView(((ViewModelCasting)this.DataContext));

            formModif.ShowDialog();
        }

        private void Delete_Casting_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelCasting)this.DataContext).RemoveCasting();
        }
    }
}
