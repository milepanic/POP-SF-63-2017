using POP_SF_63_2017.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for SalonCRUDWindow.xaml
    /// </summary>
    public partial class SalonCRUDWindow : Window
    {
        private ICollectionView view;

        public Salon IzabraniSalon { get; set; }

        public SalonCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Saloni);

            view.Filter = FilterNeobrisanogSalona;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            
            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);
        }

        private bool FilterNeobrisanogSalona(object obj)
        {
            return ((Salon)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var prazanSalon = new Salon()
            {
                Naziv = ""
            };
            var salonProzor = new SalonWindow(prazanSalon, SalonWindow.TipOperacije.DODAVANJE);
            salonProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
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
                        view.Refresh();
                    }
                }

                Salon.Delete(salonZaBrisanje);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Salon kopijaSalona = (Salon)IzabraniSalon.Clone();

            var salonProzor = new SalonWindow(kopijaSalona, SalonWindow.TipOperacije.IZMENA);
            salonProzor.ShowDialog();
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
