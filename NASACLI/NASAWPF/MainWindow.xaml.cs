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
using NASACLI;
using System.Linq; // Added for LINQ methods
using System.Collections.Generic; // Added for List<object>

namespace NASAWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool statMod = true; // Initial state matches label "Statisztika" in XAML

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdat_Click(object sender, RoutedEventArgs e)
        {
            statMod = false;
            Program.Beolvas();
            dgrAdat.ItemsSource = Program.kuldetesek.ToList();

        }

        private void dgrAdat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrAdat.SelectedItem is Kuldetes selected)
            {
                pbTeher.Value = selected.HasznosTeher;
                if (statMod)
                {
                    lblAktualis.Content = "Statisztika";
                }
                else
                {
                    lblAktualis.Content = selected.Nev;
                }
            }
        }

        private void btnStat_Click(object sender, RoutedEventArgs e)
        {
            statMod = true;
            lblAktualis.Content = "Statisztika";

            if (Program.kuldetesek.Count == 0) return;

            int emberes = Program.kuldetesek.Count(k => k.Legenyseg > 0);
            int emberNelkuli = Program.kuldetesek.Count(k => k.Legenyseg == 0);
            double atlagKoltseg = Program.kuldetesek.Average(k => k.Koltseg);
            double atlagTeher = Program.kuldetesek.Average(k => k.HasznosTeher);

            var stat = new
            {
                Emberes = emberes,
                EmberNelkuli = emberNelkuli,
                AtlagKoltseg = $"{atlagKoltseg:F2} Mrd USD",
                AtlagTeher = $"{atlagTeher:F2} kg"
            };

            dgrAdat.ItemsSource = new List<object> { stat };
        }
    }
}