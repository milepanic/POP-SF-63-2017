using POP_SF_63_2017.Model;
using POP_SF_63_2017_GUI.GUI;
using System.Windows;

namespace POP_SF_63_2017_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaji)
            {
                lbNamestaj.Items.Add(namestaj);
            }

            lbNamestaj.SelectedIndex = 0;
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(prazanNamestaj, NamestajWindow.TipOperacije.DODAVANJE);
            namestajProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnIzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            var namestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.TipOperacije.IZMENA);
            namestajProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void btnObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;

            // ispisati upozorenje

            OsveziPrikaz();
        }
    }
}
