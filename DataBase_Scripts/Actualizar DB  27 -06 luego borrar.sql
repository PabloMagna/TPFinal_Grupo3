use DBTPFinalGRUPO3
go
-- Paso 1: Agregar una columna temporal nullable
ALTER TABLE Comentarios
ADD IDUsuarioTemp INT NULL;
go
-- Paso 2: Actualizar los valores de la columna temporal
UPDATE Comentarios
SET IDUsuarioTemp = (
    SELECT TOP 1 IDUsuario
    FROM Publicaciones
    WHERE Publicaciones.ID = Comentarios.IDPublicacion
);
go
-- Paso 3: Agregar restricción NOT NULL a la columna temporal
ALTER TABLE Comentarios
ALTER COLUMN IDUsuarioTemp INT NOT NULL;

-- Paso 4: Renombrar la columna temporal
EXEC sp_rename 'Comentarios.IDUsuarioTemp', 'IDUsuario', 'COLUMN';
go
-- Paso 5: Agregar la clave foránea
ALTER TABLE Comentarios
ADD FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID);

select * from Comentarios


go
--CREACION DE TABLA DE ImagenesUsuarios
CREATE TABLE ImagenesUsuarios(
	ID int PRIMARY KEY IDENTITY(1,1),
	IDUsuario int FOREIGN KEY REFERENCES Usuarios(ID),
	UrlImagen varchar(500) NULL
);