using POP_SF_63_2017.Model;
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

            dataGrid.ItemsSource = view;

            dataGrid.DataContext = this;
            dataGrid.IsSynchronizedWithCurrentItem = true;
            
            dataGrid.ColumnWidth = new System.Windows.Controls.DataGridLength(1, System.Windows.Controls.DataGridLengthUnitType.Star);

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
            var prodajaProzor = new ProdajaWindow(praznaProdaja, ProdajaWindow.TipOperacije.DODAVANJE);
            prodajaProzor.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Prodaja kopijaProdaje = (Prodaja)IzabranaProdaja.Clone();

            var prodajaProzor = new ProdajaWindow(kopijaProdaje, ProdajaWindow.TipOperacije.IZMENA);
            prodajaProzor.ShowDialog();
        }
    }
}
