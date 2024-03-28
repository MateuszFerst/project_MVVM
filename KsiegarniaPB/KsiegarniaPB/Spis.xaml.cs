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
    /// Logika interakcji dla klasy Spis.xaml
    /// </summary>
    public partial class Spis : Window
    {
        public Spis()
        {
            InitializeComponent();
        }
        private void SpisWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // sprawdzenie, czy plik istnieje
            if (File.Exists("Baza.txt"))
            {
                // odczyt zawartości pliku i dodanie jej do ComboBoxa
                string[] lines = File.ReadAllLines("Baza.txt");
                SpisKsiazek.ItemsSource = lines;
            }
            else
            {
                // wyświetlenie komunikatu o błędzie, gdy plik nie istnieje
                MessageBox.Show("Plik Baza.txt nie istnieje.");
            }
        }
       
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
