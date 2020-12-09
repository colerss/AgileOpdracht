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
        Product prod;
        public ProductToevoegenWindow()
        {
            InitializeComponent();
            onLoad();
            prod = new Product();
            btnProductAanmaken.Click += btnProductAanmaken_Click;
            
        }
        public ProductToevoegenWindow(Product productImport)
        {
            InitializeComponent();
            onLoad();
            prod = productImport;
            lblWinkellijst.Content = "Product Aanpassen";
            btnProductAanmaken.Content = "Product Aanpassen";
            txtNaam.Text = prod.Naam;
            txtPrijs.Text = prod.Prijs.ToString("F");
            txtGewicht.Text = prod.Hoeveelheid.ToString();
            cbLocatie.SelectedIndex = (int)prod.LocatieId;
            btnProductAanmaken.Click += btnProductUpdaten;

      
        }
        private void onLoad()
        {
            cbLocatie.ItemsSource = DatabaseOperations.GetLocaties();
            cbLocatie.DisplayMemberPath = "LocatieNaam";
        }

        private void SetValuesProduct()
        {
            prod.Naam = txtNaam.Text;
            txtPrijs.Text = txtPrijs.Text.Replace(".", ",");
            if (int.TryParse(txtGewicht.Text, out int gewicht))
            {
                prod.Hoeveelheid = gewicht;
            }
            else
            {
                MessageBox.Show("Geen geldig gewicht");
                return;
            }


            if (decimal.TryParse(txtPrijs.Text, out decimal prijs))
            {
                prod.Prijs = prijs;
            }
            else
            {
                MessageBox.Show("Geen Geldige prijs");
                return;
            }
            prod.Locatie = null;
            prod.LocatieId = ((Locatie)cbLocatie.SelectedItem).LocatieId;
        }
        private void btnProductAanmaken_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtNaam.Text) && !string.IsNullOrWhiteSpace(txtPrijs.Text) && !string.IsNullOrWhiteSpace(txtGewicht.Text) && cbLocatie.SelectedIndex != -1)
            {

                SetValuesProduct();
                prod.ProductId = DatabaseOperations.CurrentProducts() + 1;

                if (DatabaseOperations.AddProduct(prod) <= 0)
                {
                    MessageBox.Show("Het  Product toevoegen is niet gelukt.");
                }
                else
                {
                    MessageBox.Show("Het toevoegen product is gelukt.");
                    txtNaam.Text = "";
                    txtGewicht.Text = "";
                    txtPrijs.Text = "";
                    cbLocatie.SelectedIndex = -1;
                    prod = new Product();
                }
            }
            else
            {
                MessageBox.Show("Een waardeveld is leeg!");
            }
        }

        private void btnProductUpdaten(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtNaam.Text)  && !string.IsNullOrWhiteSpace(txtPrijs.Text)  && !string.IsNullOrWhiteSpace(txtGewicht.Text) && cbLocatie.SelectedIndex != -1)
            {
                SetValuesProduct();
                if (DatabaseOperations.EditProduct(prod) == 0)
                {
                    MessageBox.Show("Er is iets foutgegaan met de aanpassing van het product");
                }
                else
                {
                    MessageBox.Show("Het product is succesvol aangepast");
                }
            }
        }


        private void btnNaarWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            if (WinkellijstWindow.instance == null)
            {
                WinkellijstWindow.instance = new WinkellijstWindow();
            }
            else
            {
                WinkellijstWindow.instance.FillWindow();
            }
            WinkellijstWindow.instance.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Forceerd de verhuilde schermen dicht
            Application.Current.Shutdown();
        }
    }
}
