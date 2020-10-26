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
  
        private Grid PopulatedGrid(SolidColorBrush color)
        {
            ColumnDefinition Col1 = new ColumnDefinition();
            ColumnDefinition Col2 = new ColumnDefinition();
            ColumnDefinition Col3 = new ColumnDefinition();
            ColumnDefinition Col4 = new ColumnDefinition();
            ColumnDefinition Col5 = new ColumnDefinition();
            ColumnDefinition Col6 = new ColumnDefinition();

            Col1.Width = new GridLength(1, GridUnitType.Star); 
            Col2.Width = new GridLength(7, GridUnitType.Star);
            Col3.Width = new GridLength(3, GridUnitType.Star);
            Col4.Width = new GridLength(3, GridUnitType.Star);
            Col5.Width = new GridLength(1, GridUnitType.Star);
            Col6.Width = new GridLength(1, GridUnitType.Star);

            Grid sampleGrid = new Grid();

            System.Windows.Shapes.Rectangle coloredRect = new System.Windows.Shapes.Rectangle();
            Label lblAantal = new Label();
            Label lblProductnaam = new Label();
            Label lblPrijs = new Label();
            Label lblVolledigePrijs = new Label();
            Button btnEdit = new Button();
            Button btnDelete = new Button();

            sampleGrid.ColumnDefinitions.Add(Col1);
            sampleGrid.ColumnDefinitions.Add(Col2);
            sampleGrid.ColumnDefinitions.Add(Col3);
            sampleGrid.ColumnDefinitions.Add(Col4);
            sampleGrid.ColumnDefinitions.Add(Col5);
            sampleGrid.ColumnDefinitions.Add(Col6);

            sampleGrid.RowDefinitions.Add(new RowDefinition());//rijen toevoegen aan grid
            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRowSpan(coloredRect, 2);
            Grid.SetColumnSpan(coloredRect, 6);
            Grid.SetRow(lblAantal, 0);
            Grid.SetColumn(lblProductnaam, 1);
            Grid.SetColumn(lblPrijs, 2);
            Grid.SetColumn(lblVolledigePrijs, 3);
            Grid.SetColumn(btnEdit, 4);
            Grid.SetColumn(btnDelete, 5);

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(200, 200, 200);
            coloredRect.Fill = mySolidColorBrush;

            lblAantal.Content = "1";
            lblProductnaam.Content = "Calve Pindakaas 500g";
            lblPrijs.Content = "€3.50";
            lblVolledigePrijs.Content = "€3.50";
            btnEdit.Content = "+";
            btnDelete.Content = "D";



            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblAantal);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblPrijs);
            sampleGrid.Children.Add(lblVolledigePrijs);

            sampleGrid.Children.Add(btnDelete);
            sampleGrid.Children.Add(btnEdit);


            SolidColorBrush mySolidColorBrush2 = new SolidColorBrush();
            mySolidColorBrush2.Color = Color.FromRgb(128, 128, 128);
            btnDelete.Background = mySolidColorBrush2;
            btnDelete.BorderBrush = new SolidColorBrush(Colors.Black);
            btnEdit.Margin = new Thickness(0, 0, 0, 0);
            btnDelete.Margin = new Thickness(0, 0, 0, 0);

            btnEdit.Background = mySolidColorBrush2;
            btnEdit.BorderBrush = new SolidColorBrush(Colors.Black);

            btnDelete.Padding= new Thickness(0, 0, 0, 0);
            btnEdit.Padding = new Thickness(0, 0, 0, 0);

            return sampleGrid;
        }
        private Border NewBorder(SolidColorBrush color)
        {
            Border borderToAdd = new Border();//nieuwe border aanmaken
            borderToAdd.Child = PopulatedGrid(color);//Grid in border zetten
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
            Window ArtikellijstWindow = new MainWindow() ;
            ArtikellijstWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadElements();
        }

    }
}
