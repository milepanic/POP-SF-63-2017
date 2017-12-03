﻿using POP_SF_63_2017.Model;
using System.Windows;
using System;

namespace POP_SF_63_2017_GUI.GUI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private Korisnik korisnik;
        private TipOperacije operacija;

        public KorisnikWindow(Korisnik korisnik, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(korisnik, operacija);
        }

        private void InicijalizujPodatke(Korisnik korisnik, TipOperacije operacija)
        {
            this.korisnik = korisnik;
            this.operacija = operacija;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;

            cbTipKorisnika.Items.Insert(0, "Prodavac");
            cbTipKorisnika.Items.Insert(1, "Admin");
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnici;

            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    korisnik = new Korisnik()
                    {
                        Id = listaKorisnika.Count + 1,
                        Ime = tbIme.Text,
                        Prezime = tbPrezime.Text,
                        KorisnickoIme = tbKorisnickoIme.Text,
                        Lozinka = tbLozinka.Text,
                        TipKorisnika = cbTipKorisnika.SelectedIndex
                    };
                    listaKorisnika.Add(korisnik);
                    break;
                case TipOperacije.IZMENA:
                    foreach (var n in listaKorisnika)
                    {
                        if (n.Id == korisnik.Id)
                        {
                            n.Ime = korisnik.Ime;
                            n.Prezime = korisnik.Prezime;
                            n.KorisnickoIme = korisnik.KorisnickoIme;
                            n.Lozinka = korisnik.Lozinka;
                            n.TipKorisnika = cbTipKorisnika.SelectedIndex;
                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.Korisnici = listaKorisnika;

            Close();
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
