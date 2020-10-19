

CREATE SCHEMA CWL
GO

CREATE TABLE CWL.Gebruiker(
GebruikerId int PRIMARY KEY,
Gebruikersnaam varchar (255) NOT NULL,
Wachtwoord varchar (255) NOT NULL);

CREATE TABLE CWL.Locatie(
LocatieId int PRIMARY KEY,
LocatieNaam varchar(50) NOT NULL,
Volgnummer int NOT NULL
);
CREATE TABLE CWL.Winkellijst(
WinkellijstId int PRIMARY KEY,
GebruikerId int FOREIGN KEY REFERENCES CWL.Gebruiker(GebruikerId),
Naam varchar(255) NOT NULL
);


CREATE TABLE CWL.Product(
ProductId int PRIMARY KEY,
LocatieId int FOREIGN KEY REFERENCES CWL.Locatie(LocatieId),
Naam varchar (255) NOT NULL,
Prijs smallmoney NOT NULL,
Hoeveelheid int
);
CREATE TABLE CWL.LijstItem(
LijstItemId int PRIMARY KEY,
WinkellijstId int FOREIGN KEY REFERENCES CWL.Winkellijst(WinkellijstId),
Aantal int NOT NULL
);