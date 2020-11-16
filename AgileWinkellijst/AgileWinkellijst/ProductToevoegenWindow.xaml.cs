using System;
using AgileWinkellijst;
using AgileWinkellijst_DAL;
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
    /// Interaction logic for ProductToevoegenWindow.xaml
    /// </summary>
    public partial class ProductToevoegenWindow : Window
    {
        public ProductToevoegenWindow()
        {
            InitializeComponent();
            onLoad();
        }

        private void onLoad()
        {
            List<Locatie> lstLocaties = DatabaseOperations.GetLocaties();
            List<string> data = lstLocaties.Select(x => x.LocatieNaam).Distinct().ToList();
            cbLocatie.ItemsSource = lstLocaties;
        }

        private void btnProductAanmaken_Click(object sender, RoutedEventArgs e)
        {
            //Product product = new Product();
            //    product.ProductId = DatabaseOperations.CurrentProducts() + 1;
            //    product.Naam = txtNaam.Text;
            //    product.Prijs = int.Parse(txtPrijs.Text);
            //    product.Locatie = (Locatie)cbLocatie.SelectedItem;

            //LijstItem lijstitem = new LijstItem();

            //lijstitem.ProductID = product.ProductId;
            //lijstitem.LijstItemId = DatabaseOperations.CurrentItems() + 1;

            if (txtNaam.Text != "" && txtPrijs.Text != "" && cbLocatie.SelectedItem != null)
            {
                Product NieuwProduct = new Product();
                NieuwProduct.Naam = txtNaam.Text;
                int.TryParse(txtPrijs.Text, out int gewicht);
                NieuwProduct.Hoeveelheid = gewicht;
                decimal.TryParse(txtPrijs.Text, out decimal prijs);
                NieuwProduct.Prijs = prijs;

                int oké = DatabaseOperations.AddProduct(NieuwProduct);
                if (oké <= 0)
                {
                    MessageBox.Show("Het toevoegen Product is niet gelukt.");
                }
                else
                {
                    MessageBox.Show("Het toevoegen product is gelukt.");
                    txtNaam.Text = "";
                    txtPrijs.Text = "";
                    cbLocatie.SelectedIndex = -1;
                }
            }
        }

        private void btnTerugNaarArtikellijst_Click(object sender, RoutedEventArgs e)
        {
            Window Artikellijst = new MainWindow();
            Artikellijst.Show();
            this.Close();
        }

        private void btnNaarWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            Window Winkellijst = new WinkellijstWindow();
            Winkellijst.Show();
            this.Close();
        }
    }
}
