using POP_SF_63_2017.Model;
using System.Windows;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private TipNamestaja tipNamestaja;
        private TipOperacije operacija;


        public TipNamestajaWindow(TipNamestaja tipNamestaja, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(tipNamestaja, operacija);
        }

        private void InicijalizujPodatke(TipNamestaja tipNamestaja, TipOperacije operacija)
        {
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbNaziv.DataContext = tipNamestaja;
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaTipovaNamestaja = Projekat.Instance.TipoviNamestaja;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    // obrisati
                    /*
                    tipNamestaja = new TipNamestaja()
                    {
                        Id = listaTipovaNamestaja.Count + 1,
                        Naziv = tbNaziv.Text
                    };
                    */
                    TipNamestaja.Create(tipNamestaja);
                    //listaTipovaNamestaja.Add(tipNamestaja);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaTipovaNamestaja)
                    {
                        if (n.Id == tipNamestaja.Id)
                        {
                            n.Naziv = tipNamestaja.Naziv;
                            break;
                        }
                    }
                    TipNamestaja.Update(tipNamestaja);
                    break;
            }
            
            //obrisati
            //Projekat.Instance.TipoviNamestaja = listaTipovaNamestaja;

            Close();
        }
    }
}
