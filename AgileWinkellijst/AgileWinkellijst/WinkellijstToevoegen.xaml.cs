using System;
using System.Collections.Generic;
using System.Linq;
using AgileWinkellijst_DAL;
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
using System.ComponentModel;

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for WinkellijstToevoegen.xaml
    /// </summary>
    public partial class WinkellijstToevoegen : Window
    {
        public WinkellijstToevoegen()
        {
            InitializeComponent();
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaam.Text != "")
            {
                Winkellijst NieuweWinkellijst = new Winkellijst();
                NieuweWinkellijst.Naam = txtNaam.Text;
                NieuweWinkellijst.WinkellijstId = DatabaseOperations.CurrentWinkellijst() + 1 ;
                NieuweWinkellijst.GebruikerId = LogInWindow.instance.gebruiker.GebruikerId;
                int oké = DatabaseOperations.AddWinkellijst(NieuweWinkellijst);
                if (oké <= 0)
                {
                    MessageBox.Show("Het toevoegen van de winkellijst is niet gelukt.");
                }
                else
                {
                    MessageBox.Show("Het toevoegen van de winkellijst is gelukt.");
                    txtNaam.Text = "";

                    WinkellijstWindow.instance.FillWindow();
                    this.Close();
                }
            }       
        }

        private void btnTerugNaarWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            WinkellijstWindow.instance.Show();
            this.Close();
        }

    }
}
