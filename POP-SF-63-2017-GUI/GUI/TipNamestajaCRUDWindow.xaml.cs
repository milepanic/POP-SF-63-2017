using POP_SF_63_2017.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for TipNamestajaCRUDWindow.xaml
    /// </summary>
    public partial class TipNamestajaCRUDWindow : Window
    {
        private ICollectionView view;

        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestajaCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);

            view.Filter = FilterNeobrisanogTipaNamestaja;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            
            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);
        }

        private bool FilterNeobrisanogTipaNamestaja(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var tipNamestajaProzor = new TipNamestajaWindow(prazanTipNamestaja, TipNamestajaWindow.TipOperacije.DODAVANJE);
            tipNamestajaProzor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopijaTipaNamestaja = (TipNamestaja)IzabraniTipNamestaja.Clone();

            var tipNamestajaProzor = new TipNamestajaWindow(kopijaTipaNamestaja, TipNamestajaWindow.TipOperacije.IZMENA);
            tipNamestajaProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
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
                        view.Refresh();
                    }
                }

                TipNamestaja.Delete(tipNamestajaZaBrisanje);
            }
        }

        private void dataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" ||  e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }
    }
}
