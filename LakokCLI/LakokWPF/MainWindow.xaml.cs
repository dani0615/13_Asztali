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
using LakokCLI;

namespace LakokWPF
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
            Program.loadFromFile();
            dgrAdatok.ItemsSource = Program.lakasok;

        }

        private void saveToFile()
        {
            using (StreamWriter sw = new StreamWriter("lakok.csv", false, Encoding.UTF8))
            {
                sw.WriteLine("Város, Cím,Lakók száma,Lakók neve,Lakás mérete,Tartozás");
                foreach (var l in Program.lakasok)
                {
                    sw.WriteLine($"{l.cim},{l.lakokSzama},{l.lakokNeve},{l.terulet},{l.tartozas}");
                }
            }
        }

        private void btnBevitel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nev = tbxNev.Text;
                string cim = tbxCim.Text;
                int lakokSzama = int.Parse(tbxLakokSzama.Text);
                int alapterulet = int.Parse(tbxAlapterulet.Text);

                Lakas uj = new Lakas(cim, lakokSzama, nev, alapterulet, 0);
                Program.lakasok.Add(uj);
                saveToFile();
                dgrAdatok.Items.Refresh();


                tbxNev.Clear();
                tbxCim.Clear();
                tbxLakokSzama.Clear();
                tbxAlapterulet.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a bevitel során! Kérem ellenőrizze az adatokat. " + ex.Message);
            }
        }

        private void btnKiegyenlit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrAdatok.SelectedItem is Lakas kijelolt)
            {
                kijelolt.Kiegyenlit();
                saveToFile();
                dgrAdatok.Items.Refresh();
                MessageBox.Show("Tartozás kiegyenlítve!");
            }
            else
            {
                MessageBox.Show("Kérem válasszon ki egy lakást a listából!");
            }
        }
    }
}