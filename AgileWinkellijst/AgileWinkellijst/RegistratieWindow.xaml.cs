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
            if (tbEmail.Text != "")
            {
                if (IsValid(tbEmail.Text.ToString()))
                {
                    if (tbWachtwoord.ToString().Length >= 4)
                    {
                        if (tbWachtwoord.ToString() == tbWachtwoordherhalen.ToString())
                        {
                            Gebruiker newUser = new Gebruiker();

                            newUser.Gebruikersnaam = tbEmail.Text;
                            newUser.Wachtwoord = tbWachtwoord.ToString();

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
            else
            {
                MessageBox.Show("Vul een geldig mailadres in.");
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnterug_Click(object sender, RoutedEventArgs e)
        {
            Window Login = new LogInWindow();
            Login.Show();
            this.Close();
        }
    }
}
