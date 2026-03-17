using LolCLI_V3;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LolWPF_V3
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Program.Beolvas();
            dgrChampions.ItemsSource = Program.Hosok;
            var kategoriak = Program.Hosok.Select(h => h.Category).Distinct().ToList();
            cbxChampions.ItemsSource = kategoriak;

        }

        private void cbxChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbxChampions.SelectedItem)
            {
                case "Fighter":
                    dgrChampions.ItemsSource = Program.Hosok.Where(h => h.Category == "Fighter");
                    break;
                case "Mage":
                    dgrChampions.ItemsSource = Program.Hosok.Where(h => h.Category == "Mage");
                    break;
                case "Assassin":
                    dgrChampions.ItemsSource = Program.Hosok.Where(h => h.Category == "Assassin");
                    break;
                case "Tank":
                    dgrChampions.ItemsSource = Program.Hosok.Where(h => h.Category == "Tank");
                    break;
                case "Marksman":
                    dgrChampions.ItemsSource = Program.Hosok.Where(h => h.Category == "Marksman");
                    break;
                case"Support":
                    dgrChampions.ItemsSource = Program.Hosok.Where(h => h.Category == "Support");
                    break;  
                default:
                    break;
            }

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbxChampions.SelectedIndex = -1;
            dgrChampions.ItemsSource = Program.Hosok;

        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = "teljes.txt";
                if (cbxChampions.SelectedItem != null)
                {
                    filename = cbxChampions.SelectedItem.ToString()+".txt";
                }
                StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
                foreach (var item in dgrChampions.Items)
                {
                    if (item is Hos Hos) 
                    {
                        sw.WriteLine($"Név: {Hos.Name}, \tPáncél={Hos.Armor}");
                    }
                }
                sw.Close();
                MessageBox.Show("Sikeres mentés");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt :"+ex.Message);
               
            }

        }
    }
}