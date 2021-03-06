﻿using System;
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
            ColumnDefinition Col5 = new ColumnDefinition();

            Col1.Width = new GridLength(0, GridUnitType.Auto);
            Col2.Width = new GridLength(3, GridUnitType.Star);
            Col3.Width = new GridLength(3, GridUnitType.Star);
            Col4.Width = new GridLength(0.5, GridUnitType.Auto);
            Col5.Width = new GridLength(1.5, GridUnitType.Star);

            Grid sampleGrid = new Grid();

            System.Windows.Shapes.Rectangle coloredRect = new System.Windows.Shapes.Rectangle();
            Label lblAantal = new Label();
            Label lblProductnaam = new Label();
            Label lblPrijs = new Label();
            Label lblPrijsTitel = new Label();
            Label lblVolledigePrijs = new Label();

            Button btnDelete = new Button();
            Button btnPlusHoeveelheid = new Button();
            Button btnMinHoeveelheid = new Button();
            

            GridItem gridItem = new GridItem
            {
                item = lijstitem,
                index = listIndex
            };

            btnDelete.Tag = lijstitem.LijstItemId;
            btnMinHoeveelheid.Tag = gridItem;
            btnPlusHoeveelheid.Tag = gridItem;

            btnDelete.Click += btnDelete_Click;
            btnPlusHoeveelheid.Click += BtnHoeveelheidPlus_Click;
            btnMinHoeveelheid.Click += BtnHoeveelheidMin_Click;

            sampleGrid.ColumnDefinitions.Add(Col1);
            sampleGrid.ColumnDefinitions.Add(Col2);
            sampleGrid.ColumnDefinitions.Add(Col3);
            sampleGrid.ColumnDefinitions.Add(Col4);
            sampleGrid.ColumnDefinitions.Add(Col5);

            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());
            #endregion
            #region Grid Opmaken
            Grid.SetRowSpan(coloredRect, 2);
            Grid.SetColumnSpan(coloredRect, 5);

     
            Grid.SetColumn(lblAantal, 2);
            Grid.SetRowSpan(lblAantal, 2);

            Grid.SetRow(lblPrijs, 1);
            Grid.SetRow(lblPrijsTitel, 0);
            Grid.SetRow(lblPrijsTitel, 0);

            Grid.SetColumn(lblProductnaam, 1);
            Grid.SetRowSpan(btnDelete, 2);
            Grid.SetColumn(btnDelete, 4);
            Grid.SetColumn(btnPlusHoeveelheid, 3);
            Grid.SetColumn(btnMinHoeveelheid, 3);
            Grid.SetRow(btnMinHoeveelheid, 1);
            Grid.SetRow(btnPlusHoeveelheid, 0); 

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
            lblAantal.Content = "Aantal : " + lijstitem.Aantal;
            lblAantal.HorizontalAlignment = HorizontalAlignment.Center;
            lblProductnaam.Content = lijstitem.Product.Naam.ToString();
            lblProductnaam.VerticalAlignment = VerticalAlignment.Center;
            lblPrijs.Content = lijstitem.Product.Prijs.ToString("C");
            lblPrijsTitel.Content = "Prijs per stuk :";
            btnDelete.Content = new MaterialDesignThemes.Wpf.PackIcon
            { Kind = MaterialDesignThemes.Wpf.PackIconKind.TrashCan }; ;
            btnPlusHoeveelheid.Content = "+";
            btnMinHoeveelheid.Content = "-";
            #endregion

            #region Childs toevoegen
            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblAantal);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblPrijs);
            sampleGrid.Children.Add(lblVolledigePrijs);
            sampleGrid.Children.Add(btnDelete);
            sampleGrid.Children.Add(btnMinHoeveelheid);
            sampleGrid.Children.Add(btnPlusHoeveelheid);
            sampleGrid.Children.Add(lblPrijsTitel);
            #endregion
            #region Childs opmaken
            lblAantal.FontWeight = FontWeights.Bold;
            lblAantal.FontSize = 15;
            lblAantal.HorizontalAlignment = HorizontalAlignment.Right;
            lblAantal.VerticalAlignment = VerticalAlignment.Center;
            lblProductnaam.Padding = new Thickness(50,0,0,0);

            lblPrijs.FontWeight = FontWeights.SemiBold;
            lblProductnaam.FontWeight = FontWeights.Bold;
            lblPrijsTitel.FontWeight = FontWeights.SemiBold;

            SolidColorBrush mySolidColorBrush2 = new SolidColorBrush();
            mySolidColorBrush2.Color = Color.FromRgb(112, 128, 144);
            SolidColorBrush mySolidColorBrush3 = new SolidColorBrush();
            mySolidColorBrush3.Color = Color.FromRgb(184, 115, 51);
            btnDelete.Background = mySolidColorBrush3;
            btnDelete.BorderBrush = new SolidColorBrush(Colors.Black);
            btnDelete.Margin = new Thickness(0, 0, 0, 0);
            btnMinHoeveelheid.Margin = new Thickness(0, 0, 0, 0);
            btnPlusHoeveelheid.Margin = new Thickness(0, 0, 0, 0);

            SolidColorBrush mySolidColorBrush4 = new SolidColorBrush();
            mySolidColorBrush4.Color = Colors.LightGray;
            lblPrijs.FontWeight = FontWeights.Bold;

            btnPlusHoeveelheid.Background = mySolidColorBrush2;
            btnPlusHoeveelheid.BorderBrush = new SolidColorBrush(Colors.Black);
            btnMinHoeveelheid.Background = mySolidColorBrush2;
            btnMinHoeveelheid.BorderBrush = new SolidColorBrush(Colors.Black);
            
            btnDelete.Margin = new Thickness(3);
            btnDelete.HorizontalAlignment = HorizontalAlignment.Center;
            btnMinHoeveelheid.Margin = new Thickness(6);
            btnMinHoeveelheid.Width = 40;
            btnMinHoeveelheid.HorizontalAlignment = HorizontalAlignment.Left;
            btnPlusHoeveelheid.Margin = new Thickness(6);
            btnPlusHoeveelheid.HorizontalAlignment = HorizontalAlignment.Left;
            btnPlusHoeveelheid.Width = 40;

            btnDelete.Padding = new Thickness(0, 0, 0, 0);
            btnDelete.VerticalAlignment = VerticalAlignment.Center;
            btnDelete.Width = 100;
            btnPlusHoeveelheid.Padding = new Thickness(0, 0, 0, 0);
            btnMinHoeveelheid.Padding = new Thickness(0, 0, 0, 0);
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
            if (Winkellijsten.Count == 0)
            {
                CreateStartList();
                Winkellijsten = DatabaseOperations.OphalenWinkellijstenByGebruikerId(LogInWindow.instance.gebruiker.GebruikerId);
            }
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
        public void CreateStartList()
        {
            Winkellijst NieuweWinkellijst = new Winkellijst();
            NieuweWinkellijst.Naam = "Default List";
            NieuweWinkellijst.WinkellijstId = DatabaseOperations.CurrentWinkellijst() + 1;
            NieuweWinkellijst.GebruikerId = LogInWindow.instance.gebruiker.GebruikerId;
            DatabaseOperations.AddWinkellijst(NieuweWinkellijst);
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

        private void BtnHoeveelheidPlus_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            GridItem gridItem = (GridItem)senderButton.Tag;

            int LijstItemID = gridItem.item.LijstItemId;
            LijstItem TeBewerkenLijstItem = DatabaseOperations.OphalenLijstItemViaLijstItemID(LijstItemID);
            TeBewerkenLijstItem.Aantal++;
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

        private void BtnHoeveelheidMin_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            GridItem gridItem = (GridItem)senderButton.Tag;

            int LijstItemID = gridItem.item.LijstItemId;
            LijstItem TeBewerkenLijstItem = DatabaseOperations.OphalenLijstItemViaLijstItemID(LijstItemID);
            TeBewerkenLijstItem.Aantal--;
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
     
        #endregion
        #region UI functions
        private void btnTerugNaarArtikellijst_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.instance == null)
            {
                MainWindow.instance = new MainWindow();
            }
            else
            {
                MainWindow.instance.DefaultListLoad();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            //Forceerd de verhuilde schermen dicht
            Application.Current.Shutdown();
        }
    }
}

