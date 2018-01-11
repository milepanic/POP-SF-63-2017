using POP_SF_63_2017.Model;
using System.Windows;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Salon salon;
        private TipOperacije operacija;

        public SalonWindow(Salon salon, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(salon, operacija);
        }

        private void InicijalizujPodatke(Salon salon, TipOperacije operacija)
        {
            this.salon = salon;
            this.operacija = operacija;

            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbEmail.DataContext = salon;
            tbWebsajt.DataContext = salon;
            tbPIB.DataContext = salon;
            tbMaticniBroj.DataContext = salon;
            tbBrojZiroRacuna.DataContext = salon;
        }
        
        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    Salon.Create(salon);
                    break;
                case TipOperacije.IZMENA:
                    var listaSalona = Projekat.Instance.Saloni;

                    foreach (var n in listaSalona)
                    {
                        if (n.Id == salon.Id)
                        {
                            n.Naziv = salon.Naziv;
                            n.Adresa = salon.Adresa;
                            n.Telefon = salon.Telefon;
                            n.Email = salon.Email;
                            n.Websajt = salon.Websajt;
                            n.PIB = salon.PIB;
                            n.MaticniBroj = salon.MaticniBroj;
                            n.BrojZiroRacuna = salon.BrojZiroRacuna;

                            Salon.Update(salon);

                            break;
                        }
                    }
                    break;
            }
            Close();
        }
    }
}
