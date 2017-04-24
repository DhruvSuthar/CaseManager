﻿using CaseManager.Modules;
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

        public Statistics(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            this.DataContext = this;
        }
    }
}