﻿using System;
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
using System.Windows.Shapes;
using GestionEventos.View;
using GestionEventos.ViewModel;

namespace GestionEventos.View
{
    /// <summary>
    /// Interaction logic for homeLocal.xaml
    /// </summary>
    public partial class homeLocal : Window
    {
        public homeLocal()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }                
    }
}
