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

        private Grid PopulatedGrid(SolidColorBrush color, LijstItem lijstitem, int listIndex)
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
            CheckBox cbAangepasteHoeveelheid = new CheckBox();
            TextBox txtHoeveelheid = new TextBox();
            Button btnEdit = new Button();
            Button btnDelete = new Button();

            GridItem gridItem = new GridItem
            {
                txt = txtHoeveelheid,
                cb = cbAangepasteHoeveelheid,
                item = lijstitem,
                index = listIndex
            };

            btnEdit.Tag = gridItem;
            btnDelete.Tag = lijstitem.LijstItemId;
            cbAangepasteHoeveelheid.Tag = gridItem;

            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            cbAangepasteHoeveelheid.Checked += CbSelectionChanged;
            cbAangepasteHoeveelheid.Unchecked += CbSelectionChanged;

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
            Grid.SetRow(txtHoeveelheid, 1);


            Grid.SetColumn(lblProductnaam, 1);
            Grid.SetColumn(cbAangepasteHoeveelheid, 2);
            Grid.SetColumn(txtHoeveelheid, 2);
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
            cbAangepasteHoeveelheid.Content = "Aangepaste hoeveelheid";

            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblAantal);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblPrijs);
            sampleGrid.Children.Add(lblVolledigePrijs);
            sampleGrid.Children.Add(txtHoeveelheid);
            sampleGrid.Children.Add(cbAangepasteHoeveelheid);
            sampleGrid.Children.Add(btnDelete);
            sampleGrid.Children.Add(btnEdit);

            lblAantal.FontWeight = FontWeights.SemiBold;
            lblPrijs.FontWeight = FontWeights.SemiBold;
            lblProductnaam.FontWeight = FontWeights.Bold;
            cbAangepasteHoeveelheid.FontWeight = FontWeights.Bold;


            SolidColorBrush mySolidColorBrush2 = new SolidColorBrush();
            mySolidColorBrush2.Color = Color.FromRgb(112, 128, 144);
            SolidColorBrush mySolidColorBrush3 = new SolidColorBrush();
            mySolidColorBrush3.Color = Color.FromRgb(184, 115, 51);
            btnDelete.Background = mySolidColorBrush3;
            btnDelete.BorderBrush = new SolidColorBrush(Colors.Black);
            btnEdit.Margin = new Thickness(0, 0, 0, 0);
            btnDelete.Margin = new Thickness(0, 0, 0, 0);

            txtHoeveelheid.BorderBrush = new SolidColorBrush(Colors.Black);
            SolidColorBrush mySolidColorBrush4 = new SolidColorBrush();
            mySolidColorBrush4.Color = Colors.LightGray;
            txtHoeveelheid.Background = mySolidColorBrush4;
            txtHoeveelheid.BorderThickness = new Thickness(1);
            txtHoeveelheid.Height = 25;
            txtHoeveelheid.Width = 150;
            txtHoeveelheid.Margin = new Thickness(3);
            txtHoeveelheid.Text = "1";
            txtHoeveelheid.HorizontalAlignment = HorizontalAlignment.Left;
            txtHoeveelheid.Visibility = Visibility.Hidden;

            btnEdit.Background = mySolidColorBrush2;
            btnEdit.BorderBrush = new SolidColorBrush(Colors.Black);

            btnEdit.Margin = new Thickness(3);
            btnDelete.Margin = new Thickness(3);
            btnDelete.Padding = new Thickness(0, 0, 0, 0);
            btnEdit.Padding = new Thickness(0, 0, 0, 0);

            return sampleGrid;
        }
        private Border NewBorder(SolidColorBrush color, LijstItem lijstitem, int listIndex)
        {
            Border borderToAdd = new Border();
            borderToAdd.Child = PopulatedGrid(color, lijstitem, listIndex);
            borderToAdd.BorderThickness = new Thickness(1);
            borderToAdd.BorderBrush = new SolidColorBrush(Colors.Black);
            return borderToAdd;
        }

        private void LoadElements()
        {
            //combobox wordt opgevult, momenteel geven we "1" mee als gebruikersID omdat gebruikers nog niet worden doorgegeven tussen de pagina's
            List<Winkellijst> Winkellijsten = DatabaseOperations.GetWinkellijstenByGebruikerId(0);
            cmbWinkellijst.ItemsSource = Winkellijsten;

            List<LijstItem> lijstitems = DatabaseOperations.GetLijstItems();
            spWinkellijst.Children.Clear();
            foreach (LijstItem lijstitem in lijstitems)
            {
                spWinkellijst.Children.Add(NewBorder(new SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 200, 200)), lijstitem, spWinkellijst.Children.Count));
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
            //Ik werk even met een vast aantal omdat het invullen van aantal nog niet helemaal af is
            Button senderButton = (Button)sender;
            GridItem gridItem = (GridItem)senderButton.Tag;
            int aantal = int.Parse(gridItem.txt.Text);

            int LijstItemID = gridItem.item.LijstItemId;
            LijstItem TeBewerkenLijstItem = DatabaseOperations.OphalenLijstItemViaLijstItemID(LijstItemID);
            TeBewerkenLijstItem.Aantal = aantal;

            int oké = DatabaseOperations.EditLijstItem(TeBewerkenLijstItem);
            if (oké <= 0)
            {
                MessageBox.Show("Er is iets mis gegaan met het aanpassen van dit artikel uit je winkellijst.");
            }
            else
            {
                LoadElements();
            }
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

        private void cmbWinkellijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbWinkellijst.SelectedItem != null)
            {
                Winkellijst geselecteerdeLijst = (Winkellijst)cmbWinkellijst.SelectedItem;
                List<LijstItem> lijstitems = DatabaseOperations.OphalenLijstItemViaWinkelLijstItemID(geselecteerdeLijst.WinkellijstId);
                //ik laad de nieuwe lijst nog niet, LoadElements moet waarschijnlijk later aangepast worden zodat het een lijst van LijstItems aanneemt
            }
        }
        public struct GridItem
        {
            public LijstItem item;
            public CheckBox cb;
            public TextBox txt;
            public Button btn;
            public int index;
        }
        private void btnNieuweWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            Window WinkellijstToevoegen = new WinkellijstToevoegen();
            WinkellijstToevoegen.Show();
            this.Close();
        }

        private void btnVerwijderWinkellijst_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

