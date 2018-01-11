using POP_SF_63_2017.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for ProdajaRacun.xaml
    /// </summary>
    public partial class ProdajaRacun : Window
    {
        Prodaja prodaja;

        ObservableCollection<Namestaj> kupljeniNamestaj = new ObservableCollection<Namestaj>();
        ObservableCollection<DodatnaUsluga> placenaUsluga = new ObservableCollection<DodatnaUsluga>();

        public ProdajaRacun(Prodaja prodaja)
        {
            InitializeComponent();

            this.prodaja = prodaja;

            lbKupac.Content = prodaja.Kupac;
            lbDatum.Content = prodaja.DatumProdaje;
            lbCena.Content = prodaja.UkupnaCena;

            var listaNamestaja = new ObservableCollection<Namestaj>();
            
            foreach (var namestaj in Projekat.Instance.Korpe)
            {
                if (namestaj.RacunId == prodaja.Id)
                {
                    var n = Namestaj.GetById(namestaj.NamestajId);
                    listaNamestaja.Add(n);
                }
            }
            
            dgNamestaj.ItemsSource = listaNamestaja;
            dgNamestaj.DataContext = this;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.CanUserAddRows = false;
            dgNamestaj.IsReadOnly = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);


            var listaUsluga = new ObservableCollection<DodatnaUsluga>();
            
            foreach (var usluga in Projekat.Instance.Usluge)
            {
                if (usluga.RacunId == prodaja.Id)
                {
                    var u = DodatnaUsluga.GetById(usluga.UslugaId);
                    listaUsluga.Add(u);
                }
            }
            
            dgUsluge.ItemsSource = listaUsluga;
            dgUsluge.DataContext = this;

            dgUsluge.IsSynchronizedWithCurrentItem = true;
            dgUsluge.CanUserAddRows = false;
            dgUsluge.IsReadOnly = true;

            dgUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "TipNamestaja" || e.Column.Header.ToString() == "AkcijaId" || e.Column.Header.ToString() == "TipNamestajaId" || e.Column.Header.ToString() == "Obrisan" || e.Column.Header.ToString() == "Cena" || e.Column.Header.ToString() == "KolicinaUMagacinu")
            {
                e.Cancel = true;
            }
        }

        private void dgUsluge_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
