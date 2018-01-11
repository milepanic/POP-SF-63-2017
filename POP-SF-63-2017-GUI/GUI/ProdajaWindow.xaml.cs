using POP_SF_63_2017.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        private Prodaja prodaja;

        public Namestaj IzabraniNamestaj { get; set; }
        public DodatnaUsluga BiranaUsluga { get; set; }

        ObservableCollection<Namestaj> korpaNamestaj = new ObservableCollection<Namestaj>();
        ObservableCollection<DodatnaUsluga> korpaUsluga = new ObservableCollection<DodatnaUsluga>();

        public ProdajaWindow(Prodaja prodaja)
        {
            InitializeComponent();
            this.prodaja = prodaja;

            var countProdaje = Projekat.Instance.Prodaje.Count;

            lbDatum.Content = DateTime.Now;
            lbBrojRacuna.Content = 100000 + countProdaje;

            prikaziNamestaj();

            var listaUsluga = new ObservableCollection<DodatnaUsluga>();
            foreach (var usluga in Projekat.Instance.DodatneUsluge)
            {
                if(usluga.Obrisan != true)
                {
                    listaUsluga.Add(usluga);
                }
            }
            dgUsluge.ItemsSource = listaUsluga;
            dgUsluge.DataContext = this;

            dgUsluge.IsSynchronizedWithCurrentItem = true;
            dgUsluge.CanUserAddRows = false;
            dgUsluge.IsReadOnly = true;

            dgUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
            tbKupac.DataContext = prodaja;
            
            dgKorpa.ItemsSource = korpaNamestaj;
            dgKorpa.DataContext = this;

            dgKorpa.IsSynchronizedWithCurrentItem = true;
            dgKorpa.CanUserAddRows = false;
            dgKorpa.IsReadOnly = true;

            dgKorpa.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            dgIzabraneUsluge.ItemsSource = korpaUsluga;
            dgIzabraneUsluge.DataContext = this;

            dgIzabraneUsluge.IsSynchronizedWithCurrentItem = true;
            dgIzabraneUsluge.CanUserAddRows = false;
            dgIzabraneUsluge.IsReadOnly = true;

            dgIzabraneUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void prikaziNamestaj()
        {
            dgNamestaj.DataContext = null;

            var listaNamestaja = new ObservableCollection<Namestaj>();
            foreach (var namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.Obrisan != true && namestaj.KolicinaUMagacinu > 0)
                {
                    listaNamestaja.Add(namestaj);
                }
            }
            dgNamestaj.ItemsSource = listaNamestaja;
            dgNamestaj.DataContext = this;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.CanUserAddRows = false;
            dgNamestaj.IsReadOnly = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (tbNamestajKolicina.Text == "")
            {
                MessageBox.Show("Niste upisali kolicinu", "Greska", MessageBoxButton.OK);
                return;
            }

            if (IzabraniNamestaj != null)
            {
                try
                {
                    int.Parse(tbNamestajKolicina.Text);
                }
                catch
                {
                    MessageBox.Show("Nije pravilna kolicina", "Greska", MessageBoxButton.OK);
                    return;
                }

                int kolicina = int.Parse(tbNamestajKolicina.Text);

                if (kolicina <= 0)
                {
                    MessageBox.Show("Nije ispravna kolicina", "Greska", MessageBoxButton.OK);
                    return;
                }
                if (kolicina > IzabraniNamestaj.KolicinaUMagacinu)
                {
                    MessageBox.Show("Nema toliko proizvoda na raspolaganju", "Greska", MessageBoxButton.OK);
                    return;
                }
                
                var proizvod = new Korpa()
                {
                    RacunId = prodaja.Id,
                    NamestajId = IzabraniNamestaj.Id,
                    Kolicina = kolicina
                };

                Korpa.Create(proizvod);

                IzabraniNamestaj.ProdataKolicina += kolicina;
                korpaNamestaj.Add(IzabraniNamestaj);

                prodaja.UkupnaCena += (IzabraniNamestaj.Cena * (double)IzabraniNamestaj.Akcija.Popust / 100) * kolicina;
                lbCenaBezPDV.Content = Math.Round(prodaja.UkupnaCena, 2);
                lbUkupnaCena.Content = Math.Round(prodaja.UkupnaCena + prodaja.UkupnaCena * decimal.ToDouble(prodaja.PDV / 100), 2);
                
                foreach(var n in Projekat.Instance.Namestaji)
                {
                    if(n.Id == IzabraniNamestaj.Id)
                    {
                        IzabraniNamestaj.KolicinaUMagacinu -= kolicina;
                        if(IzabraniNamestaj.KolicinaUMagacinu < 1)
                        {
                            prikaziNamestaj();
                        }
                        Namestaj.Update(IzabraniNamestaj);
                    }
                }
            }
        }

        private void btnDodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            if (BiranaUsluga != null)
            {
                foreach (var stavka in korpaUsluga)
                {
                    if (stavka.Id == BiranaUsluga.Id)
                    {
                        MessageBox.Show($"Vec ste dodali tu uslugu", "Greska", MessageBoxButton.OK);
                        return;
                    }
                }

                var usluga = new IzabranaUsluga()
                {
                    RacunId = prodaja.Id,
                    UslugaId = BiranaUsluga.Id
                };

                IzabranaUsluga.Create(usluga);
                
                korpaUsluga.Add(BiranaUsluga);

                prodaja.UkupnaCena += BiranaUsluga.Cena;
                lbCenaBezPDV.Content = Math.Round(prodaja.UkupnaCena, 2);
                lbUkupnaCena.Content = Math.Round(prodaja.UkupnaCena + prodaja.UkupnaCena * decimal.ToDouble(prodaja.PDV / 100), 2);
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            bool racun = false;
            foreach (var stavka in Projekat.Instance.Korpe)
            {
                if (stavka.Obrisan == false && stavka.RacunId == prodaja.Id)
                {
                    racun = true;
                }
            }

            if (racun == false)
            {
                MessageBox.Show("Nije moguce dodati prazan racun", "Greska", MessageBoxButton.OK);
            }

            prodaja.DatumProdaje = DateTime.Now;
            var countProdaje = Projekat.Instance.Prodaje.Count;
            prodaja.BrojRacuna = (countProdaje + 100000).ToString();
            prodaja.UkupnaCena = double.Parse(lbUkupnaCena.Content.ToString());
            Prodaja.Create(prodaja);
            Close();
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Sifra" || e.Column.Header.ToString() == "TipNamestajaId" || e.Column.Header.ToString() == "AkcijaId" || e.Column.Header.ToString() == "Obrisan" || e.Column.Header.ToString() == "ProdataKolicina")
            {
                e.Cancel = true;
            }
        }

        private void dgUsluge_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void dgKorpa_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Sifra" || e.Column.Header.ToString() == "TipNamestajaId" || e.Column.Header.ToString() == "AkcijaId" || e.Column.Header.ToString() == "KolicinaUMagacinu" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void dgIzabraneUsluge_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
