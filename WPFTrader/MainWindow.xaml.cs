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
using GestionnaireBDD;
using MetierTrader;

namespace WPFTrader
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GstBdd ungstBdd;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ungstBdd = new GstBdd();
            lstTraders.ItemsSource = GstBdd.getAllActionsByTrader();
        }

        private void lstTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstTraders.ItemsSource = null;
            lstTraders.ItemsSource = GstBdd.getAllTraders();
        }

        private void lstActions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstActions.ItemsSource = null;
            lstActions.ItemsSource = GstBdd.getAllActionsByTrader(int numTrader);
        }

        private void btnVendre_Click(object sender, RoutedEventArgs e)
        {
            if (lstTraders.SelectedItem == null)
            {
                MessageBox.Show("Selectionner un trader", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (txtQuantiteVendue.Text == "")
                {
                    MessageBox.Show("Saisissez une quantité", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (lstActions.SelectedItem == null)
                    {
                        MessageBox.Show("Impossible de vendre plus que vous ne possedez", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnAcheter_Click(object sender, RoutedEventArgs e)
        {
            if (lstActionsNonPossedees.SelectedItem == null)
            {
                MessageBox.Show("Selectionner une action a acheter", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
