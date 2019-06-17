CREATE TABLE "clients" (
          "cliId" serial NOT NULL,
          "cliNom" text NOT NULL,
          "cliPrenom" text NOT NULL,
          "cliPassword" text NOT NULL,
          "cliMail" text NOT NULL,
          "cliDateNaissance" timestamp NULL,
          "cliLieuNaissance" text NULL,
          "cliNumCart" text NULL,
          "cliExpiCarte" text NULL,
          "cliCCV" text NULL,
          "cliAuthKey" text NULL,
          CONSTRAINT "PK_clients" PRIMARY KEY ("cliId")
      );

     CREATE TABLE "Magazines" (
          "magId" serial NOT NULL,
          "magTitre" text NOT NULL,
          "magNbVolumeAnnee" int4 NOT NULL,
          "magPhotoCouverture" text NULL,
          "magDescription" text NOT NULL,
          "magPrixAnnuel" numeric NOT NULL,
          CONSTRAINT "PK_Magazines" PRIMARY KEY ("magId")
      );

      CREATE TABLE "Abonnements" (
          "aboId" serial NOT NULL,
          "aboFKCli" int4 NOT NULL,
          "aboFKMag" int4 NOT NULL,
          "aboDateDebut" timestamp NOT NULL,
          "aboDateFin" timestamp NOT NULL,
          "aboStatus" int4 NOT NULL,
          CONSTRAINT "PK_Abonnements" PRIMARY KEY ("aboId")
      );
      ALTER TABLE public."Abonnements" ADD FOREIGN KEY ("aboFKCli") REFERENCES public."clients"("cliId");
      ALTER TABLE public."Abonnements" ADD FOREIGN KEY ("aboFKMag") REFERENCES public."Magazines"("magId");

INSERT INTO "clients" ("cliNom","cliPrenom","cliPassword","cliMail","cliDateNaissance","cliLieuNaissance") VALUES ('AYMES', 'Herve', '123haymes456' , 'herve.04@hotmail.fr', '1996-07-17', 'Marseille');
INSERT INTO "clients" ("cliNom","cliPrenom","cliPassword","cliMail","cliDateNaissance","cliLieuNaissance","cliNumCart","cliExpiCarte","cliCCV") VALUES ('JEANNE', 'Steven', '123sjeanne456' , 'steven@mail.com', '1996-07-17', 'Valreas','0123456789123456','0820','123');
INSERT INTO "clients" ("cliNom","cliPrenom","cliPassword","cliMail","cliDateNaissance","cliLieuNaissance") VALUES ('JOLY', 'Fred', '123fjoly456' , 'fred@mail.fr', '1994-06-09', 'Paris');

INSERT INTO "Magazines" ("magTitre", "magNbVolumeAnnee","magPhotoCouverture","magDescription","magPrixAnnuel") VALUES ('le gorafi' , 365, 'http://www.legorafi.fr/wp-content/themes/legorafi/img/socials.png', 'Le Gorafi est un site d''information trés serieux, créé en mai 2012 durant la campagne présidentielle française',99.99);
INSERT INTO "Magazines" ("magTitre", "magNbVolumeAnnee","magPhotoCouverture","magDescription","magPrixAnnuel") VALUES ('nord presse' , 365, 'https://cdni.rt.com/french/images/2016.10/article/5810e944c36188e3488b456f.jpg', 'Nordpresse est un site d''information belge. Commençant d''abord par s''inspirer de Sudpresse, le site utilise également des noms de domaines ressemblant à ceux de médias français pour crédibiliser ses informations.',99.98);
INSERT INTO "Magazines" ("magTitre", "magNbVolumeAnnee","magPhotoCouverture","magDescription","magPrixAnnuel") VALUES ('le monde' , 365, 'https://static1.ozap.com/articles/6/57/89/36/@/4617206-le-monde-article_default-2.jpg', 'Le Monde est un journal français fondé par Hubert Beuve-Méry en 1944. C''est l''un des derniers quotidiens français dits « du soir », qui paraît, daté du lendemain, à Paris en début d''après-midi ainsi que, un peu plus tard, dans certaines grandes villes, et est distribué en province le matin suivant.',99.98);

INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (1,1,'2019-06-10','2020-06-10',1);
INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (1,2,'2018-08-02','2019-08-02',1);
INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (1,3,'2013-04-08','2014-04-08',0);

INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (2,1,'2013-04-08','2014-04-08',0);
INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (2,2,'2018-08-02','2019-08-02',1);
INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (2,3,'2019-06-10','2020-06-10',1);

INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (3,1,'2018-08-02','2019-08-02',1);
INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (3,2,'2013-04-08','2014-04-08',0);
INSERT INTO "Abonnements" ("aboFKCli", "aboFKMag","aboDateDebut","aboDateFin","aboStatus") VALUES (3,3,'2019-06-10','2020-06-10',1);