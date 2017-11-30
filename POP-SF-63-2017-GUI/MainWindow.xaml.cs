using POP_SF_63_2017.Model;
using POP_SF_63_2017_GUI.GUI;
using System.Windows;
using static POP_SF_63_2017_GUI.GUI.KorisnikWindow;

namespace POP_SF_63_2017_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Namestaj IzabraniNamestaj { get; set; }
        public TipNamestaja IzabraniTipNamestaja { get; set; }
        public Korisnik IzabraniKorisnik { get; set; }
        public Salon IzabraniSalon { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // switch po labelu
            switch (header.Content.ToString())
            {
                case "Namestaj":
                    dataGrid.ItemsSource = Projekat.Instance.Namestaji;
                    break;
                case "Tip namestaja":
                    dataGrid.ItemsSource = Projekat.Instance.TipoviNamestaja;
                    break;
                case "Korisnik":
                    dataGrid.ItemsSource = Projekat.Instance.Korisnici;
                    break;
                case "Salon":
                    dataGrid.ItemsSource = Projekat.Instance.Saloni;
                    break;
            }
            dataGrid.ItemsSource = Projekat.Instance.Namestaji;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;
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
                    break;
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            switch (header.Content.ToString())
            {
                case "Namestaj":
                    // obrisan 1 red i promijenjeno u IzabraniNamestaj
                    var namestajProzor = new NamestajWindow(IzabraniNamestaj, NamestajWindow.TipOperacije.IZMENA);
                    namestajProzor.ShowDialog();
                    break;
                case "Tip namestaja":
                    var tipNamestajaProzor = new TipNamestajaWindow(IzabraniTipNamestaja, TipNamestajaWindow.TipOperacije.IZMENA);
                    tipNamestajaProzor.ShowDialog();
                    break;
                case "Korisnik":
                    var korisnikProzor = new KorisnikWindow(IzabraniKorisnik, KorisnikWindow.TipOperacije.IZMENA);
                    korisnikProzor.ShowDialog();
                    break;
                case "Salon":
                    var salonProzor = new SalonWindow(IzabraniSalon, SalonWindow.TipOperacije.IZMENA);
                    salonProzor.ShowDialog();
                    break;
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            switch (header.Content.ToString())
            {
                case "Namestaj":
                    var namestajZaBrisanje = (Namestaj)dataGrid.SelectedItem;
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
                    var tipNamestajaZaBrisanje = (TipNamestaja)dataGrid.SelectedItem;
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
                    var korisnikZabrisanje = (Korisnik)dataGrid.SelectedItem;
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
                         var salonZaBrisanje = (Salon)dataGrid.SelectedItem;
                         if (MessageBox.Show(
                             $"Da li ste sigurni da zelite da obrisete salon: { salonZaBrisanje.Naziv}?",
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
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void namestaj_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Namestaj";
        }

        private void tipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Tip namestaja";
        }

        private void korisnik_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Korisnik";
        }

        private void Salon_Click(object sender, RoutedEventArgs e)
        {
            header.Content = "Salon";
        }
    }
}
