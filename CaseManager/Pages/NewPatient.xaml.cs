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
    public partial class NewPatient : Page
    {
        private MainWindow window;
        public DataModel Source { get { return window.dm; } }
        public ColorScheme Theme { get { return window.Theme; } set { window.Theme = value; } }

        public NewPatient(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            Source.ClearPatientData();
            this.DataContext = this;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            window.mainFrame.GoBack();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            History h = new History() { BloodPressure = cBpEditH.Text + "/" + cBpEditL.Text, HistoryText = cHistEdit.Text, Temperature = float.Parse(cTempEdit.Text), Treatment = cTreatEdit.Text, Date = Source.CurrentPatient.CaseDate };
            Source.CurrentPatient.HistoryData.Add(h);
            Source.SubmitPatient(true);
            window.mainFrame.GoBack();
        }

        private void numberMask(object sender, TextChangedEventArgs e)
        {
            var tbox = sender as TextBox;
            string txt = tbox.Text;
            if (txt != "")
            {
                try
                {
                    int.Parse(txt);
                }
                catch (Exception)
                {
                    txt = txt.Remove(txt.Length - 1);
                }
                tbox.Text = txt;
                tbox.SelectionStart = tbox.Text.Length;
            }
        }
        private void floatMask(object sender, TextChangedEventArgs e)
        {
            var tbox = sender as TextBox;
            string txt = tbox.Text;
            if (txt != "")
            {
                try
                {
                    float.Parse(txt);
                }
                catch (Exception)
                {
                    txt = txt.Remove(txt.Length - 1);
                }
                tbox.Text = txt;
                tbox.SelectionStart = tbox.Text.Length;
            }
        }
    }
}
