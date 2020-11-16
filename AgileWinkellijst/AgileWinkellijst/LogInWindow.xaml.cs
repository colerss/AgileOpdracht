﻿using AgileWinkellijst_DAL;
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

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public static LogInWindow instance;
        public Gebruiker gebruiker;
        public LogInWindow()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            gebruiker = DatabaseOperations.SelectGebruikerById(0);
            Window Assortiment = new MainWindow();
            Assortiment.Show();
            this.Close();
        }
    }
}
