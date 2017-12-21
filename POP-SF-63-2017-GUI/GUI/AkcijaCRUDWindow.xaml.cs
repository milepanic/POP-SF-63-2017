using POP_SF_63_2017.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using POP_SF_63_2017.Utils;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for AkcijaCRUDWindow.xaml
    /// </summary>
    public partial class AkcijaCRUDWindow : Window
    {
        private ICollectionView view;

        public Akcija IzabranaAkcija { get; set; }

        public AkcijaCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcije);

            view.Filter = FilterNeobrisaneAkcije;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;

            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);

        }

        private bool FilterNeobrisaneAkcije(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var praznaAkcija = new Akcija()
            {
                Popust = 0
            };
            var akcijaProzor = new AkcijaWindow(praznaAkcija, AkcijaWindow.TipOperacije.DODAVANJE);
            akcijaProzor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            var akcijaProzor = new AkcijaWindow(IzabranaAkcija, AkcijaWindow.TipOperacije.IZMENA);
            akcijaProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var akcijaZaBrisanje = (Akcija)dataGrid.SelectedItem;
            if (MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete Akciju: { akcijaZaBrisanje.DatumPocetka}?",
                "Brisanje Akcije", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Akcije;

                foreach (var akcija in lista)
                {
                    if (akcija.Id == akcijaZaBrisanje.Id)
                    {
                        akcija.Obrisan = true;
                        view.Refresh();
                    }
                }

                Akcija.Delete(akcijaZaBrisanje);
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
