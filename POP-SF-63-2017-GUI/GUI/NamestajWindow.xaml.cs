using POP_SF_63_2017.Model;
using System.Linq;
using System.Windows;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA,
            BRISANJE
        }

        private Namestaj namestaj;
        private TipOperacije operacija;

        

        public NamestajWindow(Namestaj namestaj, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(namestaj, operacija);
        }

        private void InicijalizujPodatke(Namestaj namestaj, TipOperacije operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            tbNaziv.Text = namestaj.Naziv;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //cita sa diska
            var listaNamestaja = Projekat.Instance.Namestaji;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    namestaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = tbNaziv.Text,
                        Cena = double.Parse(tbCena.Text),
                        TipNamestajaId = int.Parse(tbTipId.Text)
                    };
                    listaNamestaja.Add(namestaj);
                    break;
                case TipOperacije.IZMENA:
                    var namestajZaIzmenu = listaNamestaja.SingleOrDefault(x => x.Id == namestaj.Id); //isto kao foreach
                    namestajZaIzmenu.Naziv = tbNaziv.Text;
                    break;
                case TipOperacije.BRISANJE:
                    var namestajZaBrisanje = listaNamestaja.SingleOrDefault(x => x.Id == namestaj.Id);
                    namestajZaBrisanje.Obrisan = true;
                    break;
                default:
                    break;
            }

            //Serijalizuje se preko Projekat.cs - cuva u disk
            Projekat.Instance.Namestaji = listaNamestaja;

            Close();
        }
    }
}
