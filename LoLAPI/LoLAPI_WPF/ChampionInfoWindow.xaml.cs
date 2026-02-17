using LoLAPI.Models;
using System.Windows;

namespace LoLAPI_WPF
{
    public partial class ChampionInfoWindow : Window
    {
        public ChampionInfoWindow(Champion champion)
        {
            InitializeComponent();
            AdatokFeltöltése(champion);
        }

        private void AdatokFeltöltése(Champion champion)
        {
            tbName.Text = champion.Name;
            tbTitle.Text = champion.Title;
            tbAttack.Text = champion.Info.Attack.ToString();
            tbDefense.Text = champion.Info.Defense.ToString();
            tbTags.Text = string.Join(", ", champion.Tags);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
