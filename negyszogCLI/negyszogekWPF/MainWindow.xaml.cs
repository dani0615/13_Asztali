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
using negyszogCLI;
namespace negyszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Negyszog> negyszogek = new ObservableCollection<Negyszog>();

        public MainWindow()
        {
            InitializeComponent();
            Beolvas("negyszogek.csv");
            dgrNegyszogek.ItemsSource = negyszogek;
        

        }

        private void Beolvas(string fileNev) 
        {
            try
            {
                string[] sorok = File.ReadAllLines(fileNev);
                foreach(var sor in sorok) 
                {
                    negyszogek.Add(new Negyszog(sor));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt : {ex.Message}","Hiba", MessageBoxButton.OK , MessageBoxImage.Error);
                
            }
        }

        private void btnHozzad_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbxA.Text) >= int.Parse(tbxA.Text) &&
                int.Parse(tbxB.Text) >= int.Parse(tbxC.Text) &&
                int.Parse(tbxC.Text) >= int.Parse(tbxD.Text))
            {
                Negyszog formData = new Negyszog($"{tbxA.Text} {tbxB.Text} {tbxC.Text} {tbxD.Text}");
                if (formData.LeghosszabbOldal())
                {
                    negyszogek.Add(formData);
                }
                else
                {
                    MessageBox.Show("Nem lehetséges a 4 szakaszból négyszöget szerkeszteni!");
                }
            }
            else
                MessageBox.Show("Nem megfelelő értékek!");
        }
    }
}