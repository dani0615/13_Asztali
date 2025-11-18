using Barlangok13b;
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

namespace BarlangokGUI
{
    /// <summary>
    /// Interaction logic for NewCave.xaml
    /// </summary>
    public partial class NewCave : Window
    {
        public NewCave()
        {
            InitializeComponent();
           
        }

       

        public NewCave(string data)
        {
            InitializeComponent();
           
        }

        private void btnMent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                FileStream fs = new FileStream("barlangok.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine($"{tbxAzon.Text};{tbxNev.Text};{tbxHosszusag.Text};{tbxMelyseg.Text};{tbxTelepules.Text};{tbxVedettseg.Text}");
                sw.Close();
                fs.Close();
                MessageBox.Show("Sikeres adatfelvitel","Siker",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
