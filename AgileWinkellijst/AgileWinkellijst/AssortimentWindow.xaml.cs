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
using AgileWinkellijst_DAL;
using MaterialDesignColors;

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public List<Locatie> lstLocaties;
        
        public MainWindow()
        {
            InitializeComponent();
            OnLoad();
        }
        
        private void OnLoad()
        {
            List<Locatie> lstLocaties = DatabaseOperations.GetLocaties();
            List<string> data = lstLocaties.Select(x => x.LocatieNaam).Distinct().ToList();
            cbAfdeling.ItemsSource = lstLocaties;
        }

        public List<GridItem> allGridItems = new List<GridItem>();
        private void btnNieuwArtikel_Click(object sender, RoutedEventArgs e)
        {
            Window ProductAdd = new ProductToevoegenWindow();
            ProductAdd.Show();
            this.Close();
        }

        private void btnWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            Window Winkellijst = new WinkellijstWindow();
            Winkellijst.Show();
            this.Close();
        }

        private Grid PopulatedGrid(SolidColorBrush color, Product prod, int listIndex)
        {
        
            #region Grid Element Declarations
            ColumnDefinition Col1 = new ColumnDefinition();
            ColumnDefinition Col2 = new ColumnDefinition();
            ColumnDefinition Col3 = new ColumnDefinition();
            ColumnDefinition Col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();

            Col1.Width = new GridLength(1, GridUnitType.Star);
            Col2.Width = new GridLength(1, GridUnitType.Star);
            Col3.Width = new GridLength(1, GridUnitType.Star);
            Col4.Width = new GridLength(1, GridUnitType.Auto);
            col5.Width = new GridLength(1, GridUnitType.Auto);

          

            Grid sampleGrid = new Grid();

            System.Windows.Shapes.Rectangle coloredRect = new System.Windows.Shapes.Rectangle();
            Label lblProductnaam = new Label();
            Label lblPrijs = new Label();
            Button btnEdit = new Button();
            Button btnPlus = new Button();
            Button btnDelete = new Button();
            CheckBox cbAangepasteHoeveelheid = new CheckBox();
            TextBox txtHoeveelheid = new TextBox();

            GridItem gridItem = new GridItem
            {
                btn = btnPlus,
                txt = txtHoeveelheid,
                cb = cbAangepasteHoeveelheid,
                product = prod,
                index = listIndex
            };
            #endregion

            #region grid function declarations
            btnPlus.Tag = gridItem;
            btnEdit.Tag = gridItem;
            btnDelete.Tag = gridItem;
            cbAangepasteHoeveelheid.Tag = gridItem;
            

            btnPlus.Click += BtnPlus_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            cbAangepasteHoeveelheid.Checked += CbSelectionChanged;
            cbAangepasteHoeveelheid.Unchecked += CbSelectionChanged;
            #endregion

            #region Grid Layout Configuraitons
            sampleGrid.ColumnDefinitions.Add(Col1);
            sampleGrid.ColumnDefinitions.Add(Col2);
            sampleGrid.ColumnDefinitions.Add(Col3);
            sampleGrid.ColumnDefinitions.Add(Col4);
            sampleGrid.ColumnDefinitions.Add(col5);

            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRowSpan(coloredRect, 2);
            Grid.SetColumnSpan(coloredRect, 5);
            Grid.SetColumnSpan(lblProductnaam, 2);

            Grid.SetRow(lblPrijs, 1);
            Grid.SetRow(txtHoeveelheid, 1);
            Grid.SetRow(btnDelete, 1);
            Grid.SetRow(btnEdit, 1);
            Grid.SetRow(btnPlus, 0);

            Grid.SetColumnSpan(btnPlus,2);
            Grid.SetColumn(btnPlus, 3);
            Grid.SetColumn(lblProductnaam, 0);
            Grid.SetColumn(txtHoeveelheid, 2);
            Grid.SetColumn(cbAangepasteHoeveelheid, 2);
            Grid.SetColumn(btnEdit, 3);
            Grid.SetColumn(btnDelete, 4);

            if (listIndex % 2 == 0)
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromRgb(137, 171, 164);
                coloredRect.Fill = mySolidColorBrush;
            }
            else
            {
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromRgb(120, 150, 164);
                coloredRect.Fill = mySolidColorBrush;
            }
            

           
            lblProductnaam.Content = prod.ToString();
            lblPrijs.Content = prod.Prijs.ToString("C");
            btnPlus.Content = new MaterialDesignThemes.Wpf.PackIcon
            { Kind = MaterialDesignThemes.Wpf.PackIconKind.Plus };
            btnEdit.Content = new MaterialDesignThemes.Wpf.PackIcon
            { Kind = MaterialDesignThemes.Wpf.PackIconKind.EditOutline };
            btnDelete.Content = new MaterialDesignThemes.Wpf.PackIcon
            { Kind = MaterialDesignThemes.Wpf.PackIconKind.TrashCan };
            cbAangepasteHoeveelheid.Content = "Aangepaste hoeveelheid";
            
           

            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblPrijs);
            sampleGrid.Children.Add(btnDelete);
            sampleGrid.Children.Add(btnEdit);
            sampleGrid.Children.Add(btnPlus);
            sampleGrid.Children.Add(txtHoeveelheid);
            sampleGrid.Children.Add(cbAangepasteHoeveelheid);

            SolidColorBrush mySolidColorBrush2 = new SolidColorBrush();
            mySolidColorBrush2.Color = Color.FromRgb(112, 128, 144);
            btnDelete.Background = mySolidColorBrush2;
            btnEdit.Background = mySolidColorBrush2;

            SolidColorBrush mySolidColorBrush3 = new SolidColorBrush();
            mySolidColorBrush3.Color = Color.FromRgb(184, 115, 51);
            btnPlus.Background = mySolidColorBrush3;

            btnDelete.BorderBrush = new SolidColorBrush(Colors.Black);
            btnEdit.BorderBrush = new SolidColorBrush(Colors.Black);
            btnPlus.BorderBrush = new SolidColorBrush(Colors.Black);
            btnPlus.Margin = new Thickness(3);
            btnPlus.Width = 200;
            btnEdit.Margin = new Thickness(5);
            btnDelete.Margin = new Thickness(5);

            
            txtHoeveelheid.BorderBrush = new SolidColorBrush(Colors.Black);
            SolidColorBrush mySolidColorBrush4 = new SolidColorBrush();
            mySolidColorBrush4.Color = Colors.LightGray;
            txtHoeveelheid.Background = mySolidColorBrush4;
            txtHoeveelheid.BorderThickness = new Thickness(1);
            txtHoeveelheid.Height = 25;
            txtHoeveelheid.Margin = new Thickness(3);
            txtHoeveelheid.Text = "1";
            txtHoeveelheid.Visibility = Visibility.Hidden;
            
            lblProductnaam.FontWeight = FontWeights.Bold;
            lblProductnaam.FontSize = 15;

            lblPrijs.FontWeight = FontWeights.Bold;
            lblPrijs.FontSize = 16;
            #endregion
            allGridItems.Add(gridItem);
            return sampleGrid;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            GridItem gridItem = (GridItem)((Button)sender).Tag;

            DatabaseOperations.RemoveProduct(gridItem.product);
            List<Product> products = DatabaseOperations.GetAssortimentOrderByAfdeeling();
            LoadElements(products);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            GridItem gridItem = (GridItem)((Button)sender).Tag;

        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
           GridItem gridItem = (GridItem)((Button)sender).Tag;
   

            if ((bool)gridItem.cb.IsChecked)
            {
                if (int.TryParse(gridItem.txt.Text, out int quantity))
                {

                    if (DatabaseOperations.AddLijstItem(
                    new LijstItem
                    {
                        LijstItemId = DatabaseOperations.CurrentListItem() + 1,
                        WinkellijstId = 0,
                        ProductID = gridItem.product.ProductId,
                        Aantal = quantity
                    }
                    ) > 0)
                    {
     
                    }
                    else
                    {
                        MessageBox.Show("error, niet succesvol toegevoegd. Neem contact op met programmeurs");
                    }
                }
                else
                {
                    MessageBox.Show("Geen geldige numerieke waarden!");
                }
                
            }
            else
            {
                if (DatabaseOperations.AddLijstItem(
                  new LijstItem
                  {
                      LijstItemId = DatabaseOperations.CurrentListItem() + 1,
                      WinkellijstId = 0,
                      ProductID = gridItem.product.ProductId,
                      Aantal = 1
                  }
                  ) > 0)
                {
                }
                else
                {
                    MessageBox.Show("error, niet succesvol toegevoegd. Neem contact op met programmeurs");
                }
            }
        }

        private Border NewBorder(SolidColorBrush color, Product prod, int listIndex)
        {
            Border borderToAdd = new Border();
            borderToAdd.Child = PopulatedGrid(color, prod, listIndex);
            borderToAdd.BorderThickness = new Thickness(1);
            borderToAdd.BorderBrush = new SolidColorBrush(Colors.Black);
            return borderToAdd;
        }

        private void LoadElements(List<Product> products)
        {
            
            allGridItems = new List<GridItem>();
            spArtikellijst.Children.Clear();
            foreach (Product prod in products)
            {
                spArtikellijst.Children.Add(NewBorder(new SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 200, 200)), prod, spArtikellijst.Children.Count));
            }
         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Product> products = DatabaseOperations.GetAssortimentOrderByAfdeeling();
            LoadElements(products);
        }

        private void CbSelectionChanged(object sender, RoutedEventArgs e)
        {
            CheckBox senderBox = (CheckBox)sender;
            GridItem gridItem = (GridItem)senderBox.Tag;
            if (gridItem.txt.IsVisible)
            {
                gridItem.txt.Visibility = Visibility.Hidden;
            }
            else
            {
                gridItem.txt.Visibility = Visibility.Visible;
            }
        }

       

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            string searchstring = tbSearch.Text.ToString();
            List<Product> products = new List<Product>();
            if (cbAfdeling.SelectedIndex < 0)
            {
                products = DatabaseOperations.GetAssortimentSearched(searchstring);
            }
            else
            {
                Locatie locatie = (Locatie)cbAfdeling.SelectedItem;
                products = DatabaseOperations.ListProductsByLocationSearched(locatie, searchstring);
            }
            LoadElements(products);     
        }
        private void cbAfdeling_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Locatie locatie = (Locatie)cbAfdeling.SelectedItem;

            List<Product> products = DatabaseOperations.ListProductsByLocation(locatie);
            LoadElements(products);


        }

        public struct GridItem
        {
            public Product product;
            public CheckBox cb;
            public TextBox txt;
            public Button btn;
            public int index;
        }
    }
}