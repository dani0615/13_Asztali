using BalatonVizsga;
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

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        public ModifyWindow()
        {
            InitializeComponent();
        }

        public ModifyWindow(Haz telek)
        {
            InitializeComponent();
            tbxTaxNumber.Text = telek.Telekadoszam.ToString();
            tbxStreet.Text = telek.Utcaneve;
            tbxHouseNumber.Text = telek.Hazszam;
            tbxTaxBracket.Text = telek.AdoSav;
            tbxArea.Text = telek.Terulet.ToString();

        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetModify(new Haz(
                int.Parse(tbxTaxNumber.Text),
                tbxStreet.Text,
                tbxHouseNumber.Text,
                tbxTaxBracket.Text,
                int.Parse(tbxArea.Text)
            ));
            this.Close();
        }
    }
}
