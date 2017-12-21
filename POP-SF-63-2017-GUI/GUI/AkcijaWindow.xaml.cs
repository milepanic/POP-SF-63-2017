using POP_SF_63_2017.Model;
using System.Windows;
using System;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Akcija akcija;
        private TipOperacije operacija;

        public AkcijaWindow(Akcija akcija, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(akcija, operacija);
        }

        private void InicijalizujPodatke(Akcija akcija, TipOperacije operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

            dpPocetakAkcije.DataContext = akcija;
            dpZavrsetakAkcije.DataContext = akcija;
            tbPopust.DataContext = akcija;

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcije;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Akcija.Create(akcija);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaAkcija)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.DatumPocetka = akcija.DatumPocetka;
                            n.Popust = akcija.Popust;
                            n.DatumZavrsetka = akcija.DatumZavrsetka;
                            break;
                        }
                        Akcija.Update(akcija);
                    }
                    break;
            }
            Close();
        }
    }
}
