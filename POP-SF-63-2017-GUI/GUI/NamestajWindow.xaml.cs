using POP_SF_63_2017.Model;
using System.Windows;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Namestaj namestaj;
        private TipOperacije operacija;

        public NamestajWindow(Namestaj namestaj, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(namestaj, operacija);
        }

        private void InicijalizujPodatke(Namestaj namestaj, TipOperacije operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            // gdje treba da gleda kada bude mijenjao naziv
            tbNaziv.DataContext = namestaj;
            tbSifra.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicinaUMagacinu.DataContext = namestaj;

            //cbAkcija.ItemsSource = Projekat.Instance.Akcije;
            //cbAkcija.DataContext = namestaj;
            

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;
            cbTipNamestaja.DataContext = namestaj;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //cita sa diska listu namjestaja
            var listaNamestaja = Projekat.Instance.Namestaji;

            // uzima objekat tip namjestaja iz dropdown liste
            TipNamestaja izabraniTipNamestaja = (TipNamestaja)cbTipNamestaja.SelectedItem;
            //Akcija izabranaAkcija = (Akcija)cbAkcija.SelectedItem;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Namestaj.Create(namestaj);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.Sifra = namestaj.Sifra;
                            n.Cena = namestaj.Cena;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;
                            //n.AkcijaId = izabranaAkcija.Id;
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                            break;
                        }
                        Namestaj.Update(namestaj);
                    }
                    break;
            }
            Close();
        }
    }
}
