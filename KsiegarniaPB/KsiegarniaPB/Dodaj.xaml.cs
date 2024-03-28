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
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        public Dodaj()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void DodawajButton_Click(object sender, RoutedEventArgs e)
        {
            // pobieranie wartości z TextBoxów
            string autor = Autor.Text;
            string rok = Rok.Text;
            string numer = Numer.Text;
            string ilosc = Ilosc.Text;
            string tytul = Tytul.Text;

            // sprawdzanie czy plik Baza.txt istnieje, a jeśli nie, to tworzenie nowego pliku
            if (!File.Exists("Baza.txt"))
            {
                using (StreamWriter sw = File.CreateText("Baza.txt"))
                {
                    sw.WriteLine("Autor,Rok,Numer,Ilosc");
                }
            }

            // otwieranie pliku Baza.txt do zapisu
            using (StreamWriter sw = new StreamWriter("Baza.txt", true))
            {
                // zapisywanie danych do pliku w formacie: Autor,Rok,Numer,Ilosc
                sw.WriteLine($"Tytuł: {tytul}Autor: {autor}, Rok: {rok}, Numer: {numer}, Ilość: {ilosc}");
            }

            // wyświetlanie komunikatu o pomyślnym zapisaniu danych do pliku
            MessageBox.Show("Pomyślnie zapisano dane do pliku.");

            
        }
        
    }
}
