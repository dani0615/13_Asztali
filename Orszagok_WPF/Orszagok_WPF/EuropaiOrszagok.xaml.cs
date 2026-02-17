using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Orszagok_WPF
{
    /// <summary>
    /// Interaction logic for EuropaiOrszagok.xaml
    /// </summary>
    public partial class EuropaiOrszagok : Window
    {

        public EuropaiOrszagok()
        {
            InitializeComponent();
        }




        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            var europaiOrszagok = MainWindow.orszagok.Where(o => o.Kontinens == "Európa").ToList();
            dgrEuropai.ItemsSource = europaiOrszagok;
        }

        private void FileMentes_Click(object sender, RoutedEventArgs e)
        {
           
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Szöveges fájl(*.txt)|*.txt";
            saveFileDialog.FileName = "Európaiak.txt";


            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    foreach (var orszag in MainWindow.orszagok.Where(o => o.Kontinens == "Európa"))
                    {
                        sw.WriteLine(orszag.Orszagnev);
                        sw.WriteLine(orszag.Nepesseg);
                        sw.WriteLine(orszag.Kontinens);
                    }
                }
                MessageBox.Show("Sikeres mentés!");







            }
        }
    }
}

    

