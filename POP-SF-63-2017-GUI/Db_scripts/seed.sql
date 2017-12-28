INSERT INTO TipNamestaja (Naziv) VALUES ('Krevet');
INSERT INTO TipNamestaja (Naziv) VALUES ('Ugaona garnitura');
INSERT INTO TipNamestaja (Naziv) VALUES ('Kauc');

INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka)
	VALUES ('2017-03-03', 20, '2018-04-04');
INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka)
	VALUES ('2017-06-23', 30, '2018-05-04');
INSERT INTO Akcija (DatumPocetka, Popust, DatumZavrsetka)
	VALUES ('2017-06-01', 10, '2018-01-21');

INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu) 
	VALUES (1, 2, 'asdasda', 'Francuski krevet', 123.5, 22);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu) 
	VALUES (2, 1, 'aadfadagg', 'Sofija ugaona', 223.9, 12);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Sifra, Naziv, Cena, KolicinaUMagacinu) 
	VALUES (3, 3, 'efafea', 'Ivan kauc', 735.9, 2);

INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika)
	VALUES ('Pero', 'Peric', 'PeroPeric', '123', 0);
INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika)
	VALUES ('Jovan', 'Ilic', 'JovanIlic', '123', 0);
INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika)
	VALUES ('Admin', 'Admin', 'Admin', '123', 1);