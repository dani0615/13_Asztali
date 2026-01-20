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
using Microsoft.Win32;
using Nyilvantarto.Models;

namespace Nyilvantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<Auto> autok = new ObservableCollection<Auto>();
        static int index = -1;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            autok.Add(new Auto("Audi", "RS5",2010));
            autok.Add(new Auto("BMW", "M3",2012));
            autok.Add(new Auto("Fiat", "Punto",2000));
            dgrAdatok.ItemsSource = autok;
        }

        private void btnFelvetel_Click(object sender, RoutedEventArgs e)
        {
           AutoSablonWindow asw = new AutoSablonWindow();
            asw.Show();

        }
        public static void AutoFelvitel(Auto ujAuto) 
        {
            autok.Add(ujAuto);
        }

        public static void AutoModositas(Auto modosítottAuto) 
        {
            autok[index] = modosítottAuto;
        }

        private void btnModositas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutoSablonWindow asw = new AutoSablonWindow(autok[dgrAdatok.SelectedIndex],"módosítás");
                index = dgrAdatok.SelectedIndex;
                asw.ShowDialog();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nincs kiválasztva autó a módosításhoz!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    foreach (var auto in autok)
                    {
                        writer.WriteLine($"{auto.Marka};{auto.Tipus};{auto.GyartasiEv}");
                    }
                }
                MessageBox.Show("Az adatok sikeresen mentve!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBetöltés_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    autok.Clear(); 
                    string[] adatok = File.ReadAllLines(ofd.FileName);
                    foreach (string sor in adatok)
                    {
                        string[] adat = sor.Split(';');
                            string marka = adat[0];
                            string tipus = adat[1];
                            if (int.TryParse(adat[2], out int evjarat))
                            {
                                autok.Add(new Auto(marka, tipus, evjarat));
                            }
                            else
                            {
                                MessageBox.Show($"Hibás évjárat formátum: {adat[2]} a sorban: {sor}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                  
                    MessageBox.Show("Az adatok sikeresen betöltve!", "Betöltés", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                    
                catch (IOException ex)
                {
                    MessageBox.Show($"Hiba történt a fájl olvasása közben: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ismeretlen hiba történt: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}