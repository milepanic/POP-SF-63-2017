using POP_SF_63_2017.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for ProdajaCRUDWindow.xaml
    /// </summary>
    public partial class ProdajaCRUDWindow : Window
    {
        private ICollectionView view;

        public Prodaja IzabranaProdaja { get; set; }

        public ProdajaCRUDWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Prodaje);

            view.Filter = FilterNeobrisaneProdaje;

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            
            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);
        }
        
        private bool FilterNeobrisaneProdaje(object obj)
        {
            return ((Prodaja)obj).Obrisan == false;
        }
        
        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var praznaProdaja = new Prodaja()
            {
                BrojRacuna = ""
            };
            var prodajaProzor = new ProdajaWindow(praznaProdaja);
            prodajaProzor.ShowDialog();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var prodajaZaBrisanje = (Prodaja)dataGrid.SelectedItem;
            if (MessageBox.Show(
                $"Da li ste sigurni da zelite da obrisete racun: { prodajaZaBrisanje.BrojRacuna }?",
                "Brisanje racuna", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Prodaje;

                foreach (var prodaja in lista)
                {
                    if (prodaja.Id == prodajaZaBrisanje.Id)
                    {
                        prodaja.Obrisan = true;
                        view.Refresh();
                    }
                }
                Prodaja.Delete(prodajaZaBrisanje);
            }
        }

        private void dataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "PDV" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnRacun_Click(object sender, RoutedEventArgs e)
        {
            var racunProzor = new ProdajaRacun(IzabranaProdaja);
            racunProzor.ShowDialog();
        }
    }
}
