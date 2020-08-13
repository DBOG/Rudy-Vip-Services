using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer;
using DomainLibrary;

namespace Vip_Services_Rudy_2020
{
    /// <summary>
    /// Interaction logic for ZoekKlantPage.xaml
    /// </summary>
    public partial class ZoekKlantPage : Page
    {
        ReservatieManager rm;
        public ZoekKlantPage()
        {
            InitializeComponent();
            rm = new ReservatieManager(new UnitOfWork(new ReservatieContext()));
        }

        private void txtBoxKlantNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = txtBoxKlantNaam.Text;
            List<Klant> klanten = rm.getKlantenByName(text);
            listviewKlanten.Items.Clear();
            foreach(Klant k in klanten)
            {
                if(!listviewKlanten.Items.Contains(k))
                    listviewKlanten.Items.Add(k);
            }
        }
    }
}
