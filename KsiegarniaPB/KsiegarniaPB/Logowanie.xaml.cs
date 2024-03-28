using System;
using System.Collections.Generic;
using System.IO;
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

namespace KsiegarniaPB
{
    /// <summary>
    /// Logika interakcji dla klasy Logowanie.xaml
    /// </summary>
    public partial class Logowanie : Window
    {
        public Logowanie()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy plik Logowanie.txt istnieje
            if (!File.Exists("Logowanie.txt"))
            {
                // Jeżeli plik nie istnieje, utwórz nowy plik
                using (StreamWriter sw = File.CreateText("Logowanie.txt"))
                {
                    sw.WriteLine("Dane logowania:");
                }
            }

            // Otwórz plik Logowanie.txt w trybie append
            using (StreamWriter sw = File.AppendText("Logowanie.txt"))
            {
                // Pobierz dane z pól tekstowych
                string imie = Imie.Text;
                string nazwisko = Nazwisko.Text;
                string haslo = Haslo.Password;

                // Zapisz dane do pliku w formacie "Imię: Imie Nazwisko: Nazwisko Hasło: Haslo"
                sw.WriteLine($"Imię: {imie} Nazwisko: {nazwisko} Hasło: {haslo}");
            }

            // Wyświetl komunikat po zarejestrowaniu
            MessageBox.Show("Zarejestrowano pomyślnie!");
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = Imie.Text + " " + Nazwisko.Text;
            string password = Haslo.Password;

            // Sprawdzenie, czy plik Logowanie.txt istnieje
            if (!File.Exists("Logowanie.txt"))
            {
                MessageBox.Show("Nie można się zalogować, ponieważ nie ma jeszcze żadnych użytkowników.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Sprawdzenie, czy podane dane logowania są prawidłowe
            bool found = false;
            using (StreamReader sr = new StreamReader("Logowanie.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(new string[] { "Imię: ", "Nazwisko: ", "Hasło: " }, StringSplitOptions.RemoveEmptyEntries);
                    string currentLogin = parts[0].Trim() + " " + parts[1].Trim();
                    string currentPassword = parts[2].Trim();
                    if (currentLogin == login && currentPassword == password)
                    {
                        found = true;
                        break;
                    }
                }
            }

            // Wyświetlenie komunikatu
            if (found)
            {
                MessageBox.Show("Zalogowano pomyślnie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędne dane lub hasło!", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Imie_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
