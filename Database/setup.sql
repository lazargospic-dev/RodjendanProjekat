
CREATE DATABASE RodjendaniDB;
GO
USE RodjendaniDB;
GO

-- TABELE
CREATE TABLE klijenti (
    klijent_id INT IDENTITY(1,1) PRIMARY KEY,
    ime NVARCHAR(50) NOT NULL,
    prezime NVARCHAR(50) NOT NULL,
    telefon NVARCHAR(20),
    email NVARCHAR(100),
    napomena NVARCHAR(255)
);

CREATE TABLE slavljenici (
    slavljenik_id INT IDENTITY(1,1) PRIMARY KEY,
    ime NVARCHAR(50) NOT NULL,
    datum_rodjenja DATE NOT NULL,
    pol NVARCHAR(10),
    klijent_id INT NOT NULL,
    FOREIGN KEY (klijent_id) REFERENCES klijenti(klijent_id)
);

CREATE TABLE sale (
    sala_id INT IDENTITY(1,1) PRIMARY KEY,
    naziv NVARCHAR(100) NOT NULL,
    kapacitet INT NOT NULL,
    opis NVARCHAR(255)
);

CREATE TABLE zaposleni (
    zaposleni_id INT IDENTITY(1,1) PRIMARY KEY,
    ime NVARCHAR(50) NOT NULL,
    prezime NVARCHAR(50) NOT NULL,
    telefon NVARCHAR(20),
    pozicija NVARCHAR(50)
);

CREATE TABLE dodatne_usluge (
    usluga_id INT IDENTITY(1,1) PRIMARY KEY,
    naziv NVARCHAR(100) NOT NULL,
    cena DECIMAL(10,2) NOT NULL,
    opis NVARCHAR(255)
);

CREATE TABLE rezervacije (
    rezervacija_id INT IDENTITY(1,1) PRIMARY KEY,
    datum DATE NOT NULL,
    vreme_od TIME NOT NULL,
    vreme_do TIME NOT NULL,
    broj_dece INT NOT NULL,
    ukupan_iznos DECIMAL(10,2) NOT NULL DEFAULT 0,
    status NVARCHAR(20) NOT NULL DEFAULT 'Rezervisano',
    klijent_id INT NOT NULL,
    slavljenik_id INT NOT NULL,
    sala_id INT NOT NULL,
    FOREIGN KEY (klijent_id) REFERENCES klijenti(klijent_id),
    FOREIGN KEY (slavljenik_id) REFERENCES slavljenici(slavljenik_id),
    FOREIGN KEY (sala_id) REFERENCES sale(sala_id)
);

CREATE TABLE rezervacija_usluge (
    id INT IDENTITY(1,1) PRIMARY KEY,
    rezervacija_id INT NOT NULL,
    usluga_id INT NOT NULL,
    kolicina INT NOT NULL DEFAULT 1,
    FOREIGN KEY (rezervacija_id) REFERENCES rezervacije(rezervacija_id),
    FOREIGN KEY (usluga_id) REFERENCES dodatne_usluge(usluga_id)
);

CREATE TABLE rezervacija_zaposleni (
    id INT IDENTITY(1,1) PRIMARY KEY,
    rezervacija_id INT NOT NULL,
    zaposleni_id INT NOT NULL,
    uloga NVARCHAR(50),
    FOREIGN KEY (rezervacija_id) REFERENCES rezervacije(rezervacija_id),
    FOREIGN KEY (zaposleni_id) REFERENCES zaposleni(zaposleni_id)
);

CREATE TABLE uplate (
    uplata_id INT IDENTITY(1,1) PRIMARY KEY,
    rezervacija_id INT NOT NULL,
    datum_uplate DATE NOT NULL,
    iznos DECIMAL(10,2) NOT NULL,
    nacin_placanja NVARCHAR(30),
    FOREIGN KEY (rezervacija_id) REFERENCES rezervacije(rezervacija_id)
);

CREATE TABLE korisnici (
    korisnik_id INT IDENTITY(1,1) PRIMARY KEY,
    ime NVARCHAR(50) NOT NULL,
    prezime NVARCHAR(50) NOT NULL,
    telefon NVARCHAR(20),
    email NVARCHAR(100),
    napomena NVARCHAR(255),
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(100) NOT NULL,
    uloga NVARCHAR(20) DEFAULT 'Zaposleni'
);

-- TEST PODACI
INSERT INTO klijenti (ime, prezime, telefon, email, napomena) VALUES
('Marko','Petrović','0641234567','marko@gmail.com','Stalan klijent'),
('Ana','Jovanović','0651112233','ana@gmail.com',NULL);

INSERT INTO slavljenici (ime, datum_rodjenja, pol, klijent_id) VALUES
('Luka','2018-05-12','M',1),
('Mila','2019-08-22','Ž',2);

INSERT INTO sale (naziv, kapacitet, opis) VALUES
('Plava sala',30,'Sala sa toboganom'),
('Crvena sala',50,'Velika sala sa binom');

INSERT INTO zaposleni (ime, prezime, telefon, pozicija) VALUES
('Jelena','Nikolić','0631111111','Animator'),
('Stefan','Ilić','0632222222','Konobar');

INSERT INTO dodatne_usluge (naziv, cena, opis) VALUES
('Torta',3500,'Čokoladna torta'),
('Animator',5000,'2 sata animacije'),
('Face painting',2500,'Slikanje lica');

INSERT INTO korisnici (ime, prezime, telefon, email, username, password, uloga)
VALUES ('Glavni','Admin','0641111111','admin@test.com','admin','admin123','Admin');