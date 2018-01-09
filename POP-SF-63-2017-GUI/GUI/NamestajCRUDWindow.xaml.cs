using POP_SF_63_2017.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for NamestajCRUDWindow.xaml
    /// </summary>
    public partial class NamestajCRUDWindow : Window
    {
        private ICollectionView view;

        public Namestaj IzabraniNamestaj { get; set; }

        public NamestajCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaji);

            view.Filter = FilterNeobrisanogNamestaja;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;

            // sinhronizuje broj kolona u data gridu (kada izbacimo neke kolone da ne pokazuje praznu)
            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);
        }

        private bool FilterNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(prazanNamestaj, NamestajWindow.TipOperacije.DODAVANJE);
            namestajProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
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
                        // dodato view.r i break

                        namestaj.Obrisan = true;
                        view.Refresh();
                    }
                }
                Namestaj.Delete(namestajZaBrisanje);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Namestaj kopijaNamestaja = (Namestaj)IzabraniNamestaj.Clone();

            var namestajProzor = new NamestajWindow(kopijaNamestaja, NamestajWindow.TipOperacije.IZMENA);
            namestajProzor.ShowDialog();
        }

        // manipulacija izgleda data grida (kolone koje se prikazuju)
        private void dataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "AkcijaId" || e.Column.Header.ToString() == "TipNamestajaId" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
