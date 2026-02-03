using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CukraszdaWPF
{
    public partial class Arlista : Window
    {
        List<Sutemenyek> sutemenyeks = new List<Sutemenyek>();
        public Arlista()
        {
            InitializeComponent();
        }

        public Arlista(List<Sutemenyek> sutemenyek)
        {
            InitializeComponent();

            this.sutemenyeks = sutemenyek;
            for (int i = 0; i < sutemenyek.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = $"{sutemenyek[i].Suti}({sutemenyek[i].Ar})";
                checkBox.Name = $"cbx{sutemenyek[i].Suti.Replace(" ", "")}";
                checkBox.Margin = new Thickness(30, 10, 0, 10);
                checkBox.Tag = i;

                stpName.Children.Add(checkBox);

                StackPanel stpTemp = new StackPanel();
                stpTemp.Orientation = Orientation.Horizontal;
                TextBox textBox = new TextBox();
                textBox.Name = $"tbx{sutemenyek[i].Suti.Replace(" ", "")}";
                textBox.Width = 50;
                textBox.Margin = new Thickness(0, 10, 15, 7);
                stpTemp.Children.Add(textBox);
                Label label = new Label();
                label.Content = "adag";
                stpTemp.Children.Add(label);

                stpAmount.Children.Add(stpTemp);

            }


        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < stpName.Children.Count; i++)
            {
                if ((stpName.Children[i] as CheckBox).IsChecked == true)
                {
                    int amount = 0;
                    TextBox amountTextBox = (stpAmount.Children[i] as StackPanel).Children[0] as TextBox;
                    if (int.TryParse(amountTextBox.Text, out amount) && amount > 0)
                    {
                        sum += sutemenyeks[i].Ar * amount;
                    }
                }
            }
            MessageBox.Show($"A fizetendő összeg: {sum}");
        }

        private void miBill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.Title = "Save Bill";
                sfd.FileName = "bill.txt"; 

                if (sfd.ShowDialog() == true)
                {
                    string filePath = sfd.FileName;
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        int sum = 0;
                        List<string> sorok = new List<string>();
                        for (int i = 0; i < stpName.Children.Count; i++)
                        {
                            var cb = stpName.Children[i] as CheckBox;
                            if (cb.IsChecked == true)
                            {
                                int amount = 0;
                                var stp = stpAmount.Children[i] as StackPanel;
                                var tbx = stp.Children[0] as TextBox;
                                if (int.TryParse(tbx.Text, out amount) && amount > 0)
                                {
                                    int eredmeny = sutemenyeks[i].Ar * amount;
                                    sum += eredmeny;
                                    sorok.Add($"{sutemenyeks[i].Suti} ({sutemenyeks[i].Ar}) x {amount} = {eredmeny}");
                                }
                            }
                        }
                        if (sorok.Count == 0)
                        {
                            sw.WriteLine("Nincs kiválasztva sütemény.");
                        }
                        else
                        {
                            foreach (var sor in sorok)
                            {
                                sw.WriteLine(sor);
                            }
                            sw.WriteLine($"Összesen: {sum}");
                        }
                    }
                    MessageBox.Show("Számla megírva!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int CurrentAmount(CheckBox? checkBox)
        {
            if (checkBox == null) return 0;
            int index = (int)checkBox.Tag;
            var stp = stpAmount.Children[index] as StackPanel;
            var tbx = stp.Children[0] as TextBox;
            int amount = 0;
            if (int.TryParse(tbx.Text, out amount) && amount > 0)
            {
                return amount;
            }
            return 0;
        }

        //private void Rendel_Click(object sender, RoutedEventArgs e)
        //{
        //    var rendelt = _sutemenyek.Where(s => s.Kivalasztva && s.Adag > 0).ToList();

        //    if (!rendelt.Any())
        //    {
        //        MessageBox.Show("Semmi sincs kijelölve vagy nincs adag megadva!", "Hiba");
        //        return;
        //    }

        //    string uzenet = "Rendelés leadva!\n\n";
        //    int osszeg = 0;

        //    foreach (var s in rendelt)
        //    {
        //        int ar = s.Adag * s.Ar;
        //        osszeg += ar;
        //        uzenet += $"{s.Adag} adag {s.Suti} – {ar} Ft\n";
        //    }

        //    uzenet += $"\nÖsszesen: {osszeg} Ft";

        //    MessageBox.Show(uzenet, "Sikeres rendelés");


        //    foreach (var s in _sutemenyek)
        //    {
        //        s.Kivalasztva = false;
        //        s.Adag = 0;
        //    }
        //}
    }
}