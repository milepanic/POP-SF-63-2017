CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Obrisan BIT NOT NULL DEFAULT ((0))
)
GO
CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipNamestajaId INT,
	AkcijaId INT,
	Sifra VARCHAR(50),
	Naziv VARCHAR(100),
	Cena NUMERIC(9,2),
	KolicinaUMagacinu INT,
	Obrisan BIT NOT NULL DEFAULT ((0)),
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
)
GO
CREATE TABLE Akcija (
	Id INT PRIMARY KEY IDENTITY(1,1),
	DatumPocetka DATE,
	Popust DECIMAL,
	DatumZavrsetka DATE,
	Obrisan BIT NOT NULL DEFAULT ((0))
)
GO
CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Ime VARCHAR(30),
	Prezime VARCHAR(30),
	KorisnickoIme VARCHAR(50),
	Lozinka VARCHAR(30),
	TipKorisnika INT,
	Obrisan BIT NOT NULL DEFAULT ((0))
)
GO
CREATE TABLE Salon (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(60),
	Adresa VARCHAR(50),
	Telefon VARCHAR(50),
	Email VARCHAR(50),
	Websajt VARCHAR(50),
	PIB INT,
	MaticniBroj INT,
	BrojZiroRacuna VARCHAR(60),
	Obrisan BIT NOT NULL DEFAULT((0))
)
GO
CREATE TABLE DodatnaUsluga (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(60),
	Cena NUMERIC(9,2),
	Obrisan BIT NOT NULL DEFAULT((0))
)
GO
CREATE TABLE Prodaja (
	Id INT PRIMARY KEY IDENTITY(1,1),
	NamestajId INT,
	DatumProdaje DATETIME,
	BrojRacuna VARCHAR(60),
	Kupac VARCHAR(60),
	DodatnaUslugaId INT,
	UkupnaCena NUMERIC(9,2)
)