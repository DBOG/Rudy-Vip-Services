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
using DomainLibrary;
using DataLayer;
using System.Linq;

namespace Vip_Services_Rudy_2020
{
    /// <summary>
    /// Interaction logic for NieuweReservatiePage.xaml
    /// </summary>
    public partial class NieuweReservatiePage : Page
    {
        public ReservatieManager rm;
        public NieuweReservatiePage()
        {
            InitializeComponent();

            rm = new ReservatieManager(new UnitOfWork(new ReservatieContext()));

            foreach (Voertuig v in rm.getVoertuigen())
                comboBoxVoertuig.Items.Add($"{v.Naam} ,{v.Id}");

            if(comboBoxArrangement.Items.Count < 3)
            {
                foreach (var value in Arrangement.GetValues(typeof(Arrangement)))
                {
                    if (!comboBoxArrangement.Items.Contains(value.ToString()))
                        comboBoxArrangement.Items.Add(value.ToString());
                }
            }
            foreach (var value in Locaties.GetValues(typeof(Locaties)))
            {
                if (!comboBoxOphaalLoc.Items.Contains(value))
                    comboBoxOphaalLoc.Items.Add(value);
                if (!comboBoxAfzetLoc.Items.Contains(value))
                    comboBoxAfzetLoc.Items.Add(value);
            }
            comboBoxOphaalLoc.SelectedIndex = 0;
            comboBoxAfzetLoc.SelectedIndex = 0;
        }
        private void btnPlaatsReservatie_Click(object sender, RoutedEventArgs e)
        {
            //check if everyting is correctly filled in:
            string errorMessage = "Please Fill in the next items: \n\n";
            if(datePicker.SelectedDate.HasValue == false) { errorMessage += "DateTime\n"; }
            if(datePicker.SelectedDate.Value < DateTime.Now) { errorMessage += "Date cannot be in the past!\n"; }
            if(txtBoxklantId.Text == "") { errorMessage += "Klant Id\n"; }
            if(comboBoxArrangement.SelectedItem == null) { errorMessage += "Arrangement\n"; }
            if(timeStart.Text == null) { errorMessage += "Start uur\n"; }
            if(totaaluur.Text == null) { errorMessage += "Totaal uur\n"; }
            if(comboBoxVoertuig.SelectedItem == null) { errorMessage += "Voertuig\n"; }
            if(errorMessage.Length > 35)
                MessageBox.Show(errorMessage, "Oh ohh you forgot some information", MessageBoxButton.OK);
            else
            {
                //converts input to data
            
                Klant klant = rm.getKlantByID(int.Parse(txtBoxklantId.Text));
                DateTime datum = (DateTime)datePicker.SelectedDate;
                DateTime completeDate = datum.AddHours((double)timeStart.Value);
                Locaties ophaalLoc = (Locaties)comboBoxOphaalLoc.SelectedIndex;
                Locaties afzetLoc = (Locaties)comboBoxAfzetLoc.SelectedIndex;
                Voertuig voertuig = rm.ZoekVoertuigById(int.Parse(comboBoxVoertuig.SelectedItem.ToString().Split(",")[1]));
                Arrangement arrangement = (Arrangement)comboBoxArrangement.SelectedIndex;
                int aantaluren = (int)totaaluur.Value;
            
                //calculate price
                Reservatie r = rm.CalculatePriceForPreview( klant, completeDate, ophaalLoc, afzetLoc, voertuig, arrangement, aantaluren);

                //validation for correct price
                string message = $"{r.Arrangement}\n\n{r.Datum}\n{r.GereserveerdeVoertuig.Naam}\nExcl Btw:{r.TotaalExclusiefBtw}\nInc Btw:{r.TeBetalenBedrag}\n{r.klant.Naam}\n";
                MessageBoxResult result = MessageBox.Show(message, "Price Confirmation", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                    rm.CreateNewReservation(r);
            }
           
        }
        private void arrangement_Changed(object sender, RoutedEventArgs e)
        {
            //arrangement enum index:
            //Airport = 0,
            //Business = 1,
            //Wedding = 2,
            //Wellness = 3,
            //NightLife = 4

            timeStart.Value = null;
            totaaluur.Value = null;
            comboBoxVoertuig.SelectedItem = null;
            List<Voertuig> voertuigen = rm.getVoertuigen();
            if(datePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select date first!", "Oops!", MessageBoxButton.OK);
                comboBoxArrangement.SelectedItem = null;
            }
            else
            {
                List<Voertuig> unavailableCars = new List<Voertuig>();
                var unavailableListByReservation = rm.getVoertuigenUnAvailableOnDate(datePicker.SelectedDate.Value);
                IEnumerable<Voertuig> unavailableListByArrangement;
                if (comboBoxArrangement.SelectedIndex == 2)
                {
                    unavailableListByArrangement = voertuigen.Where(s => s.Wedding.ToString().StartsWith("0"));

                    timeStart.Minimum = 7;
                    timeStart.Value = 7;
                    timeStart.Maximum = 15;
                }
                else if (comboBoxArrangement.SelectedIndex == 4)
                {
                    unavailableListByArrangement = voertuigen.Where(s => s.NightLife.ToString().StartsWith("0"));

                    timeStart.Minimum = 20;
                    timeStart.Value = 20;
                    timeStart.Maximum = 24;
                }
                else if (comboBoxArrangement.SelectedIndex == 3)
                {
                    unavailableListByArrangement = voertuigen.Where(s => s.Wellness.ToString().StartsWith("0"));

                    timeStart.Minimum = 7;
                    timeStart.Value = 7;
                    timeStart.Maximum = 12;
                }
                else
                {
                    timeStart.Minimum = 0;
                    timeStart.Maximum = 23;
                    unavailableListByArrangement = voertuigen.Where(s => s.EersteUur.ToString().StartsWith("0"));
                }

                foreach (var v in unavailableListByArrangement)
                {
                    unavailableCars.Add(v);
                }
                foreach (var v in unavailableListByReservation)
                {
                    if (!unavailableCars.Contains(v))
                        unavailableCars.Add(v);
                }
                foreach(Voertuig v in unavailableCars)
                {
                    voertuigen.Remove(v);
                }

                comboBoxVoertuig.Items.Clear();
                foreach(Voertuig v in voertuigen)
                {
                    comboBoxVoertuig.Items.Add($"{ v.Naam} ,{ v.Id}");
                }
            }
        }
        private void startuur_Changed(object sender, RoutedEventArgs e)
        {
            if(comboBoxArrangement.SelectedItem == null)
            {
                MessageBox.Show("Please select type of arrangement first!", "Oops!", MessageBoxButton.OK);
                timeStart.Value = null;
            }
            else
            {
                if (comboBoxArrangement.SelectedIndex == 3)
                    totaaluur.Maximum = 10;
                else
                    totaaluur.Maximum = 11;
            }
        }

        private void comboBoxVoertuig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBoxArrangement.SelectedItem == null)
            {
                comboBoxVoertuig.SelectedItem = null;
                MessageBox.Show("Please select type of arrangement first!", "Oops!", MessageBoxButton.OK);
            }
        }
    }
}
