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

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

        private Grid PopulatedGrid(SolidColorBrush color)
        {
            ColumnDefinition Col1 = new ColumnDefinition();
            ColumnDefinition Col2 = new ColumnDefinition();
            ColumnDefinition Col3 = new ColumnDefinition();
            ColumnDefinition Col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();

            Col1.Width = new GridLength(1, GridUnitType.Star);
            Col2.Width = new GridLength(1, GridUnitType.Star);
            Col3.Width = new GridLength(1, GridUnitType.Star);
            Col4.Width = new GridLength(1, GridUnitType.Star);
            col5.Width = new GridLength(1, GridUnitType.Star);



            Grid sampleGrid = new Grid();

            System.Windows.Shapes.Rectangle coloredRect = new System.Windows.Shapes.Rectangle();
            Label lblProductnaam = new Label();
            Label lblHoeveelheid = new Label();
            Label lblPrijs = new Label();
            Button btnEdit = new Button();
            Button btnPlus = new Button();
            Button btnDelete = new Button();
            CheckBox cbAangepasteHoeveelheid = new CheckBox();
            TextBox txtHoeveelheid = new TextBox();

            sampleGrid.ColumnDefinitions.Add(Col1);
            sampleGrid.ColumnDefinitions.Add(Col2);
            sampleGrid.ColumnDefinitions.Add(Col3);
            sampleGrid.ColumnDefinitions.Add(Col4);
            sampleGrid.ColumnDefinitions.Add(col5);

            sampleGrid.RowDefinitions.Add(new RowDefinition());
            sampleGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRowSpan(coloredRect, 2);
            Grid.SetColumnSpan(coloredRect, 5);

            Grid.SetRow(lblPrijs, 1);
            Grid.SetRow(txtHoeveelheid, 1);
            Grid.SetRow(btnDelete, 1);
            Grid.SetRow(btnEdit, 1);
            Grid.SetRow(btnPlus, 0);


            Grid.SetColumn(btnPlus, 3);
            Grid.SetColumn(lblProductnaam, 0);
            Grid.SetColumn(lblHoeveelheid, 1);
            Grid.SetColumn(txtHoeveelheid, 2);
            Grid.SetColumn(cbAangepasteHoeveelheid, 2);
            Grid.SetColumn(btnEdit, 3);
            Grid.SetColumn(btnDelete, 4);
            


            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(137, 171, 164);
            coloredRect.Fill = mySolidColorBrush;

           
            lblProductnaam.Content = "Calve Pindakaas";
            lblHoeveelheid.Content = "500g";
            lblPrijs.Content = "€3.50";
            btnPlus.Content = "+";
            btnEdit.Content = "Edit";
            btnDelete.Content = "Delete";
            cbAangepasteHoeveelheid.Content = "Aangepaste hoeveelheid";

            sampleGrid.Children.Add(coloredRect);
            sampleGrid.Children.Add(lblProductnaam);
            sampleGrid.Children.Add(lblHoeveelheid);
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
            btnDelete.BorderBrush = new SolidColorBrush(Colors.Black);
            btnEdit.BorderBrush = new SolidColorBrush(Colors.Black);
            btnEdit.Margin = new Thickness(0, 0, 0, 0);
            btnDelete.Margin = new Thickness(0, 0, 0, 0);

            
           


            return sampleGrid;
        }

        private Border NewBorder(SolidColorBrush color)
        {
            Border borderToAdd = new Border();
            borderToAdd.Child = PopulatedGrid(color);
            borderToAdd.BorderThickness = new Thickness(1);
            borderToAdd.BorderBrush = new SolidColorBrush(Colors.Black);
            return borderToAdd;
        }

        private void LoadElements()
        {
            spArtikellijst.Children.Clear();
            spArtikellijst.Children.Add(NewBorder(new SolidColorBrush(System.Windows.Media.Color.FromRgb(200, 200, 200))));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadElements();
        }

       
    }
}