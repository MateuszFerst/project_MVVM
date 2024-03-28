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

namespace projekt1.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy FeaturedView.xaml
    /// </summary>
    public partial class FeaturedView : UserControl
    {
        public FeaturedView()
        {
            InitializeComponent();
        }

        private void DodajPrzepisButton_Click(object sender, RoutedEventArgs e)
        {
            string tytul = TytulTextBox.Text.Trim();
            string skladniki = SkladnikiTextBox.Text.Trim();
            string opis = OpisTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(tytul) && !string.IsNullOrEmpty(skladniki) && !string.IsNullOrEmpty(opis))
            {
                string filePath = "File.txt";
                string newLine = $"{tytul}; {skladniki}; {opis}";
                File.AppendAllText(filePath, newLine + "\n");

                // Wyczyszczenie TextBoxów po dodaniu przepisu
                TytulTextBox.Clear();
                SkladnikiTextBox.Clear();
                OpisTextBox.Clear();

                MessageBox.Show("Przepis został dodany do książki kucharskiej.");
            }
            else
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.");
            }
        }
        private void SkladnikiTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Logika obsługi zmiany tekstu w TextBoxie SkladnikiTextBox
        }

    }
}
