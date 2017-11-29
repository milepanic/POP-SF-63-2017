using POP_SF_63_2017.Model;
using System.Windows;
using System;

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
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            //cita sa diska listu namjestaja
            var listaSalona = Projekat.Instance.Saloni;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    salon = new Salon()
                    {
                        Id = listaSalona.Count + 1,
                        Naziv = tbNaziv.Text,
                        Adresa = tbAdresa.Text,
                        Telefon = tbTelefon.Text,
                        Email = tbEmail.Text,
                        Websajt = tbWebsajt.Text,
                        PIB = int.Parse(tbPIB.Text),
                        MaticniBroj = int.Parse(tbMaticniBroj.Text),
                        BrojZiroRacuna = tbBrojZiroRacuna.Text
                    };
                    listaSalona.Add(salon);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaSalona)
                    {
                        if (n.Id == salon.Id)
                        {
                            n.Naziv = tbNaziv.Text;
                            n.Adresa = tbAdresa.Text;
                            n.Telefon = tbTelefon.Text;
                            n.Email = tbEmail.Text;
                            n.Websajt = tbWebsajt.Text;
                            n.PIB = int.Parse(tbPIB.Text);
                            n.MaticniBroj = int.Parse(tbMaticniBroj.Text);
                            n.BrojZiroRacuna = tbBrojZiroRacuna.Text;
                            break;
                        }
                    }
                    break;
            }

            //Serijalizuje se preko Projekat.cs - cuva u disk
            Projekat.Instance.Saloni = listaSalona;

            Close();
        }
    }
}
