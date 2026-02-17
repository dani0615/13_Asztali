using Microsoft.Win32;
using System.Collections.ObjectModel;
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

namespace Orszagok_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static ObservableCollection<Orszag> orszagok = new ObservableCollection<Orszag>();
       
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Megnyitas_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string orszagnev = line;
                        int nepesseg = int.Parse(sr.ReadLine());
                        string kontinens = sr.ReadLine();
                        Orszag orszag = new Orszag(orszagnev, nepesseg, kontinens);
                        orszagok.Add(orszag);
                    }
                }
                MessageBox.Show($"Sikeres megnyitás! {orszagok.Count}");
                dgrOsszesOrszag.ItemsSource = orszagok;

               

            }
        }


        private void EuropaiWindow_Click(object sender, RoutedEventArgs e)
        {
            EuropaiOrszagok europaiOrszagok = new EuropaiOrszagok();
            europaiOrszagok.Show();
        }

        private void btnmegszamol_Click(object sender, RoutedEventArgs e)
        {
            int dbSzam = 0;
            if (rbtn10Milliotobb.IsChecked == true)
            {
                foreach (var orszag in orszagok)
                {
                    if (orszag.Nepesseg > 10000000)
                    {
                        dbSzam++;
                    }
                }

            }
            else if (rbtnMax10Miliio.IsChecked == true)
            {
                foreach (var orszag in orszagok)
                {
                    if (orszag.Nepesseg <= 1000000)
                    {
                        dbSzam++;
                    }
                }
            }
            tbxLakossag.Text = dbSzam.ToString();
        }

        private void btnAtlagNepesseg_Click(object sender, RoutedEventArgs e)
        {
            int osszNepesseg = 0;
            foreach (var orszag in orszagok)
            {
                osszNepesseg += orszag.Nepesseg;
            }
            double atlag = (double)osszNepesseg / orszagok.Count;
            MessageBox.Show($"Az országok átlagos népessége: " + atlag.ToString("F2"));
        }

        private void btnKilepés_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        

        private void btnkiirat_Click(object sender, RoutedEventArgs e)
        {
            cbxOrszagKivalasztas.Items.Clear();
            string legnagyobbOrszag = orszagok.OrderByDescending(o => o.Nepesseg).First().Orszagnev;
            string legkisebbOrszag = orszagok.OrderBy(o => o.Nepesseg).First().Orszagnev;

            cbxOrszagKivalasztas.Items.Add(legkisebbOrszag);
            cbxOrszagKivalasztas.Items.Add(legnagyobbOrszag);

            if (cbxOrszagKivalasztas.SelectedIndex == 0)
            {
                MessageBox.Show($"A legkisebb ország: {legkisebbOrszag}");
            }
            else if (cbxOrszagKivalasztas.SelectedIndex == 1)
            {
                MessageBox.Show($"A legnagyobb ország: {legnagyobbOrszag}");
            }
        }
    }
}
