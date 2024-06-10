CREATE DATABASE IF NOT EXISTS VoilierCourseDB;
USE VoilierCourseDB;

DROP TABLE IF EXISTS Voiliers;
DROP TABLE IF EXISTS VoiliersInscrits;
DROP TABLE IF EXISTS VoiliersCourse;
DROP TABLE IF EXISTS Personnes;
DROP TABLE IF EXISTS Sponsors;
DROP TABLE IF EXISTS Courses;
DROP TABLE IF EXISTS Epreuves;
DROP TABLE IF EXISTS Penalites;
DROP TABLE IF EXISTS __EFMigrationsHistory;

CREATE TABLE Voiliers (
                          Id INT PRIMARY KEY AUTO_INCREMENT,
                          Code VARCHAR(20)
);

CREATE TABLE VoiliersInscrits (
                                  Id INT PRIMARY KEY,
                                  CodeInscription VARCHAR(20),
                                  CourseId INT,
                                  FOREIGN KEY (Id) REFERENCES Voiliers(Id)
);

CREATE TABLE VoiliersCourse (
                                Id INT PRIMARY KEY,
                                TempsBrute DOUBLE,
                                TempsReel DOUBLE,
                                CourseId1 INT,
                                FOREIGN KEY (Id) REFERENCES VoiliersInscrits(Id)
);

CREATE TABLE Personnes (
                           Id INT PRIMARY KEY AUTO_INCREMENT,
                           Nom VARCHAR(100),
                           Prenom VARCHAR(100),
                           Post VARCHAR(50),
                           VoilierId INT,
                           FOREIGN KEY (VoilierId) REFERENCES Voiliers(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Sponsors (
                          Id INT PRIMARY KEY AUTO_INCREMENT,
                          Nom VARCHAR(100),
                          VoilierInscritId INT,
                          FOREIGN KEY (VoilierInscritId) REFERENCES VoiliersInscrits(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Courses (
                         Id INT PRIMARY KEY AUTO_INCREMENT,
                         Nom VARCHAR(100)
);

CREATE TABLE Epreuves (
                          Numero INT PRIMARY KEY AUTO_INCREMENT,
                          Libelle VARCHAR(100),
                          Ordre INT,
                          CourseId INT,
                          FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Penalites (
                           Id VARCHAR(191) PRIMARY KEY,
                           Duree INT,
                           Description VARCHAR(255),
                           VoilierCourseId INT,
                           FOREIGN KEY (VoilierCourseId) REFERENCES VoiliersCourse(Id)
);

-- Insertion de données d'exemple

INSERT INTO Voiliers (Code) VALUES
                                ('V001'),
                                ('V002'),
                                ('V003'),
                                ('V004'),
                                ('V005');

-- Voiliers Inscrits
INSERT INTO VoiliersInscrits (Id, CodeInscription, CourseId) VALUES
                                                                 (1, 'VI001', 1),
                                                                 (2, 'VI002', 1),
                                                                 (3, 'VI003', 2),
                                                                 (4, 'VI004', 2),
                                                                 (5, 'VI005', 3);

-- Voiliers Course
INSERT INTO VoiliersCourse (Id, TempsBrute, TempsReel, CourseId1) VALUES
                                                                      (1, 123.45, 120.00, 1),
                                                                      (2, 678.90, 670.00, 1),
                                                                      (3, 234.56, 230.00, 2),
                                                                      (4, 789.12, 780.00, 2),
                                                                      (5, 345.67, 340.00, 3);

-- Personnes
INSERT INTO Personnes (Nom, Prenom, Post, VoilierId) VALUES
                                                         ('Dupont', 'Jean', 'Capitaine', 1),
                                                         ('Martin', 'Paul', 'Marin', 2),
                                                         ('Leclerc', 'Marie', 'Capitaine', 3),
                                                         ('Bernard', 'Julie', 'Marin', 4),
                                                         ('Durand', 'Luc', 'Capitaine', 5);

-- Sponsors
INSERT INTO Sponsors (Nom, VoilierInscritId) VALUES
                                                 ('Sponsor1', 1),
                                                 ('Sponsor2', 2),
                                                 ('Sponsor3', 3),
                                                 ('Sponsor4', 4),
                                                 ('Sponsor5', 5);

-- Courses
INSERT INTO Courses (Nom) VALUES
                              ('Course 1'),
                              ('Course 2'),
                              ('Course 3');

-- Epreuves
INSERT INTO Epreuves (Libelle, Ordre, CourseId) VALUES
                                                    ('Epreuve 1.1', 1, 1),
                                                    ('Epreuve 1.2', 2, 1),
                                                    ('Epreuve 2.1', 1, 2),
                                                    ('Epreuve 2.2', 2, 2),
                                                    ('Epreuve 3.1', 1, 3),
                                                    ('Epreuve 3.2', 2, 3);

-- Penalites
INSERT INTO Penalites (Id, Duree, Description, VoilierCourseId) VALUES
                                                                    ('P001', 10, 'Infraction mineure', 1),
                                                                    ('P002', 20, 'Infraction majeure', 2),
                                                                    ('P003', 15, 'Infraction mineure', 3),
                                                                    ('P004', 25, 'Infraction majeure', 4),
                                                                    ('P005', 5, 'Infraction mineure', 5);