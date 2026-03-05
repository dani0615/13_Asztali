using celloveszetCLI;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace celloveszetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Lovesz> loveszek = new List<Lovesz>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
            dgrAdatok.ItemsSource = loveszek;
        }

        private void LoadFromFile()
        {
            string[] sorok = File.ReadAllLines("lovesek.csv");
            foreach (string s in sorok)
            {
                loveszek.Add(new Lovesz(s));
            }
        }

        private void btnHozzaad_Click(object sender, RoutedEventArgs e)
        {
            //ertekek ellenorzese
            if (int.Parse(tbxLoves1.Text) < 0 || int.Parse(tbxLoves1.Text) > 99 ||
                int.Parse(tbxLoves2.Text) < 0 || int.Parse(tbxLoves2.Text) > 99 ||
                int.Parse(tbxLoves3.Text) < 0 || int.Parse(tbxLoves3.Text) > 99 ||
                int.Parse(tbxLoves4.Text) < 0 || int.Parse(tbxLoves4.Text) > 99)
            {
                MessageBox.Show("Nem megfelelő értékek");
            }
            else
            {
                loveszek.Add(new Lovesz($"{tbxNev.Text};{tbxLoves1.Text};{tbxLoves2.Text};{tbxLoves3.Text};{tbxLoves4.Text}"));
                dgrAdatok.Items.Refresh();
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("lovesek2.csv"))
            {
                foreach (var item in loveszek)
                {
                    sw.WriteLine($"{item.Nev};{item.ElsoLoves};{item.MasodikLoves};{item.HarmadikLoves};{item.NegyedikLoves}");
                }
                sw.Close();
                MessageBox.Show("A mentés sikeresen megtörtént!");
            }

        }
    }
}