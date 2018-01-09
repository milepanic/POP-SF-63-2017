using POP_SF_63_2017.Model;
using System;
using System.Windows;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Korisnik korisnik;
        private TipOperacije operacija;

        public KorisnikWindow(Korisnik korisnik, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(korisnik, operacija);
        }

        private void InicijalizujPodatke(Korisnik korisnik, TipOperacije operacija)
        {
            this.korisnik = korisnik;
            this.operacija = operacija;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika));
            cbTipKorisnika.DataContext = korisnik;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnici;

            var izabraniTipKorisnika = (TipKorisnika)cbTipKorisnika.SelectedItem;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Korisnik.Create(korisnik);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaKorisnika)
                    {
                        if (n.Id == korisnik.Id)
                        {
                            n.Ime = korisnik.Ime;
                            n.Prezime = korisnik.Prezime;
                            n.KorisnickoIme = korisnik.KorisnickoIme;
                            n.Lozinka = korisnik.Lozinka;
                            n.TipKorisnika = izabraniTipKorisnika;
                            break;
                        }
                        Korisnik.Update(korisnik);
                    }
                    break;
            }
            Close();
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
