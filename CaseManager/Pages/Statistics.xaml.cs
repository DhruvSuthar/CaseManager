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
    public partial class Statistics : Page
    {
        private MainWindow window;
        public DataModel Source { get { return window.dm; } }
        public ColorScheme Theme { get { return window.Theme; } set { window.Theme = value; } }
        public int[] Monthly { get; set; }
        public int GrandTotal
        {
            get
            {
                int x = 0;
                foreach (var item in Monthly)
                {
                    x += item;
                }
                return x;
            } }

        public Statistics(MainWindow window)
        {
            Monthly = new int[12];
            InitializeComponent();
            this.window = window;
            this.DataContext = this;
            InitYearList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.Navigate(new Dashboard(window));
        }

        private void InitYearlyStats(string year)
        {
            var ls1 = Source.DataSource.Select(Strings.DailyStats, Strings.RevNew + "," + Strings.RevOld + "," + Strings.Month, Strings.Year + "='" + (int.Parse(year) - 1) + "'");
            var ls2 = Source.DataSource.Select(Strings.DailyStats, Strings.RevNew + "," + Strings.RevOld + "," + Strings.Month, Strings.Year + "='" + year + "'");
            cleanMonthly();
            foreach (var item in from x in ls1 where int.Parse(x[2]) > 3 select x)
            {
                Monthly[int.Parse(item[2]) - 4] += int.Parse(item[0]) + int.Parse(item[1]);
            }
            foreach (var item in from x in ls2 where int.Parse(x[2]) < 4 select x)
            {
                Monthly[8 + int.Parse(item[2])] += int.Parse(item[0]) + int.Parse(item[1]);
            }
        }
        private void cleanMonthly()
        {
            for (int i = 0; i < Monthly.Length; i++)
            {
                Monthly[i] = 0;
            }
        }
        private void InitYearList()
        {
            var list = new List<string>() { "Select a year " };
            list.AddRange(Source.DataSource.SelectStarFromField(Strings.DailyStats, "DISTINCT " + Strings.Year));
            YearDropdown.ItemsSource = list;
            YearDropdown.DataContext = this;
            YearDropdown.SelectedIndex = 0;
        }

        private void YearDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (sender as ComboBox).SelectedItem as string;
            if (selectedItem != "Select a year ") 
            {
                InitYearlyStats(selectedItem);
                DataContext = null;
                DataContext = this;
            }
        }
    }
}
