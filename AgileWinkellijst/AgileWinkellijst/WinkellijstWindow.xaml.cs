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
using AgileWinkellijst_DAL;

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

        private Grid PopulatedGrid(SolidColorBrush color, LijstItem lijstitem)
        {
            ColumnDefinition Col1 = new ColumnDefinition();
            ColumnDefinition Col2 = new ColumnDefinition();
            ColumnDefinition Col3 = new ColumnDefinition();
            ColumnDefinition Col4 = new ColumnDefinition();

            Col1.Width = new GridLength(0, GridUnitType.Auto);
            Col2.Width = new GridLength(3, GridUnitType.Star);
            Col3.Width = new GridLength(3, GridUnitType.Star);
            Col4.Width = new GridLength(3, GridUnitType.Star);

            Grid sampleGrid = new Grid();

            System.Windows.Shapes.Rectangle coloredRect = new System.Windows.Shapes.Rectangle();
            Label lblAantal = new Label();
            Label lblProductnaam = new Label();
            Label lblPrijs = new Label();
            Label lblVolledigePrijs = new Label();
            Label lblHoeveelheid = new Label();
            Button btnEdit = new Button();
            Button btnDelete = new Button();

            btnEdit.Tag = lijstitem.LijstItemId;
            btnDelete.Tag = lijstitem.LijstItemId;

            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += btnDelete_Click;

            sampleGrid.ColumnDefinitions.Add(Col1);
            sampleGrid.ColumnDefinitions.Add(Col2);
            sampleGrid.ColumnDefinitions.Add(Col3);
            sampleGrid.ColumnDefinitions.Add(Col4);

            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRowSpan(coloredRect, 2);
            Grid.SetColumnSpan(coloredRect, 4);
            Grid.SetRow(lblAantal, 0);
            Grid.SetRow(lblPrijs, 1);
            

            Grid.SetColumn(lblProductnaam, 1);
            Grid.SetColumn(lblHoeveelheid, 2);
            // Grid.SetColumn(lblVolledigePrijs, 3);
            Grid.SetRow(btnEdit, 0);
            Grid.SetRow(btnDelete, 1);
            Grid.SetColumn(btnEdit, 3);
            Grid.SetColumn(btnDelete, 3);

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(137, 171, 164);
            coloredRect.Fill = mySolidColorBrush;

            lblAantal.Content = lijstitem.Aantal;
            lblProductnaam.Content = lijstitem.Product.Naam.ToString();
            lblPrijs.Content = lijstitem.Product.Prijs;
            // lblVolledigePrijs.Content = volledigeprijs;
            btnEdit.Content = "Edit";
            btnDelete.Content = "Delete";
            lblHoeveelheid.Content = "Aangepaste hoeveelheid";

            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblAantal);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblPrijs);
            sampleGrid.Children.Add(lblVolledigePrijs);
            sampleGrid.Children.Add(lblHoeveelheid);
            sampleGrid.Children.Add(btnDelete);
            sampleGrid.Children.Add(btnEdit);

            lblAantal.FontWeight = FontWeights.SemiBold;
            lblPrijs.FontWeight = FontWeights.SemiBold;
            lblProductnaam.FontWeight = FontWeights.Bold;
            lblHoeveelheid.FontWeight = FontWeights.Bold;


            SolidColorBrush mySolidColorBrush2 = new SolidColorBrush();
            mySolidColorBrush2.Color = Color.FromRgb(112, 128, 144);
            SolidColorBrush mySolidColorBrush3 = new SolidColorBrush();
            mySolidColorBrush3.Color = Color.FromRgb(184, 115, 51);
            btnDelete.Background = mySolidColorBrush3;
            btnDelete.BorderBrush = new SolidColorBrush(Colors.Black);
            btnEdit.Margin = new Thickness(0, 0, 0, 0);
            btnDelete.Margin = new Thickness(0, 0, 0, 0);

            btnEdit.Background = mySolidColorBrush2;
            btnEdit.BorderBrush = new SolidColorBrush(Colors.Black);

            btnEdit.Margin = new Thickness(3);
            btnDelete.Margin = new Thickness(3);
            btnDelete.Padding = new Thickness(0, 0, 0, 0);
            btnEdit.Padding = new Thickness(0, 0, 0, 0);

            return sampleGrid;
        }
        private Border NewBorder(SolidColorBrush color, LijstItem lijstitem)
        {
            Border borderToAdd = new Border();
            borderToAdd.Child = PopulatedGrid(color, lijstitem);
            borderToAdd.BorderThickness = new Thickness(1);
            borderToAdd.BorderBrush = new SolidColorBrush(Colors.Black);
            return borderToAdd;
        }

        private void LoadElements()
        {
            List<LijstItem> lijstitems = DatabaseOperations.GetLijstItems();
            spWinkellijst.Children.Clear();
            foreach (LijstItem lijstitem in lijstitems)
            {
                spWinkellijst.Children.Add(NewBorder(new SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 200, 200)), lijstitem));
            }
        }

        private void btnTerugNaarArtikellijst_Click(object sender, RoutedEventArgs e)
        {
            Window ArtikellijstWindow = new MainWindow();
            ArtikellijstWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadElements();
        }

        private void btnNieuwArtikel_Click(object sender, RoutedEventArgs e)
        {
            Window ProductAdd = new ProductToevoegenWindow();
            ProductAdd.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int LijstItemID = int.Parse(((Button)sender).Tag.ToString());
            LijstItem TeVerwijderenLijstItem = DatabaseOperations.OphalenLijstItemViaLijstItemID(LijstItemID);
            int oké = DatabaseOperations.RemoveLijstItem(TeVerwijderenLijstItem);
            if (oké <= 0)
            {
                MessageBox.Show("Er is iets mis gegaan met het verwijderen van dit artikel uit je winkellijst.");
            }
            else
            {
                LoadElements();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //(Button)sender.Tag geeft het geselecteerde product mee
            int aantal = 5;

        }
    }
}

