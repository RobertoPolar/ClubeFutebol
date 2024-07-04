CREATE DATABASE DBCLUBE
GO

USE DBCLUBE
GO

CREATE TABLE ATLETA(
ID_ATLETA INT PRIMARY KEY IDENTITY,
NOME_COMPLETO VARCHAR(255) NOT NULL,
APELIDO VARCHAR(255) NULL,
DATA_NASCIMENTO DATE NOT NULL,
ALTURA DECIMAL(18,2) NOT NULL,
PESO DECIMAL(18,2) NOT NULL,
POSICAO VARCHAR(200) NOT NULL,
NRO_CAMISA INT NOT NULL
)

GO

INSERT INTO 
	[dbo].[ATLETA] ([NOME_COMPLETO],[APELIDO],[DATA_NASCIMENTO],[ALTURA],[PESO],[POSICAO],[NRO_CAMISA])
VALUES
	('Abatte','Abatte','09.22.1902',1.70,90.5,'Defensa',3),
	('Abel','Abel','10.21.1941',1.80,60.5,'Centrocampista',5),
	('Baidek','Baidek','04.16.1960',1.65,60.5,'Defensa',2),
	('Caio','Caio','08.16.1975',1.75,70.5,'Delantero',4),
	('David Neres','David','03.03.1997',1.80,60,'Delantero',6)

GO
----------------------------------------------
CREATE PROCEDURE SP_LISTAR_ATLETAS
AS
BEGIN
	SET DATEFORMAT dmy
	SELECT * FROM ATLETA
END
GO
----------------------------------------------
CREATE PROCEDURE SP_OBTER_ATLETA_POR_ID
@id int 
AS
BEGIN
	SET DATEFORMAT dmy
	SELECT * FROM ATLETA where ID_ATLETA = @id
END
GO
-----------------------------------------------
CREATE PROCEDURE SP_CRIAR_ATLETA
@NOME_COMPLETO VARCHAR(255),
@APELIDO VARCHAR(255),
@DATA_NASCIMENTO DATE,
@ALTURA DECIMAL(18,2),
@PESO DECIMAL(18,2),
@POSICAO VARCHAR(200),
@NRO_CAMISA INT
AS
BEGIN
	INSERT INTO ATLETA (NOME_COMPLETO,APELIDO,DATA_NASCIMENTO,ALTURA,PESO,POSICAO,NRO_CAMISA)
	VALUES (@NOME_COMPLETO,@APELIDO,@DATA_NASCIMENTO,@ALTURA,@PESO,@POSICAO,@NRO_CAMISA)
END
GO
---------------------------------------------------------------------------
CREATE PROCEDURE SP_EDITAR_ATLETA
@ID_ATLETA INT,
@NOME_COMPLETO VARCHAR(255),
@APELIDO VARCHAR(255),
@DATA_NASCIMENTO DATE,
@ALTURA DECIMAL(18,2),
@PESO DECIMAL(18,2),
@POSICAO VARCHAR(200),
@NRO_CAMISA INT
AS
BEGIN
	UPDATE ATLETA
	SET 
		NOME_COMPLETO = @NOME_COMPLETO,
		APELIDO = @APELIDO,
		DATA_NASCIMENTO = @DATA_NASCIMENTO,
		ALTURA = @ALTURA,
		PESO = @PESO,
		POSICAO = @POSICAO,
		NRO_CAMISA = @NRO_CAMISA
	WHERE
		ID_ATLETA = @ID_ATLETA
END
GO
--------------------------------------------------------------------------------
CREATE PROCEDURE SP_ELIMINAR_ATLETA
@ID_ATLETA INT
AS
BEGIN
	DELETE FROM ATLETA WHERE ID_ATLETA = @ID_ATLETA
END
GO
