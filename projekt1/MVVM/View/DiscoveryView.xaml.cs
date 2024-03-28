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
using System.IO;
using System.Threading;

namespace projekt1.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy DiscoveryView.xaml
    /// </summary>
    public partial class DiscoveryView : UserControl
    {
        public DiscoveryView()
        {
            InitializeComponent();
            // Wczytaj dane z pliku txt
            LoadDataFromFile("File.txt");
        }

        private void LoadDataFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines("File.txt"); // Wczytanie linii tekstu z pliku do tablicy string[]
            foreach (string line in lines)
            {
                string[] parts = line.Split(';'); // Podział linii na części na podstawie separatora ';'
                string title = parts[0].Trim(); // Pobranie tytułu potrawy
                string ingredients = parts[1].Trim(); // Pobranie składników potrawy
                string description = parts[2].Trim(); // Pobranie opisu potrawy

                // Dodanie tytułu do comboboxa bez słowa "Tytuł: "
                PrzepisyLista.Items.Add(title);
            }
        }

        private void PrzepisyLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedText = PrzepisyLista.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedText))
            {
                // Odczytanie pełnych informacji o potrawie na podstawie tytułu z pliku txt
                string filePath = "File.txt";
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    string title = parts[0].Trim();
                    string ingredients = parts[1].Trim();
                    string description = parts[2].Trim();

                    if (title == selectedText)
                    {
                        // Wyświetlenie pełnych informacji o potrawie w kontrolce TextBlock
                        string formattedText = $"Składniki:\n {ingredients}\n\nOpis:\n{description}";
                        Przepis.Text = formattedText;
                        break;
                    }
                }
            }
            else
            {
                Przepis.Text = string.Empty;
            }
        }

        private void PrzyciskUsun_Click(object sender, RoutedEventArgs e)
        {
            string selectedText = PrzepisyLista.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedText))
            {
                string filePath = "File.txt";
                List<string> lines = File.ReadAllLines(filePath).ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(';');
                    string title = parts[0].Trim();

                    if (title == selectedText)
                    {
                        lines.RemoveAt(i);
                        File.WriteAllLines(filePath, lines);
                        PrzepisyLista.Items.Remove(selectedText);
                        Przepis.Text = string.Empty;
                        break;
                    }
                }
            }
        }

    }
}
