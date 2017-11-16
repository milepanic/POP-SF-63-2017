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
            IZMENA
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

            // dropdown za tip namjestaja - override-uje se toString metoda klase
            foreach (var TipNamestaja in Projekat.Instance.TipoviNamestaja)
            {
                cbTipNamestaja.Items.Add(TipNamestaja);
            }

            // petlja da ispise tip namjestaja u combo boxu kada se edituje
            foreach (TipNamestaja tipNamestaja in cbTipNamestaja.Items)
            {
                if (tipNamestaja.Id == namestaj.TipNamestajaId)
                {
                    cbTipNamestaja.SelectedItem = tipNamestaja;
                    break;
                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //cita sa diska listu namjestaja
            var listaNamestaja = Projekat.Instance.Namestaji;
            // uzima objekat tip namjestaja iz dropdown liste
            TipNamestaja izabraniTipNamestaja = (TipNamestaja)cbTipNamestaja.SelectedItem;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    namestaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = tbNaziv.Text,
                        Cena = double.Parse(tbCena.Text),
                        TipNamestajaId = izabraniTipNamestaja.Id
                    };
                    listaNamestaja.Add(namestaj);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if(n.Id == namestaj.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.Cena = double.Parse(this.tbCena.Text);
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                            break;
                        }
                    }
                    break;
            }

            //Serijalizuje se preko Projekat.cs - cuva u disk
            Projekat.Instance.Namestaji = listaNamestaja;

            Close();
        }
    }
}
