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
using negyszogCLI;
namespace negyszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Negyszog> negyszogek = new List<Negyszog>();
        public MainWindow()
        {
            InitializeComponent();
            Beolvas();
            dgrNegyszogek.ItemsSource = negyszogek;
        

        }

        private void Beolvas() 
        {
            try
            {
                string[] sorok = File.ReadAllLines("negyszogek.csv");
                foreach(var sor in sorok) 
                {
                    negyszogek.Add(new Negyszog(sor));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt : {ex.Message}");
                
            }
        }
    }
}