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

            tbNaziv.Text = tipNamestaja.Naziv;
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //cita sa diska listu namjestaja
            var listaTipovaNamestaja = Projekat.Instance.TipoviNamestaja;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    tipNamestaja = new TipNamestaja()
                    {
                        Id = listaTipovaNamestaja.Count + 1,
                        Naziv = tbNaziv.Text
                    };
                    listaTipovaNamestaja.Add(tipNamestaja);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaTipovaNamestaja)
                    {
                        if (n.Id == tipNamestaja.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            break;
                        }
                    }
                    break;
            }

            //Serijalizuje se preko Projekat.cs - cuva u disk
            Projekat.Instance.TipoviNamestaja = listaTipovaNamestaja;

            Close();
        }
    }
}
