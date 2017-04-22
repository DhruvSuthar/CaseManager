using CaseManager.Modules;
using CaseManager.Modules.DataStructures;
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

namespace CaseManager.Pages
{
    public partial class Dashboard : Page
    {
        private MainWindow window;
        public DataModel Source { get { return window.dm; } }
        public ColorScheme Theme { get { return window.Theme; } set { window.Theme = value; } }

        public Dashboard(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            this.DataContext = this;
        }

        private void NewPatientClick(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new NewPatient(window));
        }

        private void StatsClick(object sender, RoutedEventArgs e)
        {
            //window.mainFrame.Navigate(new Stats(window));
        }

        private void popup_LostFocus(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            popup.IsOpen = false;
            string txt = SearchBar.Text;
            if (txt.Contains("'")) txt = txt.Replace("'", "''");
            try
            {
                if (SearchBar.Text != "")
                {
                    var list = await Source.DataSource.Select(Strings.Patient, Strings.CaseID + "," + Strings.PatientName, Strings.Expired + "='false' AND " + Strings.CaseID + " LIKE '%" + txt + "%' OR " + Strings.PatientName + " LIKE '%" + txt + "%'");
                    var SearchViewSource = new List<SearchView>();
                    foreach (var item in list)
                    {
                        SearchViewSource.Add(new SearchView() { CaseID = item[0], PatientName = item[1] });
                    }
                    ItemsList.ItemsSource = SearchViewSource;
                    popup.IsOpen = true;
                }
            }
            catch(Exception)
            {

            }
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = (ItemsList.SelectedItem as SearchView).CaseID;
            LoadPatient(name);
            window.mainFrame.Navigate(new OldPatient(window));
        }

        private async void LoadPatient(string CID)
        {
            var data = await Source.DataSource.Select(Strings.Patient, Strings.PatientInstance, Strings.CaseID + "='" + CID + "'");
            Source.CurrentPatient = Patient.GetPatient(data[0][0]);
        }
    }
}
