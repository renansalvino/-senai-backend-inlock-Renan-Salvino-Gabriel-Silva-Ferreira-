USE Inlock_Games_Tarde

INSERT TipoUsuario (Titulo)
VALUES ('Cliente'),('Administrador')

INSERT Usuario (Email,Senha,IdTipoUsuario)
VALUES ('admin@admin.com','admin',2),('cliente@cliente.com','cliente',1)

INSERT INTO Estudio (NomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix')

INSERT INTO Jogo (NomeJogo,Descricao,DataLancamento,Valor,IdEstudio)
VALUES ('Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','15/05/2012','R$ 99,00',1),('Red Dead Redemption II','jogo eletrônico de Ação-aventura western','26/10/2018','R$ 120,00',2)

SELECT*FROM TipoUsuario
