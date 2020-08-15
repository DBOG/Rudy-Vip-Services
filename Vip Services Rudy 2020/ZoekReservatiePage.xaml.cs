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
    /// Interaction logic for ZoekReservatiePage.xaml
    /// </summary>
    public partial class ZoekReservatiePage : Page
    {
        ReservatieManager rm;
        public ZoekReservatiePage()
        {
            InitializeComponent();
            rm = new ReservatieManager(new UnitOfWork(new ReservatieContext()));
        }

        private void txtBoxKlantNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = txtBoxKlantNaam.Text;
            if (listViewReservaties.Items.Count >= 1)
                listViewReservaties.ClearValue(ItemsControl.ItemsSourceProperty);

            List<Reservatie> reservaties;
            if (!datePickerBox.SelectedDate.HasValue)
                reservaties = rm.GetReservatiesByKlantNaam(text);
            else
                reservaties = rm.GetReservatiesByKlantAndDatum(text, datePickerBox.SelectedDate.Value);

            listViewReservaties.ItemsSource = reservaties;
        }
        private void DateTimePick_ValueChanged(Object sender, EventArgs e)
        {
            string text = txtBoxKlantNaam.Text;
            if(listViewReservaties.Items.Count >= 1)
                listViewReservaties.ClearValue(ItemsControl.ItemsSourceProperty);

            List<Reservatie> reservaties;
            if (text == "")
                reservaties = rm.GetReservatiesByDatum(datePickerBox.SelectedDate.Value);
            else
                reservaties = rm.GetReservatiesByKlantAndDatum(text, datePickerBox.SelectedDate.Value);

            listViewReservaties.ItemsSource = reservaties;
        }

        private void btnCancelReservation_Click(object sender, RoutedEventArgs e)
        {
            if(listViewReservaties.SelectedItems == null)
                MessageBox.Show("Please select a reservation you want to delete","selection", MessageBoxButton.OK);

            else
            {
                string confirmMessage = "Are you sure you want to delete the following reservations?: \n\n";
                List<Reservatie> r = new List<Reservatie>();
                foreach(Reservatie v in listViewReservaties.SelectedItems)
                {
                    r.Add(v);
                    confirmMessage += $"{v.klant.Naam}, {v.Datum}, {v.GereserveerdeVoertuig.Naam}\n";
                }

                if(MessageBox.Show(confirmMessage, "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    rm.CancelReservation(r);

            }
        }
    }
}
