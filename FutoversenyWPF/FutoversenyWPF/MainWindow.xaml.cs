using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FutoversenyWPF
{
    public partial class MainWindow : Window
    {
        List<Versenyzok> versenyzok = new List<Versenyzok>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "szöveges fájl (*.txt)|*.txt";
            if (ofd.ShowDialog() == true)
            {
                versenyzok.Clear();
                lbResztvevok.Items.Clear();
                var sorok = File.ReadAllLines(ofd.FileName, Encoding.Default);
                foreach (var sor in sorok)
                {
                    if (!string.IsNullOrWhiteSpace(sor))
                    {
                        Versenyzok v = new Versenyzok(sor);
                        versenyzok.Add(v);
                        lbResztvevok.Items.Add(v.Nev);
                    }
                }
            }
        }

        private void miEredmeny_Click(object sender, RoutedEventArgs e)
        {
            if (versenyzok.Count > 0)
            {
                EredmenyLista eredmenyWindow = new EredmenyLista(versenyzok);
                eredmenyWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nincs betöltött adat!");
            }
        }

        private void lbResztvevok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbResztvevok.SelectedIndex != -1)
            {
                Versenyzok valasztott = versenyzok[lbResztvevok.SelectedIndex];
                tbxRajtszam.Text = valasztott.Rajtszam.ToString();
                tbxOrszag.Text = valasztott.Orszag;
                tbxIdo.Text = valasztott.Eredmeny.ToString(@"mm\:ss\.ff");
                tbxEletkor.Text = valasztott.Eletkor.ToString();
            }
        }

        private void btnAdat_Click(object sender, RoutedEventArgs e)
        {
            miFile_Click(sender, e);
        }

        private void btnBezar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}