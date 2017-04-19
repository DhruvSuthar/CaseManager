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

namespace CaseManager
{
    public partial class MainWindow : Window
    {
        private DataModel dm;

        public MainWindow()
        {
            InitializeComponent();
            dm = (Application.Current as App).DefaultDataModel;
            dm.ResetData();
            mainFrame.Navigate(new Dashboard());
        }
    }
}
