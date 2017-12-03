using POP_SF_63_2017.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System;
using POP_SF_63_2017.Utils;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaCRUDWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaCRUDWindow : Window
    {
        private ICollectionView view;

        public DodatnaUsluga IzabranaDodatnaUsluga { get; set; }

        public DodatnaUslugaCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatneUsluge);

            view.Filter = FilterNeobrisaneDodatneUsluge;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;

            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);
        }

        private bool FilterNeobrisaneDodatneUsluge(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var praznaDodatnaUsluga = new DodatnaUsluga()
            {
                Naziv = ""
            };
            var dodatnaUslugaProzor = new DodatnaUslugaWindow(praznaDodatnaUsluga, DodatnaUslugaWindow.TipOperacije.DODAVANJE);
            dodatnaUslugaProzor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            var dodatnaUslugaProzor = new DodatnaUslugaWindow(IzabranaDodatnaUsluga, DodatnaUslugaWindow.TipOperacije.IZMENA);
            dodatnaUslugaProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var dodatnaUslugaZaBrisanje = (DodatnaUsluga)dataGrid.SelectedItem;
            if (MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete Dodatnu uslugu: { dodatnaUslugaZaBrisanje.Naziv}?",
                "Brisanje Dodatne usluge", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.DodatneUsluge;

                foreach (var usluga in lista)
                {
                    if (usluga.Id == dodatnaUslugaZaBrisanje.Id)
                    {
                        usluga.Obrisan = true;
                        view.Refresh();
                    }
                }

                GenericSerializer.Serialize("dodatna_usluga.xml", lista);
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
