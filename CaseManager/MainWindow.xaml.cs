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
using CaseManager.Pages;
using CaseManager.Modules;

namespace CaseManager
{
    public partial class MainWindow : Window
    {
        public DataModel dm { get; }
        public ColorScheme Theme { get; set; }

        public MainWindow()
        {
            Theme = ColorScheme.GetDarkTheme();
            InitializeComponent();
            dm = (Application.Current as App).DefaultDataModel;
            mainFrame.Navigate(new Dashboard(this));
            DataContext = this;
        }

        private void slider_Click(object sender, RoutedEventArgs e)
        {
            if (themeText.Text == "Dark")
            {
                slider.HorizontalAlignment = HorizontalAlignment.Right;
                themeText.Text = "Light";
                Theme = ColorScheme.GetLightTheme();
            }
            else
            {
                slider.HorizontalAlignment = HorizontalAlignment.Left;
                themeText.Text = "Dark";
                Theme = ColorScheme.GetDarkTheme();
            }
            DataContext = null;
            DataContext = this;
            (mainFrame.Content as Page).DataContext = null;
            (mainFrame.Content as Page).DataContext = (mainFrame.Content as Page);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dm.UpdateDB();
        }
    }
}
