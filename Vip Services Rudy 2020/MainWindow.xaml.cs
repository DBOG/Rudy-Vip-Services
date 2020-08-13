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

namespace Vip_Services_Rudy_2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentContainer.Content = new HomePage();
        }


        private void BtnHomePage_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new HomePage();
        }

        private void BtnNieuweReservatie_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new NieuweReservatiePage();
        }

        private void BtnZoekReservatie_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new ZoekReservatiePage();
        }

        private void BtnNieuweKlant_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new NieuweKlantPage();
        }

        private void BtnZoekKlant_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Content = new ZoekKlantPage();
        }
    }
}
