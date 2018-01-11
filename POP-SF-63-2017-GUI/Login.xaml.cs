using POP_SF_63_2017.Model;
using System.Windows;

namespace POP_SF_63_2017_GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private int brojPokusaja = 2;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = tbUsername.Text;
            string sifra = tbPassword.Password;
            var korisnici = Projekat.Instance.Korisnici;

            if (brojPokusaja == 0)
            {
                MessageBox.Show("Nemate vise pokusaja za logovanje", "Izlazak", MessageBoxButton.OK);
                Close();
                return;
            }

            int flag = 0;

            var ulogovaniKorisnik = new Korisnik();

            foreach (Korisnik korisnik in korisnici)
            {
                if (korisnik.Obrisan == false && korisnik.KorisnickoIme == korisnickoIme && korisnik.Lozinka == sifra)
                {
                    flag = 1;
                    ulogovaniKorisnik = korisnik;
                }
            }

            if(flag == 1)
            {
                var glavniProzor = new MainWindow(ulogovaniKorisnik);
                Close();
                glavniProzor.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show($"Korisnik sa tim podacima ne postoji, imate jos {brojPokusaja} pokusaja", "Greska", MessageBoxButton.OK);

                brojPokusaja--;
                return;
            }
        }
    }
}
