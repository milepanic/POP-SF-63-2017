using POP_SF_63_2017.Model;
using System.Windows;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private DodatnaUsluga dodatnaUsluga;
        private TipOperacije operacija;

        public DodatnaUslugaWindow(DodatnaUsluga dodatnaUsluga, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(dodatnaUsluga, operacija);
        }

        private void InicijalizujPodatke(DodatnaUsluga dodatnaUsluga, TipOperacije operacija)
        {
            this.dodatnaUsluga = dodatnaUsluga;
            this.operacija = operacija;

            tbNaziv.DataContext = dodatnaUsluga.Naziv;
            tbCena.DataContext = dodatnaUsluga.Cena;
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaDodatnihUsluga = Projekat.Instance.DodatneUsluge;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    dodatnaUsluga = new DodatnaUsluga()
                    {
                        Id = listaDodatnihUsluga.Count + 1,
                        Naziv = tbNaziv.Text,
                        Cena = double.Parse(tbCena.Text),
                    };
                    listaDodatnihUsluga.Add(dodatnaUsluga);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaDodatnihUsluga)
                    {
                        if (n.Id == dodatnaUsluga.Id)
                        {
                            n.Naziv = dodatnaUsluga.Naziv;
                            n.Cena = dodatnaUsluga.Cena;
                            break;
                        }
                    }
                    break;
            }
            
            Projekat.Instance.DodatneUsluge = listaDodatnihUsluga;

            Close();
        }
    }
}
