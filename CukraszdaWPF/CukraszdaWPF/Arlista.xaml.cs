using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CukraszdaWPF
{
    public partial class Arlista : Window
    {
        private readonly List<Sutemenyek> _sutemenyek;

        public Arlista(List<Sutemenyek> sutemenyek)
        {
            InitializeComponent();
            _sutemenyek = sutemenyek;
            icArlista.ItemsSource = _sutemenyek;
        }

        private void Rendel_Click(object sender, RoutedEventArgs e)
        {
            var rendelt = _sutemenyek.Where(s => s.Kivalasztva && s.Adag > 0).ToList();

            if (!rendelt.Any())
            {
                MessageBox.Show("Semmi sincs kijelölve vagy nincs adag megadva!", "Hiba");
                return;
            }

            string uzenet = "Rendelés leadva!\n\n";
            int osszeg = 0;

            foreach (var s in rendelt)
            {
                int ar = s.Adag * s.Ar;
                osszeg += ar;
                uzenet += $"{s.Adag} adag {s.Suti} – {ar} Ft\n";
            }

            uzenet += $"\nÖsszesen: {osszeg} Ft";

            MessageBox.Show(uzenet, "Sikeres rendelés");

            
            foreach (var s in _sutemenyek)
            {
                s.Kivalasztva = false;
                s.Adag = 0;
            }
        }
    }
}