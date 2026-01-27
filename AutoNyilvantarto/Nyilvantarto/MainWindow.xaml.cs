using Microsoft.Win32;
using Nyilvantarto.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

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
            autok.Add(new Auto("Audi", "RS5", 2010));
            autok.Add(new Auto("BMW", "M3", 2012));
            autok.Add(new Auto("Fiat", "Punto", 2000));
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
                AutoSablonWindow asw = new AutoSablonWindow(autok[dgrAdatok.SelectedIndex], "módosítás");
                index = dgrAdatok.SelectedIndex;
                asw.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
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

            
            sfd.Filter = "Szövegfájl (*.txt)|*.txt|Minden fájl (*.*)|*.*|JSON fájl (*.json)|*.json|XML fájl (*.xml)|*.xml";

            
            sfd.AddExtension = true;
            sfd.DefaultExt = ".txt";
            sfd.FileName = "autok"; 

            if (sfd.ShowDialog() == true)
            {
                try
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1: 
                        case 2: 
                            using (StreamWriter writer = new StreamWriter(sfd.FileName))
                            {
                                foreach (var auto in autok)
                                {
                                    writer.WriteLine($"{auto.Marka};{auto.Tipus};{auto.GyartasiEv}");
                                }
                            }
                            break;

                        case 3: 
                            JsonSerializerOptions options = new JsonSerializerOptions
                            {
                                WriteIndented = true,
                                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                            };

                            string json = JsonSerializer.Serialize(autok, options);
                            File.WriteAllText(sfd.FileName, json);
                            break;

                        case 4: 
                            XmlSerializer serializer = new XmlSerializer(typeof(List<Auto>)); 
                            using (TextWriter writer = new StreamWriter(sfd.FileName))
                            {
                                serializer.Serialize(writer, autok);
                            }
                            break;

                        default:
                            
                            using (StreamWriter writer = new StreamWriter(sfd.FileName))
                            {
                                foreach (var auto in autok)
                                {
                                    writer.WriteLine($"{auto.Marka};{auto.Tipus};{auto.GyartasiEv}");
                                }
                            }
                            break;
                    }

                    MessageBox.Show("Az adatok sikeresen mentve!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"H Hibát történt a mentés során: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBetöltés_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // Ugyanaz a filter, mint a mentésnél
            ofd.Filter = "Szövegfájl (*.txt)|*.txt|Minden fájl (*.*)|*.*|JSON fájl (*.json)|*.json|XML fájl (*.xml)|*.xml";

            if (ofd.ShowDialog() == true)
            {
                try
                {
                    autok.Clear();

                    // FilterIndex alapján döntjük el a formátumot (1-től indul)
                    switch (ofd.FilterIndex)
                    {
                        case 1: // *.txt
                        case 2: // *.* (de txt-ként kezeljük)
                            string[] sorok = File.ReadAllLines(ofd.FileName);
                            foreach (string sor in sorok)
                            {
                                if (string.IsNullOrWhiteSpace(sor))
                                    continue;

                                string[] reszek = sor.Split(';');

                                if (reszek.Length >= 3 &&
                                    int.TryParse(reszek[2].Trim(), out int evjarat))
                                {
                                    string marka = reszek[0].Trim();
                                    string tipus = reszek[1].Trim();
                                    autok.Add(new Auto(marka, tipus, evjarat));
                                }
                                else
                                {
                                    MessageBox.Show($"Hibás sorformátum: {sor}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            break;

                        case 3: // *.json
                            string json = File.ReadAllText(ofd.FileName);

                            JsonSerializerOptions options = new JsonSerializerOptions
                            {
                                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                            };

                            var loaded = JsonSerializer.Deserialize<ObservableCollection<Auto>>(json, options);
                            // vagy List<Auto>, ha autok List
                            if (loaded != null)
                            {
                                foreach (var auto in loaded)
                                {
                                    autok.Add(auto);
                                }
                            }
                            break;

                        case 4: // *.xml
                                // TODO: XML betöltés implementálása
                                // Példa:
                                // XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Auto>));
                                // using (TextReader reader = new StreamReader(ofd.FileName))
                                // {
                                //     var loaded = (ObservableCollection<Auto>)serializer.Deserialize(reader);
                                //     if (loaded != null) autok = loaded; // vagy Add egyesével
                                // }
                            MessageBox.Show("XML betöltés még nincs implementálva.", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;

                        default:
                            // Biztonság kedvéért TXT-ként kezeljük
                            goto case 1;
                    }

                    MessageBox.Show("Az adatok sikeresen betöltve!", "Betöltés", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (JsonException jex)
                {
                    MessageBox.Show($"JSON formátum hiba: {jex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
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
        private void miOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
            {
                btnBetöltés_Click(sender, e);
                e.Handled = true;
            }
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
                e.Handled = true;
            }
        }


        private void miHelp_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://kkszki.hu",
                UseShellExecute = true
            });
        }
    }
}