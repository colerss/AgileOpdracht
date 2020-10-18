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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNieuwArtikel_Click(object sender, RoutedEventArgs e)
        {
            Window Seizoen = new ProductToevoegenWindow();
            Seizoen.Show();
            this.Close();
        }

        private void btnWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            Window Seizoen = new WinkellijstWindow();
            Seizoen.Show();
            this.Close();
        }
    }
}