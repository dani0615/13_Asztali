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

namespace SzoKitalalo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> szavak = new List<string>();
        private string titkosSzo;
        private string maszk;
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
            RandomSzoBetoltes();
        }
        private void LoadFromFile()
        {
            foreach (var item in File.ReadAllLines("magyar-szavak.txt"))
            {
                szavak.Add(item);
            }
        }

        private void RandomSzoBetoltes()
        { 
            Random rnd = new Random();
            int index = rnd.Next(0, szavak.Count);
            titkosSzo = szavak[index];

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < titkosSzo.Length; i++)
            {
                sb.Append("_");
                if (i < titkosSzo.Length - 1)
                    sb.Append(" ");
            }
            maszk = sb.ToString();
            tbxKitalalando.Text = maszk;
        }
        private void btnTipp_Click(object sender, RoutedEventArgs e)
        {
            if (tbxBetu.Text.Length != 1)
            {
                MessageBox.Show("Kérem csak egy betűt írjon be!");
                return;
            }

            if (string.IsNullOrEmpty(tbxBetu.Text))
            {
                MessageBox.Show("Kérem írjon be egy betűt!");
                return;
            }
            if (string.IsNullOrEmpty(tbxSorszam.Text))
            {
                MessageBox.Show("Kérem írjon be egy sorszámot!");
                return;
            }

            if (!int.TryParse(tbxSorszam.Text, out int sorszam))
            {
                MessageBox.Show("Kérem érvényes számot adjon meg sorszámnak!");
                return;
            }

            if (sorszam < 1 || sorszam > titkosSzo.Length)
            {
                MessageBox.Show($"Kérem 1 és {titkosSzo.Length} közötti sorszámot adjon meg!");
                return;
            }

            int indexAmaszkban = (sorszam - 1) * 2;

            StringBuilder sb = new StringBuilder(maszk);

            sb[indexAmaszkban] = tbxBetu.Text[0];

            maszk = sb.ToString();

            
            tbxKitalalando.Text = maszk;

            
            tbxSorszam.Text = string.Empty;
            tbxBetu.Text = string.Empty;


        }
    }
}