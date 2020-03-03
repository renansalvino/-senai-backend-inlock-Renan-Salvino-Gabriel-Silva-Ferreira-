CREATE DATABASE Inlock_Games_Tarde

USE Inlock_Games_Tarde

--Criando Tabela de Estudio
CREATE TABLE Estudio (
IdEstudio		INT PRIMARY KEY IDENTITY
,NomeEstudio	VARCHAR(255)
);


--Criando tabela de jogo
CREATE TABLE Jogo (
IdJogo			INT PRIMARY KEY IDENTITY
,NomeJogo		VARCHAR (255)
,Descricao		VARCHAR (255)
,DataLancamento DATETIME
,Valor			VARCHAR (255)
,IdEstudio		INT FOREIGN KEY REFERENCES Estudio (IdEstudio)
);

--Criando tabela de Tipo de Usuario
CREATE TABLE TipoUsuario (
IdTipoUsuario		INT PRIMARY KEY IDENTITY
,Titulo				VARCHAR (255)
);

--Criando tabela de Usuario
CREATE TABLE Usuario (
IdUsuario		INT PRIMARY KEY  IDENTITY
,Email			VARCHAR(255)
,Senha			VARCHAR (255)
,IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);







