using POP_SF_63_2017.Model;
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

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for NamestajCRUD.xaml
    /// </summary>
    public partial class NamestajCRUD : Window
    {
        public NamestajCRUD()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.Obrisan == false)
                {
                    lbNamestaj.Items.Add(namestaj);
                }
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

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var namestajZaBrisanje = (Namestaj)lbNamestaj.SelectedItem;
            if (MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete namestaj: { namestajZaBrisanje.Naziv }?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Namestaji;

                foreach (var namestaj in lista)
                {
                    if (namestaj.Id == namestajZaBrisanje.Id)
                    {
                        namestaj.Obrisan = true;
                    }
                }

                Projekat.Instance.Namestaji = lista;
                OsveziPrikaz();
            }
        }
    }
}
