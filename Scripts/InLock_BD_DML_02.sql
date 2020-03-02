USE Inlock_Games_Tarde

INSERT TipoUsuario (Titulo)
VALUES ('Cliente'),('Administrador')

INSERT Usuario (Email,Senha,IdTipoUsuario)
VALUES ('admin@admin.com','admin',2),('cliente@cliente')

INSERT INTO Estudio (NomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix')

SELECT*From Estudio