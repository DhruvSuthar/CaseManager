﻿using CaseManager.Modules.DataStructures;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CaseManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DataModel DefaultDataModel { get; set; } = new DataModel();

    }
}
