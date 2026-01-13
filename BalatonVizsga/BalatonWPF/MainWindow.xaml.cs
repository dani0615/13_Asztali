using System.IO;
using System.Security.Authentication;
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
using BalatonVizsga;
using Microsoft.Win32.SafeHandles;

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Haz> hazak = new List<Haz>();
        static int index = -1;
        public MainWindow()
        {
            InitializeComponent();
            dgrLista.ItemsSource = hazak;
            Beolvasas();
            cbxAdoSav.Items.Add("A");
            cbxAdoSav.Items.Add("B");
            cbxAdoSav.Items.Add("C");
        }

        public static void SetModify(Haz haz) 
        {
            hazak[index] = haz;
        }

        private void Beolvasas() 
        {
            string[] sorok = File.ReadAllLines("utca.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adat = sorok[i].Split(' ');


                if (adat.Length >= 5)
                {
                    hazak.Add(new Haz(
                        int.Parse(adat[0]),
                        adat[1],
                        adat[2],
                        adat[3],
                        int.Parse(adat[4])
                    ));
                }
            }
        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            
            switch (cbxAdoSav.SelectedIndex)
            {
                case 0:
                    hazak[cbxAdoSav.SelectedIndex].SetAdoSav("A");
                    break;
                case 1:
                    hazak[cbxAdoSav.SelectedIndex].SetAdoSav("B");
                    break;
                case 2:
                    hazak[cbxAdoSav.SelectedIndex].SetAdoSav("C");
                    break;
            }
            dgrLista.Items.Refresh();
        }
        
        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("modositottadok.txt", false, Encoding.UTF8);
                foreach (var haz in hazak)
                {
                    sw.WriteLine($"{haz.Telekadoszam} {haz.Utcaneve} {haz.Hazszam} {haz.AdoSav} {haz.Terulet}");
                }
                sw.Close();
                MessageBox.Show("Sikeres Mentés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            dgrLista.SelectedIndex = index;
            ModifyWindow mfw = new ModifyWindow(hazak[dgrLista.SelectedIndex]);
            mfw.ShowDialog();
        }
    }
}   
    
            
    
