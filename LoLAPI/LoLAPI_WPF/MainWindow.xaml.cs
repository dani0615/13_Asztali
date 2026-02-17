using LoLAPI;
using LoLAPI.Models;
using System.Windows;
using System.Windows.Controls;

namespace LoLAPI_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Program.LoadLanguages();
            LanguageComboBox.ItemsSource = Program.languages;


            if (Program.languages.Contains("hu_HU"))
            {
                LanguageComboBox.SelectedItem = "hu_HU";
            }
            else if (Program.languages.Count > 0)
            {
                LanguageComboBox.SelectedIndex = 0;
            }
        }

        private async void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is string selectedLanguage)
            {
                await Program.LoadChampions(selectedLanguage);
                lbxChampions.ItemsSource = null;
                lbxChampions.ItemsSource = Program.champions;
            }
        }

        private void ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            if (lbxChampions.SelectedItem is Champion selectedChampion)
            {
                ChampionInfoWindow infoWindow = new ChampionInfoWindow(selectedChampion);
                infoWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Válassz ki egy championt előszőr!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}