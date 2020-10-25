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
using System.Windows.Shapes;

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for WinkellijstWindow.xaml
    /// </summary>
    public partial class WinkellijstWindow : Window
    {
        public WinkellijstWindow()
        {
            InitializeComponent();
        }

        private void btnTerugNaarArtikellijst_Click(object sender, RoutedEventArgs e)
        {
            Window ArtikellijstWindow = new MainWindow() ;
            ArtikellijstWindow.Show();
            this.Close();
        }
    }
}
