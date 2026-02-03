using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace FutoversenyWPF
{
    public partial class EredmenyLista : Window
    {
        List<Versenyzok> rendezettLista;

        public EredmenyLista(List<Versenyzok> futok)
        {
            InitializeComponent();
            
            
            rendezettLista = futok.OrderByDescending(v => v.Eredmeny).ToList();

            foreach (var v in rendezettLista)
            {
                lbEredmenyLista.Items.Add($"{v.Nev} - {v.Eredmeny.ToString(@"mm\:ss\.ff")}");
            }
        }

        private void miMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("EREDMENYEK.txt"))
                {
                    foreach (var v in rendezettLista)
                    {
                        sw.WriteLine($"{v.Nev};{v.Eredmeny.ToString(@"mm\:ss\.ff")}");
                    }
                }
                MessageBox.Show("Sikeres mentés: EREDMENYEK.txt");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Hiba a mentés során: " + ex.Message);
            }
        }
    }
}
