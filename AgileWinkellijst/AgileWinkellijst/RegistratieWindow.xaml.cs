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
using System.Net.Mail;
using AgileWinkellijst_DAL;
using System.Text.RegularExpressions;

namespace AgileWinkellijst
{
    /// <summary>
    /// Interaction logic for RegistratieWindow.xaml
    /// </summary>
    public partial class RegistratieWindow : Window
    {
        public RegistratieWindow()
        {
            InitializeComponent();
        }

        private void btnRegistreren_Click(object sender, RoutedEventArgs e)
        {
                if (IsValid(tbEmail.Text.ToString()))
                {
                    if (tbWachtwoord.Password.Length >= 4)
                    {
                        if (tbWachtwoord.Password == tbWachtwoordherhalen.Password)
                        {
                            Gebruiker newUser = new Gebruiker();

                            newUser.GebruikerId = DatabaseOperations.CurrentGebruikers() + 1;
                            newUser.Gebruikersnaam = tbEmail.Text;
                            newUser.Wachtwoord = tbWachtwoord.Password;

                            if (DatabaseOperations.AddGebruiker(newUser) <= 0)
                            {
                                MessageBox.Show("Het aanmaken van een nieuwe gebruiker is niet gelukt.");
                            }
                            else
                            {
                                MessageBox.Show("Deze nieuwe gebruiker is aangemaakt.");

                                Window login = new LogInWindow();
                                login.Show();

                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("De ingegeven wachtwoorden komen niet overeen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Je wachtwoord moet minstens 4 karakters lang zijn.");
                    }
                }
                else
                {
                    MessageBox.Show("Vul een geldig mailadres in.");
                }
        }
        public bool IsValid(string emailaddress)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(emailaddress);
        }



        private void btnterug_Click(object sender, RoutedEventArgs e)
        {
            if (LogInWindow.instance == null)
            {
                Window Login = new LogInWindow();
                Login.Show();
            }
            else
            {
                LogInWindow.instance.Show();
            }
            this.Closed -= Window_Closed;
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Forceerd de verhuilde schermen dicht
            Application.Current.Shutdown();
        }
    }
}
