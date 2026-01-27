using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace CukraszdaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Sutemenyek> sutik = new List<Sutemenyek>();  

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Szövegfájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*"
            };

            if (opf.ShowDialog() == true)
            {
                sutik.Clear(); 

                foreach (var sor in File.ReadAllLines(opf.FileName, Encoding.UTF8))
                {
                    if (!string.IsNullOrWhiteSpace(sor))
                        sutik.Add(new Sutemenyek(sor));
                }                
                menuSutemenyek.IsEnabled = true;               
                dgrAdat.ItemsSource = sutik;              
            }
        }

        private void menuSutemenyek_Click(object sender, RoutedEventArgs e)
        {
            MegnyitArlista();
        }

        private void MegnyitArlista()
        {
            
            var arlistaAblak = new Arlista(sutik);
            arlistaAblak.Show();
        }

        private void menuNevjegy_Click(object sender, RoutedEventArgs e)
        {
           
            MessageBox.Show("Cukrászda WPF alkalmazás\nVerzió 1.0", "Névjegy");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
