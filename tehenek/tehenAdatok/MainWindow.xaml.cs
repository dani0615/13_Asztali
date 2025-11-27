using System.IO;
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
using tehenek;

namespace tehenAdatok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Tehen> happycows = new List<Tehen>();
        public MainWindow()
        {
            InitializeComponent();
            Feladat2();
            ComboBoxFill();
        }

        private void ComboBoxFill()
        {
            cbxNapok.Items.Add("Hétfő");
            cbxNapok.Items.Add("Kedd");
            cbxNapok.Items.Add("Szerda");
            cbxNapok.Items.Add("Csütörtök");
            cbxNapok.Items.Add("Péntek");
            cbxNapok.Items.Add("Szombat");
            cbxNapok.Items.Add("Vasárnap");
            cbxNapok.SelectedIndex = 2;
        }

        private void btnKilépes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private static void Feladat2()
        {
            string[] sorok = File.ReadAllLines("hozam.txt");
            foreach (var sor in sorok)
            {
                string id = sor.Split(";")[0];
                string nap = sor.Split(";")[1];
                string mennyiseg = sor.Split(";")[2];

                Tehen aktTehen = new Tehen(id);

                if (!happycows.Contains(aktTehen))
                {
                    happycows.Add(aktTehen);
                }
                int index = happycows.IndexOf(aktTehen);
                happycows[index].EredmenytRogzit(nap, mennyiseg);
            }
        }

        private void sldTejLimit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblBeallitottErtek.Content = $"Beállított érték: {sldTejLimit.Value}";


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sldTejLimit.Minimum = 15;
            sldTejLimit.Maximum = 25;
            sldTejLimit.Value = 20;
            sldTejLimit.TickFrequency = 1;
            sldTejLimit.IsSnapToTickEnabled = true;
            

        }

        private void btnLekerdezes_Click(object sender, RoutedEventArgs e)
        {
            int liter = (int)sldTejLimit.Value;
            string id = tbxAzon.Text;
            int nap = cbxNapok.SelectedIndex;
            Tehen? tehen = happycows.FirstOrDefault(t => t.Id == id);
            if (tehen == null || tehen.Mennyisegek == null || nap < 0 || nap >= tehen.Mennyisegek.Length || tehen.Mennyisegek[nap] == 0) 
            {
                MessageBox.Show("Nem volt fejés", "Eredmény", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int adottMennyiseg = tehen.Mennyisegek[nap];

            if(adottMennyiseg < liter) 
            {
                MessageBox.Show("Az adott napon a mennyiség nem érte el a limitet!", "Eredmény", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
                MessageBox.Show($"A fejés eredménye : {adottMennyiseg}", "Eredmény", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}