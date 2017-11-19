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
        }

        private void OsveziPrikaz()
        {
            listBox.Items.Clear();

            switch (header.Content.ToString())
            {
                case "Namestaj":
                    foreach (var namestaj in Projekat.Instance.Namestaji)
                    {
                        if (namestaj.Obrisan == false)
                        {
                            listBox.Items.Add(namestaj);
                        }
                    }
                    break;
                case "Tip namestaja":
                    foreach (var tipNamestaja in Projekat.Instance.TipoviNamestaja)
                    {
                        if (tipNamestaja.Obrisan == false)
                        {
                            listBox.Items.Add(tipNamestaja);
                        }
                    }
                    break;
                case "Korisnik":
                    foreach (var korisnik in Projekat.Instance.Korisnici)
                    {
                        if (korisnik.Obrisan == false)
                        {
                            listBox.Items.Add(korisnik);
                        }
                    }
                    break;
                case "Salon":
                    foreach (var salon in Projekat.Instance.Saloni)
                    {
                        if (salon.Obrisan == false)
                        {
                            listBox.Items.Add(salon);
                        }
                    }
                    break;
                default:
                    break;
            }

            listBox.SelectedIndex = 0;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            switch (header.Content.ToString())
            {
                case "Namestaj":
                    var prazanNamestaj = new Namestaj()
                    {
                        Naziv = ""
                    };
                    var namestajProzor = new NamestajWindow(prazanNamestaj, NamestajWindow.TipOperacije.DODAVANJE);
                    namestajProzor.ShowDialog();
                    break;
                case "Tip namestaja":
                    var prazanTipNamestaja = new TipNamestaja()
                    {
                        Naziv = ""
                    };
                    var tipNamestajaProzor = new TipNamestajaWindow(prazanTipNamestaja, TipNamestajaWindow.TipOperacije.DODAVANJE);
                    tipNamestajaProzor.ShowDialog();
                    break;
                case "Korisnik":
                    var prazanKorisnik = new Korisnik()
                    {
                        Ime = ""
                    };
                    var korisnikProzor = new KorisnikWindow(prazanKorisnik, KorisnikWindow.TipOperacije.DODAVANJE);
                    korisnikProzor.ShowDialog();
                    break;
                case "Salon":
                    var prazanSalon = new Salon()
                    {
                        Naziv = ""
                    };
                    var salonProzor = new SalonWindow(prazanSalon, SalonWindow.TipOperacije.DODAVANJE);
                    salonProzor.ShowDialog();
                default:
                    break;
            }

            OsveziPrikaz();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            switch (header.Content.ToString())
            {
                case "Namestaj":
                    var izabraniNamestaj = (Namestaj)listBox.SelectedItem;

                    var namestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.TipOperacije.IZMENA);
                    namestajProzor.ShowDialog();
                    break;
                case "Tip namestaja":
                    var izabraniTipNamestaja = (TipNamestaja)listBox.SelectedItem;

                    var tipNamestajaProzor = new TipNamestajaWindow(izabraniTipNamestaja, TipNamestajaWindow.TipOperacije.IZMENA);
                    tipNamestajaProzor.ShowDialog();
                    break;
                case "Korisnik":
                    var izabraniTipKorisnika = (Korisnik)listBox.SelectedItem;

                    var korisnikProzor = new KorisnikWindow(izabraniTipKorisnika, KorisnikWindow.TipOperacije.IZMENA);
                    break;
                case "Salon":
                    var izabraniSalon = (Salon)listBox.SelectedItem;

                    var salonProzor = new SalonWindow(izabraniSalon, SalonWindow.TipOperacije.IZMENA);
                    break;
                default:
                    break;
            }

            OsveziPrikaz();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            switch (header.Content.ToString())
            {
                case "Namestaj":
                    var namestajZaBrisanje = (Namestaj)listBox.SelectedItem;
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
                    }
                    break;
                case "Tip namestaja":
                    var tipNamestajaZaBrisanje = (TipNamestaja)listBox.SelectedItem;
                    if (MessageBox.Show(
                        $"Da li ste sigurni da zelite da obristete namestaj: { tipNamestajaZaBrisanje.Naziv }?",
                        "Brisanje tipa namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var lista = Projekat.Instance.TipoviNamestaja;

                        foreach (var tip in lista)
                        {
                            if (tip.Id == tipNamestajaZaBrisanje.Id)
                            {
                                tip.Obrisan = true;
                            }
                        }

                        Projekat.Instance.TipoviNamestaja = lista;
                    }
                    break;
                case "Korisnik":
                    var korisnikZabrisanje = (Korisnik)listBox.SelectedItem;
                    if (MessageBox.Show(
                        $"Da li ste sigurni da zelite da obrisete korisnika: { korisnikZabrisanje.Ime} { korisnikZabrisanje.Prezime }?",
                        "Brisanje korisnika", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var lista = Projekat.Instance.Korisnici;

                        foreach (var korisnik in lista)
                        {
                            if (korisnik.Id == korisnikZabrisanje.Id)
                            {
                                korisnik.Obrisan = true;
                            }
                        }

                        Projekat.Instance.Korisnici = lista;
                    }
                    break;
                case "Salon":
                    var salonZaBrisanje = (Salon)listBox.SelectedItem;
                    if (MessageBox.Show(
                        $"Da li ste sigurni da zelite da obrisete salon: { Salon.Naziv}?",
                        "Brisanje salona", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var lista = Projekat.Instance.Saloni;

                        foreach (var salon in lista)
                        {
                            if (salon.Id == salonZaBrisanje.Id)
                            {
                                salon.Obrisan = true;
                            }
                        }

                        Projekat.Instance.Saloni = lista;
                    }
                    break;
                default:
                    break;
            }

            OsveziPrikaz();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void namestaj_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Namestaj";
            OsveziPrikaz();
        }

        private void tipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Tip namestaja";
            OsveziPrikaz();
        }

        private void korisnik_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Korisnik";
            OsveziPrikaz();
        }

        private void Salon_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Salon";
            OsveziPrikaz();
        }
    }
}
