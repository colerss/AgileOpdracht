INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (0, 'Brood/ Ontbijt',0);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (1, 'Koeken/ Snoep',1);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (2, 'Diepvries',2);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (3, 'Groente / Fruit',3);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (4, 'Alcoholische dranken',7);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (5, 'Zuivel',4);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (6, 'Conserve',5);
INSERT INTO CWL.Locatie(LocatieID, LocatieNaam, Volgnummer)
VALUES (7, 'Snacks',6);


INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (0,0, 'Boni Meergranenbrood', 1.38, 600 );
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (1,0, 'Poco Loco Mexicaanse Wraps 6st', 2.49, 370);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (2,0, 'Calve Pindakaas', 2.99, 350);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (3,1, 'Milka Alpenmelk', 1.15, 100);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (4,1, 'Lotus Madeleine', 2.74, 300 );
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (5,1, 'Boni Luikse Wafels 8st', 3.18, 720);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (6,2, 'Boni Pizza Mozerella 2st', 2.39, 670);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (7,2, 'Mora Loempias 4st', 3.45, 600);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (8,2, 'Everyday Kippenborstfilets', 5.85, 1000);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (9,3, 'Boni Polderaardappelen', 3.25, 2500);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (10,3, 'Wortelen Los', 0.89, null);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (11,3, 'Boni Clementines', 2.36, null);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (12,4, 'Grimbergen Dubbel 8st', 8.65, 1980);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (13,4, 'Stella Artois blik', 0.97, 330);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (14,4, 'Chateau La France (wit)', 5.49, 700);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (15,5, 'Everyday Yoghurt vol', 1.05, 1000);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (16,5, 'Nestle La Latière 4st', 1.56, 660);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (17,5, 'Balade roomboter', 3.65, 225);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (18,6, 'Boni Ananas stukjes op blik', 0.89, 227);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (19,6, 'Bonduelle boterbonen extra fijn', 2.69, 590);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (20,6, 'Boni Cocktail worstjes', 0.59, 200);

INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (21,7, 'Pringles Original', 2.23, 200);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (22,7, 'Jimmies popcorn, zoet', 1.43, 150);
INSERT INTO CWL.Product(ProductId, LocatieId, Naam, Prijs, Hoeveelheid)
VALUES (23,7, 'Boni Salsa mix', 2.39, 400);


Insert Into CWL.Gebruiker(GebruikerId, Gebruikersnaam, Wachtwoord)
VALUES (0, 'Admin', 'Admin123')
