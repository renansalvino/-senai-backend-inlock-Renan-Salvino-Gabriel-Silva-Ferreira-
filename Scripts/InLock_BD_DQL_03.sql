USE Inlock_Games_Tarde

-- Listar Todos os Usuarios --
SELECT*FROM Usuario

--Listar Todos os estudios --
SELECT*FROM Estudio

-- Listar todos os jogos --
SELECT*FROM Jogo


--Listar todos os jogos e seus respectivos est�dios --
SELECT		Jogo.NomeJogo, Estudio.NomeEstudio
FROM		Jogo
INNER JOIN	Estudio
ON			Estudio.IdEstudio = Jogo.IdEstudio

--Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listartodos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia --
SELECT		Estudio.NomeEstudio, Jogo.NomeJogo
FROM		Estudio
LEFT JOIN	Jogo
ON			Jogo.IdEstudio = Estudio.IdEstudio

-- Buscar um usu�rio por email e senha --
DECLARE @EMAIL VARCHAR (255)
		,@SENHA  VARCHAR(255)
SET		@EMAIL = 'cliente@cliente.com'
SET		@SENHA = 'cliente'
SELECT	Usuario.Email, Usuario.Senha,  TipoUsuario.Titulo 
FROM	Usuario INNER JOIN TipoUsuario
ON		TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario
WHERE	Email = @EMAIL AND Senha = @SENHA


--Buscar um jogo por IdJogo --
DECLARE @IDjogo INT
SET		@IDjogo = 1
SELECT	NomeJogo,Descricao,DataLancamento,Valor
FROM	Jogo
WHERE	IdJogo =  @IDjogo

--Buscar um est�dio por IdEstudio --
DECLARE @IDestudio INT
SET		@IDestudio = 3
SELECT	NomeEstudio 
FROM	Estudio 
WHERE	IdEstudio = @IDestudio







