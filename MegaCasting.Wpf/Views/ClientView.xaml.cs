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
    /// Logique d'interaction pour ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {
        public ClientView()
        {
            InitializeComponent();
            DataContext = new ViewModelClient();

        }
        private void Delete_Client_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelClient)this.DataContext).RemoveClient();
        }
        private void Create_Client_Click(object sender, RoutedEventArgs e)
        {
            FormCreateClientView formOffer = new FormCreateClientView();

            formOffer.ShowDialog();

            //formOffer.MyProperty;

        }private void Edit_Client_Click(object sender, RoutedEventArgs e)
        {
            FormEditClientView formEdit = new FormEditClientView();

            formEdit.ShowDialog();

            //formEdit.MyProperty;
        }
    }
}
