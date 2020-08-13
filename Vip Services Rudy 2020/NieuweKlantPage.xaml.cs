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
    /// Interaction logic for NieuweKlantPage.xaml
    /// </summary>
    public partial class NieuweKlantPage : Page
    {
        ReservatieManager rm;
        public NieuweKlantPage()
        {
            InitializeComponent();
            rm = new ReservatieManager(new UnitOfWork(new ReservatieContext()));
            foreach (var value in KlantType.GetValues(typeof(KlantType)))
            {
                if (!comboBoxType.Items.Contains(value.ToString()))
                    comboBoxType.Items.Add(value.ToString());
            }
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            string errormessage = "Please fill in: \n\n";
            if(txtBoxNaam.Text == "") { errormessage += "Naam\n"; }
            if(comboBoxType.SelectedItem == null) { errormessage += "Type\n"; }
            if(txtBoxAdres.Text == "") { errormessage += "Adres\n"; }
            if (errormessage.Length > 20)
                MessageBox.Show(errormessage, "oh ohh you forgot some information", MessageBoxButton.OK);
            else
            {
                rm.AddKlant(new Klant((KlantType)comboBoxType.SelectedIndex, txtBoxNaam.Text, txtBoxBtwNummer.Text, txtBoxAdres.Text));
                MessageBox.Show("Klant Succesvol toegevoegd!","Succes!", MessageBoxButton.OK);
            }
        }
    }
}
