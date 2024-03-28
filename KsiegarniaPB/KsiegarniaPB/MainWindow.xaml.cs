using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KsiegarniaPB
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

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            Dodaj dodajWindow = new Dodaj();
            dodajWindow.Show();
            this.Close();

        }
        private void ZarejestrujButton_Click(object sender, RoutedEventArgs e)
        {
            Logowanie logowanie = new Logowanie();
            logowanie.Show();
            this.Close();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Potwierdzenie zamknięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void SpisButton_Click(Object sender, RoutedEventArgs e)
        {
            Spis spisWindow = new Spis();
            spisWindow.Show();
            this.Close();
        }




    }
}
