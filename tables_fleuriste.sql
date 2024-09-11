create database if not exists fleurs;
use fleurs;

Drop table if exists clients;
CREATE TABLE clients (
    idClient INT PRIMARY KEY,
    nom VARCHAR(50),
    prenom VARCHAR(50) ,
    telephone VARCHAR(20) ,
    courriel VARCHAR(50),
    mdp VARCHAR(50),
    adresse VARCHAR(100) ,
    carte_credit VARCHAR(16) ,
    statut ENUM('normal', 'OR', 'bronze') 
);

drop table if exists commandes;
CREATE TABLE commandes (

    idCommande INT PRIMARY KEY auto_increment ,
    idClient INT ,
    date_commande DATE ,
    date_livraison DATE ,
    adresse_livraison VARCHAR(100) ,
    message VARCHAR(200),
    montant_total DECIMAL(7,2) ,
    etat ENUM('VINV', 'CC', 'CPAV', 'CAL', 'CL') ,
    idBoutique INT,
    FOREIGN KEY (idClient) REFERENCES clients(idClient),
    FOREIGN KEY (idBoutique) REFERENCES boutique(idBoutique)
);

drop table if exists compo;
CREATE TABLE compo(

	idCompo int PRIMARY KEY auto_increment, 
	nom varchar(30),
	description VARCHAR(200),
	idCommande INT,
    prix DECIMAL(7,2),
	FOREIGN KEY (idCommande) REFERENCES commandes(idCommande)
);


drop table if exists items;
CREATE TABLE items (
    idItem INT,
    idCompo INT,
    quantite INT,
    PRIMARY KEY(idItem, idCompo),
    FOREIGN KEY (idCompo) REFERENCES compo(idCompo),
    FOREIGN KEY (idItem) REFERENCES stock(idItem)
);

drop table if exists stock;
CREATE TABLE stock(
	idItem INT PRIMARY KEY, 
    nom VARCHAR(50) ,
	description VARCHAR(200),
	prix DECIMAL(7,2) ,
	type ENUM('fleur', 'accessoire'),
    quantite INT
);

drop table if exists boutique;
CREATE table boutique(
	idBoutique INT PRIMARY KEY
);

INSERT INTO clients VALUES (0,'Bellefleur','Michel','','11','11','11','00000000', 'normal');

