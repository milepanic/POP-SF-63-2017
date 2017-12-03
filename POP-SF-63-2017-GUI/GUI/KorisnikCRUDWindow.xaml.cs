using POP_SF_63_2017.Model;
using POP_SF_63_2017.Utils;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for KorisnikCRUDWindow.xaml
    /// </summary>
    public partial class KorisnikCRUDWindow : Window
    {
        private ICollectionView view;

        public Korisnik IzabraniKorisnik { get; set; }

        public KorisnikCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);

            view.Filter = FilterNeobrisanogKorisnika;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;

            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);
        }

        private bool FilterNeobrisanogKorisnika(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanKorisnik = new Korisnik()
            {
                Ime = ""
            };
            var korisnikProzor = new KorisnikWindow(prazanKorisnik, KorisnikWindow.TipOperacije.DODAVANJE);
            korisnikProzor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            var korisnikProzor = new KorisnikWindow(IzabraniKorisnik, KorisnikWindow.TipOperacije.IZMENA);
            korisnikProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
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
                        view.Refresh();
                    }
                }

                GenericSerializer.Serialize("korisnik.xml", lista);
            }
        }
        private void dataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
