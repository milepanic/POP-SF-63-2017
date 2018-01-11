using POP_SF_63_2017.Model;
using POP_SF_63_2017_GUI.GUI;
using System.Linq;
using System.Windows;

namespace POP_SF_63_2017_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Korisnik korisnik)
        {
            InitializeComponent();
            
            if(korisnik.TipKorisnika == TipKorisnika.PRODAVAC)
            {
                adminPanel.Visibility = Visibility.Hidden;
            }

            var saloni = Projekat.Instance.Saloni;
            var salon = saloni.First();

            lbSalon.Content = $"{salon}";

            lbKorisnik.Content = $"{korisnik}";
        }
        
        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void namestaj_Click(object sender, RoutedEventArgs e)
        {
            var namestajProzor = new NamestajCRUDWindow();
            namestajProzor.ShowDialog();
        }

        private void tipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            var tipNamestajaProzor = new TipNamestajaCRUDWindow();
            tipNamestajaProzor.ShowDialog();
        }

        private void korisnik_Click(object sender, RoutedEventArgs e)
        {
            var korisnikProzor = new KorisnikCRUDWindow();
            korisnikProzor.ShowDialog();
        }

        private void Salon_Click(object sender, RoutedEventArgs e)
        {
            var salonProzor = new SalonCRUDWindow();
            salonProzor.ShowDialog();
        }

        private void dodatnaUsluga_Click(object sender, RoutedEventArgs e)
        {
            var dodatnaUslugaProzor = new DodatnaUslugaCRUDWindow();
            dodatnaUslugaProzor.ShowDialog();
        }

        private void akcija_Click(object sender, RoutedEventArgs e)
        {
            var akcijaProzor = new AkcijaCRUDWindow();
            akcijaProzor.ShowDialog();
        }

        private void prodaja_Click(object sender, RoutedEventArgs e)
        {
            var prodajaProzor = new ProdajaCRUDWindow();
            prodajaProzor.ShowDialog();
        }

        private void odjava_Click(object sender, RoutedEventArgs e)
        {
            var prijavaProzor = new Login();
            Close();
            prijavaProzor.ShowDialog();
        }
    }
}
