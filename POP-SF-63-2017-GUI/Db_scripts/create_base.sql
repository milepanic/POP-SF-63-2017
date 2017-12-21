﻿CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Obrisan BIT NOT NULL DEFAULT ((0))
)
GO
CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipNamestajaId INT,
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