using System;
using System.Collections.Generic;
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

namespace Nyilvantarto
{
    /// <summary>
    /// Interaction logic for AutoSablonWindow.xaml
    /// </summary>
    public partial class AutoSablonWindow : Window
    {
        string Kuldo = "";
        public AutoSablonWindow()
        {
            InitializeComponent();
        }

        public AutoSablonWindow(Models.Auto auto) 
        {
            InitializeComponent();
            tbxMarka.Text = auto.Marka;
            tbxTipus.Text = auto.Tipus;
            tbxEvjarat.Text = auto.GyartasiEv.ToString();
        }

        public AutoSablonWindow(Models.Auto auto, string kuldo)
        {
            InitializeComponent();
            tbxMarka.Text = auto.Marka;
            tbxTipus.Text = auto.Tipus;
            tbxEvjarat.Text = auto.GyartasiEv.ToString();
            this.Kuldo = kuldo;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (Kuldo == "módosítás")
            {
                MainWindow.AutoModositas(new Models.Auto(tbxMarka.Text, tbxTipus.Text, int.Parse(tbxEvjarat.Text)));
                MessageBox.Show("Az autó sikeresen módosítva lett.", "Sikeres módosítás", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                MainWindow.AutoFelvitel(new Models.Auto(tbxMarka.Text, tbxTipus.Text, int.Parse(tbxEvjarat.Text)));
                MessageBox.Show("Az autó sikeresen hozzáadva a nyilvántartáshoz.", "Sikeres felvétel", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            
        }
    }
}
