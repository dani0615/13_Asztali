using Iskola;
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

namespace IskolaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<string> tanulos = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
            lbxTanulok.ItemsSource = tanulos;
        }

        private void LoadFromFile()
        {
            string[] adatok = File.ReadAllLines("nevek.txt");
            foreach (var sor in adatok)
            {
                tanulos.Add(sor);
            }

        }

        private void btnTörlés_Click(object sender, RoutedEventArgs e)
        {
            var kijeloltTanulo = (string)lbxTanulok.SelectedItem;
            if(kijeloltTanulo == null) 
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
                return;
            }
            else
            {
                tanulos.Remove(kijeloltTanulo);
                lbxTanulok.Items.Refresh();
            }

        }

        private void btnAllomanyMentes_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                using (StreamWriter sw = new StreamWriter("nevekNEW.txt"))
                {
                    foreach (var tanulo in tanulos)
                    {
                        sw.WriteLine(tanulo);
                    }
                    MessageBox.Show("Sikeres mentés!");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hiba történt a mentés során: {ex.Message}");
            }
            

        }
    }
}