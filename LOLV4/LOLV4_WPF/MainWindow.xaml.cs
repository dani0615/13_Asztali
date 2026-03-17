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
using LOLV4;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace LOLV4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Hos> EredetiHosok;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Program.Feladat1();
            EredetiHosok = Program.hosok.ToList();
            dgrChampions.ItemsSource = EredetiHosok;

            var propertyIds = new List<string>
            {
                "name",
                "title",
                "category",
                "tag",
                "hp",
                "attackdamage",
                "attackdamageperlevel"
            };

            cbxChampions.ItemsSource = propertyIds;

            
            cbxChampions.SelectionChanged += CbxChampions_SelectionChanged;


        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            
            cbxChampions.SelectedIndex = -1;
            dgrChampions.ItemsSource = EredetiHosok;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "";
            if (cbxChampions.SelectedIndex == -1)
            {
                fileName = "eredeti.txt";

            }
            else
            {
                fileName = cbxChampions.SelectedItem.ToString() + ".txt";
            }
            try
            {
                

                StreamWriter sw = new StreamWriter(fileName);
                foreach (var item in dgrChampions.Items)
                {
                    sw.WriteLine(item.ToString());

                }
                sw.Close();
                MessageBox.Show("Sikeres mentés");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt" + ex.Message);
            }
           

        }

        private void CbxChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxChampions.SelectedItem == null) return;
            string prop = cbxChampions.SelectedItem.ToString();

           
            switch (prop)
            {
                case "name":
                    dgrChampions.ItemsSource=Program.hosok.OrderByDescending(h => h.Name).ToList();
                    break;
                case "title":
                    dgrChampions.ItemsSource = Program.hosok.OrderByDescending(h => h.Title).ToList();
                    break;
                case "category":
                    dgrChampions.ItemsSource = Program.hosok.OrderByDescending(h => h.Category).ToList();
                    break;
                case "tag":
                    dgrChampions.ItemsSource = Program.hosok.OrderByDescending(h => h.Tag).ToList();
                    break;
                case "hp":
                    dgrChampions.ItemsSource = Program.hosok.OrderByDescending(h => h.HP).ToList();
                    break;
                case "attackdamage":
                    dgrChampions.ItemsSource = Program.hosok.OrderByDescending(h => h.AttackDamage).ToList() ;
                    break;
                case "attackdamageperlevel":
                    dgrChampions.ItemsSource = Program.hosok.OrderByDescending(h => h.AttackDamagePerLevel).ToList();
                    break;
                default:
                    dgrChampions.ItemsSource = Program.hosok;
                    break;
            }

        }
    }
}