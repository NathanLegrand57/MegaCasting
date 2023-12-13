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
    /// Logique d'interaction pour PartenaireView.xaml
    /// </summary>
    public partial class PartenaireView : UserControl
    {
        public PartenaireView()
        {
            InitializeComponent();
            DataContext = new ViewModelPartenaire();
        }
        private void Delete_Partenaire_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelPartenaire)this.DataContext).RemovePartenaire();
        }

        private void Create_Partenaire_Click(object sender, RoutedEventArgs e)
        {
            FormCreatePartenaireView formCreatePartenaireView = new FormCreatePartenaireView();

            formCreatePartenaireView.ShowDialog();

            //formCreatePartenaireView.MyProperty;

        }
        private void Edit_Partenaire_Click(object sender, RoutedEventArgs e)
        {
            FormEditPartenaireView formEdit = new FormEditPartenaireView();

            formEdit.ShowDialog();

            //formEdit.MyProperty;
        }
    }
}
