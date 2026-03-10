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
using hegyekCLI;

namespace hegyekWPF
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

        private void btnHozzad_Click(object sender, RoutedEventArgs e)
        {
            int magassag = int.Parse(tbxMagassag.Text);
            if(magassag>0 && magassag <= 2000) 
            {
                hegycsucs ujHegy = new hegycsucs($"{tbxNev.Text};{tbxHegyseg.Text};{magassag}");
                Program.hegycsucsok.Add(ujHegy);
                dgrHegyek.Items.Refresh();

            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek.");
            }

        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("hegycsucsok2.csv");
                foreach (var item in Program.hegycsucsok)
                {
                    sw.WriteLine($"{item.Nev};{item.Hegyseg};{item.Magassag}");
                    
                }
                sw.Close();
                MessageBox.Show("A mentés sikeresen megtörtént!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Program.Beolvas();
            dgrHegyek.ItemsSource = Program.hegycsucsok;
        }
    }
}