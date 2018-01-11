﻿INSERT INTO TipNamestaja (Naziv) VALUES ('Krevet');
INSERT INTO TipNamestaja (Naziv) VALUES ('Ugaona garnitura');
INSERT INTO TipNamestaja (Naziv) VALUES ('Kauc');

INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka)
	VALUES ('2017-03-03', 20, '2018-04-04');
INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka)
	VALUES ('2017-06-23', 30, '2018-05-04');
INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka)
	VALUES ('2017-06-01', 10, '2018-01-21');

INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu, ProdataKolicina) 
	VALUES (1, 2, 'asdasda', 'Francuski krevet', 123.5, 22, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu, ProdataKolicina) 
	VALUES (2, 1, 'aadfadagg', 'Sofija ugaona', 223.9, 12, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu, ProdataKolicina) 
	VALUES (3, 3, 'efafea', 'Ivan kauc', 735.9, 2, 0);

INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika)
	VALUES ('Todor', 'Boroja', 's', 's', 0);
INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika)
	VALUES ('Goran', 'Bratic', 'b', 'b', 1);
INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika)
	VALUES ('Djole', 'Joveta', 'a', 'a', 0);

INSERT INTO Salon (Naziv, Adresa, Telefon, Email, Websajt, PIB, MaticniBroj, BrojZiroRacuna)
	VALUES ('Salon1', 'Ulica neka', '+381662154681', 'salon1@gmail.com', 'salon1.com', 1247161, 14198519, '41085198571');




INSERT INTO DodatnaUsluga (Naziv, Cena)
	VALUES ('dodatna usluga 1', 120.5);



INSERT INTO Prodaja (BrojRacuna, Kupac, UkupnaCena)
	VALUES ('314151', 'Petar Maric', 1200.0);

