/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Person (Lastname, Firstname, PictureURL) VALUES ('Hammil', 'Mark', 'https://resize-elle.ladmedia.fr/rcrop/638,,forcex/img/var/plain_site/storage/images/loisirs/cinema/dossiers/que-sont-ils-devenus-les-acteurs-de-star-wars/mark-hamill2/92295653-1-fre-FR/Mark-Hamill.jpg')
INSERT INTO Person (Lastname, Firstname, PictureURL) VALUES ('Ford', 'Harisson', 'https://m.media-amazon.com/images/M/MV5BMTY4Mjg0NjIxOV5BMl5BanBnXkFtZTcwMTM2NTI3MQ@@._V1_FMjpg_UX1000_.jpg')
INSERT INTO Person (Lastname, Firstname, PictureURL) VALUES ('Fisher', 'Carrie', 'https://resize.elle.fr/portrait/var/plain_site/storage/images/people/la-vie-des-people/news/carrie-fisher-le-message-d-outre-tombe-de-la-princesse-leia-qui-a-emu-sa-famille-3829301/92306648-1-fre-FR/Carrie-Fisher-le-message-d-outre-tombe-de-la-princesse-Leia-qui-a-emu-sa-famille.jpg')
INSERT INTO Person (Lastname, Firstname, PictureURL) VALUES ('Lucas', 'George', 'https://fr.web.img6.acsta.net/pictures/15/12/18/10/51/568937.jpg')
INSERT INTO Person (Lastname, Firstname, PictureURL) VALUES ('Spielberg', 'Steven', 'https://fr.web.img5.acsta.net/pictures/16/05/17/11/39/453609.jpg')


INSERT INTO Movie (Title, Description, RealisatorID) VALUES ('Star Wars - A New Hope', 'Space-opera', 4)
INSERT INTO Movie (Title, Description, RealisatorID) VALUES ('Star Wars - Empire Strikes Back','Space-opera', 4)
INSERT INTO Movie (Title, Description, RealisatorID) VALUES ('Indiana Jones - Cursed temple','Film d''aventure', 5)

INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (1, 1, 'Luke Skywalker')
INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (2, 1, 'Han Solo')
INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (3, 1, 'Leia Organa')
INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (1, 2, 'Luke Skywalker')
INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (2, 2, 'Han Solo')
INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (3, 2, 'Leia Organa')
INSERT INTO Movie_Person (PersonId, MovieId, Role) VALUES (2, 3, 'Indiana Jones')