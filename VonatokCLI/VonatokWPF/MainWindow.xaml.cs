using Microsoft.Win32;
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
using VonatokCLI;

namespace VonatokWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Varakozas> vonatok = new List<Varakozas>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
            cbxVonalszam.ItemsSource = vonatok.Select(v => v.Vonal).Distinct();
        }

        private void LoadFromFile()
        {
            string[] sorok = File.ReadAllLines("varakozas.txt");
            foreach (string sor in sorok.Skip(1))
            {
                vonatok.Add(new Varakozas(sor));
            }
        }

        private void cbxVonalszam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string vonalszam = cbxVonalszam.SelectedItem.ToString();
            var szurtVonatok = vonatok.Where(v => v.Vonal == vonalszam).ToList();
            tbkAdatok.Text = "";
            foreach (Varakozas vonat in szurtVonatok)
            {
                tbkAdatok.Text += vonat.ToString() + "\n";
            }

        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {

            if (cbxVonalszam.SelectedItem != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Szöveges fájl (*.txt)|*.txt";

                saveFileDialog.FileName = cbxVonalszam.SelectedItem.ToString();
                if (saveFileDialog.ShowDialog() == true)
                {
                    string vonalszam = cbxVonalszam.SelectedItem.ToString();
                    var szurtVonatok = vonatok.Where(v => v.Vonal == vonalszam).ToList();
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    foreach (Varakozas vonat in szurtVonatok)
                    {
                        sw.WriteLine($"{vonat.Allomas} állomáson {vonat.Erkezo} felé vár a(z){vonat.Indulo} felől érkező vonatra.");
                    }
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott vonal!");
            }
        }

       
    }
}