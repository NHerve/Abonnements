CREATE TABLE Client (
	cliId SERIAL PRIMARY KEY,
	cliNom VARCHAR(255) NOT NULL,
	cliPrenom VARCHAR(255) NOT NULL,
	cliPassword VARCHAR(255) NOT NULL,
	cliMail VARCHAR(255) NOT NULL,
	cliDateNaissance DATE,
	cliLieuNaissance VARCHAR(255)
)

CREATE TABLE Magazine (
	magId SERIAL PRIMARY KEY,
	magTitre VARCHAR(255) NOT NULL,
	magNbVolumeAnnee INT NOT NULL, 
	magPhotoCouverture VARCHAR(10000),
	magDescription VARCHAR(10000) NOT NULL,
	magPrixAnnuel REAL NOT NULL
)

CREATE TABLE Abonnement (
	aboFKCli INT NOT NULL REFERENCES client(cliId),
	aboFKMag INT NOT NULL REFERENCES magazine(magId),
	aboDateDebut DATE NOT NULL,
	aboDateFin DATE,
	PRIMARY KEY(aboFKCli,aboFKMag)
)

INSERT INTO client (cliNom,cliPrenom,clipassword,cliMail,cliDateNaissance,cliLieuNaissance) VALUES ( 'AYMES', 'Herve', '123haymes456' , 'herve.04@hotmail.fr', '1996-07-17', 'Marseille');
INSERT INTO client (cliNom,cliPrenom,clipassword,cliMail,cliDateNaissance,cliLieuNaissance) VALUES ( 'JEANNE', 'Steven', '123sjeanne456' , 'steven@mail.com', '1996-07-17', 'Valreas');
INSERT INTO client (cliNom,cliPrenom,clipassword,cliMail,cliDateNaissance,cliLieuNaissance) VALUES ( 'JOLY', 'Fred', '123fjoly456' , 'fred@mail.fr', '1994-06-09', 'Paris');

INSERT INTO magazine (magTitre, magNbVolumeAnnee,magPhotoCouverture,magDescription,magPrixAnnuel) VALUES ('le gorafi' , 365, 'http://www.legorafi.fr/wp-content/themes/legorafi/img/socials.png', 'Le Gorafi est un site d''information trés serieux, créé en mai 2012 durant la campagne présidentielle française',99.99);
INSERT INTO magazine (magTitre, magNbVolumeAnnee,magPhotoCouverture,magDescription,magPrixAnnuel) VALUES ('nord presse' , 365, 'https://cdni.rt.com/french/images/2016.10/article/5810e944c36188e3488b456f.jpg', 'Nordpresse est un site d''information belge. Commençant d''abord par s''inspirer de Sudpresse, le site utilise également des noms de domaines ressemblant à ceux de médias français pour crédibiliser ses informations.',99.98);
INSERT INTO magazine (magTitre, magNbVolumeAnnee,magPhotoCouverture,magDescription,magPrixAnnuel) VALUES ('le monde' , 365, 'https://static1.ozap.com/articles/6/57/89/36/@/4617206-le-monde-article_default-2.jpg', 'Le Monde est un journal français fondé par Hubert Beuve-Méry en 1944. C''est l''un des derniers quotidiens français dits « du soir », qui paraît, daté du lendemain, à Paris en début d''après-midi ainsi que, un peu plus tard, dans certaines grandes villes, et est distribué en province le matin suivant.',99.98);

INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (1,1,'2019-06-10','2020-06-10');
INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (1,2,'2018-08-02','2019-08-02');
INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (1,3,'2013-04-08','2014-04-08');

INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (2,1,'2013-04-08','2014-04-08');
INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (2,2,'2018-08-02','2019-08-02');
INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (2,3,'2019-06-10','2020-06-10');

INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (3,1,'2018-08-02','2019-08-02');
INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (3,2,'2013-04-08','2014-04-08');
INSERT INTO abonnement (aboFKCli,aboFKMag,aboDateDebut,aboDateFin) VALUES (3,3,'2019-06-10','2020-06-10');