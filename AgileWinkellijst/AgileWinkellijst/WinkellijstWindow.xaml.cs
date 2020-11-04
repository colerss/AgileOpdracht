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
        string aantalContent = "1";
        string productnaamContent = "Calve Pindakaas";
        string prijsContent = "€3.50";
        string volledigePrijsContent = "€3.50";
        string editContent = "Aantal aanpassen";
        string deleteContent = "Delete";
        string hoeveelheidContent = "500 g";


        public WinkellijstWindow()
        {
            InitializeComponent();
        }

        private Grid PopulatedGrid(SolidColorBrush color, string aantal, string productnaam, string prijs, string volledigeprijs, string editcontent, string deletecontent)
        {
            ColumnDefinition Col1 = new ColumnDefinition();
            ColumnDefinition Col2 = new ColumnDefinition();
            ColumnDefinition Col3 = new ColumnDefinition();
            ColumnDefinition Col4 = new ColumnDefinition();

            Col1.Width = new GridLength(0, GridUnitType.Auto);
            Col2.Width = new GridLength(1.5, GridUnitType.Star);
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

            sampleGrid.ColumnDefinitions.Add(Col1);
            sampleGrid.ColumnDefinitions.Add(Col2);
            sampleGrid.ColumnDefinitions.Add(Col3);
            sampleGrid.ColumnDefinitions.Add(Col4);

            sampleGrid.RowDefinitions.Add(new RowDefinition());//rijen toevoegen aan grid
            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());
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

            lblAantal.Content = aantal;
            lblProductnaam.Content = productnaam;
            lblPrijs.Content = prijs;
           // lblVolledigePrijs.Content = volledigeprijs;
            btnEdit.Content = editcontent;
            btnDelete.Content = deletecontent;
            lblHoeveelheid.Content = hoeveelheidContent;

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
        private Border NewBorder(SolidColorBrush color)
        {
            Border borderToAdd = new Border();//nieuwe border aanmaken
            borderToAdd.Child = PopulatedGrid(color, aantalContent, productnaamContent, prijsContent, volledigePrijsContent, editContent, deleteContent);
            borderToAdd.BorderThickness = new Thickness(1);
            borderToAdd.BorderBrush = new SolidColorBrush(Colors.Black);
            return borderToAdd;
        }

        private void LoadElements()
        {
            spWinkellijst.Children.Clear();
            spWinkellijst.Children.Add(NewBorder(new SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 200, 200))));
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

     
    }
}

