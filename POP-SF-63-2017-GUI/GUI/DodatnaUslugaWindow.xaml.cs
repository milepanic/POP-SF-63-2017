﻿using POP_SF_63_2017.Model;
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

            tbNaziv.DataContext = dodatnaUsluga;
            tbCena.DataContext = dodatnaUsluga;
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
                    DodatnaUsluga.Create(dodatnaUsluga);
                    break;
                case TipOperacije.IZMENA:
                    var listaDodatnihUsluga = Projekat.Instance.DodatneUsluge;

                    foreach (var n in listaDodatnihUsluga)
                    {
                        if (n.Id == dodatnaUsluga.Id)
                        {
                            n.Naziv = dodatnaUsluga.Naziv;
                            n.Cena = dodatnaUsluga.Cena;

                            DodatnaUsluga.Update(dodatnaUsluga);

                            break;
                        }
                    }
                    break;
            }
            Close();
        }
    }
}
