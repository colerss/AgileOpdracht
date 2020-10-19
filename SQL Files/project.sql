CREATE SCHEMA CWL
GO

CREATE TABLE CWL.LijstItem(
LijstItemId int PRIMARY KEY,
ProducttypeId int FOREIGN KEY REFERENCES CWL.Producttype(Id),
WinkellijstId int FOREIGN KEY REFERENCES CWL.Winkellijst(Id),
Aantal int NOT NULL
);

CREATE TABLE CWL.Winkellijst(
WinkellijstId int PRIMARY KEY,
GebruikerId int FOREIGN KEY REFERENCES CWL.Gebruiker(Id),
Naam varchar(255)
);

CREATE TABLE CWL.Gebruiker(
GebruikerId int PRIMARY KEY,
Gebruikersnaam varchar (255),
Wachtwoord varchar (255));

CREATE TABLE CWL.Product(
ProductId int PRIMARY KEY,
ProducttypeId int FOREIGN KEY REFERENCES CWL.Producttype(Id),
LocatieId int FOREIGN KEY REFERENCES CWL.Locatie(Id),
Naam varchar (255),
Prijs smallmoney,
Hoeveelheid int,
Omschrijving varchar (255)
);

CREATE TABLE CWL.Producttype(
ProducttypeId int PRIMARY KEY,
Naam varchar(255)
);

CREATE TABLE CWL.Locatie(
LocatieId int PRIMARY KEY,
ProducttypeId int FOREIGN KEY REFERENCES CWL.Producttype(Id),
Volgnummer int 
);
