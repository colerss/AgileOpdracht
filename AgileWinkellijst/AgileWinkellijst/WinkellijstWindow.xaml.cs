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
using CredentialManagement;

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for WinkellijstWindow.xaml
    /// </summary>
    public partial class WinkellijstWindow : Window
    {
        public static WinkellijstWindow instance;
        public Winkellijst winkelLijst;
        public double totaalprijs;

        public WinkellijstWindow()
        {
            instance = this;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillWindow();
        }
        #region User Functions
        private Grid PopulatedGrid(SolidColorBrush color, LijstItem lijstitem, int listIndex)
        {
            #region Grid Defininieren
            ColumnDefinition Col1 = new ColumnDefinition();
            ColumnDefinition Col2 = new ColumnDefinition();
            ColumnDefinition Col3 = new ColumnDefinition();
            ColumnDefinition Col4 = new ColumnDefinition();

            Col1.Width = new GridLength(0, GridUnitType.Auto);
            Col2.Width = new GridLength(3, GridUnitType.Star);
            Col3.Width = new GridLength(3, GridUnitType.Star);
            Col4.Width = new GridLength(1.5, GridUnitType.Star);

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
            #endregion
            #region Grid Opmaken
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
            #endregion
            #region Grid Opvullen
            lblAantal.Content = lijstitem.Aantal;
            lblAantal.HorizontalAlignment = HorizontalAlignment.Center;
            lblProductnaam.Content = lijstitem.Product.Naam.ToString();
            lblProductnaam.VerticalAlignment = VerticalAlignment.Center;
            lblPrijs.Content = lijstitem.Product.Prijs.ToString("C");
            // lblVolledigePrijs.Content = volledigeprijs;
            btnEdit.Content = new MaterialDesignThemes.Wpf.PackIcon
            { Kind = MaterialDesignThemes.Wpf.PackIconKind.EditOutline };
            btnDelete.Content = new MaterialDesignThemes.Wpf.PackIcon
            { Kind = MaterialDesignThemes.Wpf.PackIconKind.TrashCan }; ;
            cbAangepasteHoeveelheid.Content = "Aangepaste hoeveelheid";
            #endregion
            #region Childs toevoegen
            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblAantal);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblPrijs);
            sampleGrid.Children.Add(lblVolledigePrijs);
            sampleGrid.Children.Add(txtHoeveelheid);
            sampleGrid.Children.Add(cbAangepasteHoeveelheid);
            sampleGrid.Children.Add(btnDelete);
            sampleGrid.Children.Add(btnEdit);
            #endregion
            #region Childs opmaken
            lblAantal.FontWeight = FontWeights.Bold;
            lblAantal.FontSize = 20;
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
            lblPrijs.FontWeight = FontWeights.Bold;
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
            #endregion
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

        private void LoadElements(List<LijstItem> lijstitems)
        {
            spWinkellijst.Children.Clear();
            decimal totaalprijs = 0;
            foreach (LijstItem lijstitem in lijstitems)
            {
                decimal doubleAantal = Convert.ToDecimal(lijstitem.Aantal);
                spWinkellijst.Children.Add(NewBorder(new SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 200, 200)), lijstitem, spWinkellijst.Children.Count));
                totaalprijs += doubleAantal * lijstitem.Product.Prijs;
            }
            tbTotaal.Text = totaalprijs.ToString("C");
        }
      

        public void FillWindow()
        {
            LoadWinkelLijst();
            LoadElements(DatabaseOperations.GetLijstItems(winkelLijst.WinkellijstId));
        }

        private void LoadWinkelLijst()
        {
            //combobox wordt opgevult, momenteel geven we "1" mee als gebruikersID omdat gebruikers nog niet worden doorgegeven tussen de pagina's

            List<Winkellijst> Winkellijsten = DatabaseOperations.OphalenWinkellijstenByGebruikerId(LogInWindow.instance.gebruiker.GebruikerId);
            cmbWinkellijst.ItemsSource = Winkellijsten;
            if (winkelLijst != null)
            {
                cmbWinkellijst.Text = winkelLijst.Naam;
            }
            else
            {
                cmbWinkellijst.SelectedIndex = 0;
                winkelLijst = Winkellijsten[0];
            }
           

        }
        #endregion
        #region list UI functions
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult MessageBoxResult = (MessageBoxResult)MessageBox.Show("Bent u zeker dat u dit artikel uit uw winkellijst wil verwijderen?", "Verwijder artikel uit winkellijst", MessageBoxButton.YesNo);
            if (MessageBoxResult == System.Windows.MessageBoxResult.Yes)
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
                    LoadElements(DatabaseOperations.GetLijstItems(winkelLijst.WinkellijstId));
                }
            }
            else if (MessageBoxResult == System.Windows.MessageBoxResult.No)
            {
                //do something
            }

               
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //(Button)sender.Tag geeft het geselecteerde product mee
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
                LoadElements(DatabaseOperations.GetLijstItems(winkelLijst.WinkellijstId));
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
        #endregion
        #region UI functions
        private void btnTerugNaarArtikellijst_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.instance == null)
            {
                MainWindow.instance = new MainWindow();
            }
            MainWindow.instance.Show();
            this.Hide();
        }
        private void btnNieuwArtikel_Click(object sender, RoutedEventArgs e)
        {
            Window ProductAdd = new ProductToevoegenWindow();
            ProductAdd.Show();
            this.Hide();
        }
        private void cmbWinkellijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbWinkellijst.SelectedItem != null)
            {
                winkelLijst = (Winkellijst)cmbWinkellijst.SelectedItem;
                //List<LijstItem> lijstitems = DatabaseOperations.OphalenLijstItemViaWinkelLijstItemID(winkelLijst.WinkellijstId);
                LoadElements(DatabaseOperations.GetLijstItems(winkelLijst.WinkellijstId));
                //ik laad de nieuwe lijst nog niet, LoadElements moet waarschijnlijk later aangepast worden zodat het een lijst van LijstItems aanneemt
            }
        }
       
        private void btnNieuweWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            Window WinkellijstToevoegen = new WinkellijstToevoegen();
            WinkellijstToevoegen.Show();
            
           
        }

        private void btnVerwijderWinkellijst_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult MessageBoxResult = (MessageBoxResult)MessageBox.Show("Bent u zeker dat u deze winkellijst wil verwijderen?", "Verwijder winkellijst", MessageBoxButton.YesNo);
            if (MessageBoxResult == System.Windows.MessageBoxResult.Yes)
            {
                
                if (DatabaseOperations.DeleteWinkellijst((Winkellijst)cmbWinkellijst.SelectedItem) != 0)
                {
                    MessageBox.Show("Verwijdering successvol");
                    LoadWinkelLijst();
                    cmbWinkellijst.SelectedIndex = -1;
                    LoadElements(DatabaseOperations.GetLijstItems(winkelLijst.WinkellijstId));

                }
                else
                {
                    MessageBox.Show("Verwijdering gefaald");
                }
            }
            else if (MessageBoxResult == System.Windows.MessageBoxResult.No)
            {
               return;
            }
          
            
            
            
        }
        #endregion
        public struct GridItem
        {
            public LijstItem item;
            public CheckBox cb;
            public TextBox txt;
            public Button btn;
            public int index;
        }
    }
}

