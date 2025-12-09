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
using System.Text.RegularExpressions;

namespace WPF_Regex
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

        public static bool IpCheck(string ip) 
        {
            return Regex.IsMatch(ip, @"^(?!0\d)\d{1,3}(\.(?!0\d)\d{1,3}){3}$");
        }

        private void btnEllenoriz_Click(object sender, RoutedEventArgs e)
        {
            string input = tbxTelefonszám.Text;
            bool helyes = Regex.IsMatch(input, @"^(\+36|06) (20|30|70) \d{3} \d{2} \d{2}$");

            if (helyes)
            {
                MessageBox.Show("Helyes formátum","Figyelmeztetés" , MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Helytelen formátum", "Helytelen" , MessageBoxButton.OKCancel);
            }
        }
    }
}