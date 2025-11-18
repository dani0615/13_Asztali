using Barlangok13b;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Serialization;

namespace BarlangokGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static List<Barlang> barlangs = new List<Barlang>();
        private int index = -1; 
        public MainWindow()
        {
            InitializeComponent();
            FileRead();
           
        }

        private void FileRead()
        {
            string[] sorok = File.ReadAllLines("barlangok.txt").Skip(1).ToArray();
            foreach (string sor in sorok)
            {
                barlangs.Add(new Barlang(sor));
            }


        }

      
       private void btnKereses_Click(object sender, RoutedEventArgs e)
        {
            index = -1; 

            if (!int.TryParse(tbxAzon.Text, out int azonosito))
            {
                MessageBox.Show("Érvénytelen azonosító! Kérjük, adjon meg egy számot.");
                tbxAzon.Text = "";
                lblBarlang.Content = "";
                tbxHosszúság.Text = "";
                tbxMelyseg.Text = "";
                btnMentes.IsEnabled = false;
                return;
            }

            bool megtalalt = false;
            for (int i = 0; i < barlangs.Count; i++)
            {
                if (barlangs[i].Azon == azonosito)
                {
                    lblBarlang.Content = barlangs[i].Nev;
                    tbxHosszúság.Text = barlangs[i].Hossz.ToString();
                    tbxMelyseg.Text = barlangs[i].Melyseg.ToString();
                    btnMentes.IsEnabled = true;
                    index = i;          
                    megtalalt = true;
                    break;
                }
            }

            if (!megtalalt)
            {
                MessageBox.Show("Ezzel az azonosítóval nem létezik barlang!");
                tbxAzon.Text = "";
                lblBarlang.Content = "";
                tbxHosszúság.Text = "";
                tbxMelyseg.Text = "";
                btnMentes.IsEnabled = false;
                index = -1;  
            }
        }
        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tbxHosszúság.Text) > barlangs[index].Hossz)
            {
                if (int.Parse(tbxMelyseg.Text) > barlangs[index].Melyseg)
                {
                    barlangs[index].Hossz = int.Parse(tbxHosszúság.Text);
                    barlangs[index].Melyseg = int.Parse(tbxMelyseg.Text);


                }
                else
                {
                    MessageBox.Show("A mélység nem lehet kisebb mint a régi érték!");
                }

            }
            else
            {
                MessageBox.Show("A hosszúság nem lehet kisebb mint a régi érték!");
            }


           


        }

        private void tbxAzon_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void btnMentesAllomany_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("barlangok.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("azon;nev;hossz;melyseg;telepules;vedettseg");
            foreach (var item in barlangs)
            {
                sw.WriteLine($"{item.Azon};{item.Nev};{item.Hossz};{item.Melyseg};{item.Telepules};{item.Vedettseg}");   
            }
            sw.Close();
        }

        private void btnUjElem_Click(object sender, RoutedEventArgs e)
        {
            NewCave nw = new NewCave("Átvitt adat");
            nw.Show();
            //nw.ShowDialog();

        }
    }
}