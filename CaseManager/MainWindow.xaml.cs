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
            InitializeComponent();
            dm = (Application.Current as App).DefaultDataModel;
            dm.ResetData();
            Theme = ColorScheme.GetDarkTheme();
            mainFrame.Navigate(new Dashboard(this));
        }
    }
}
