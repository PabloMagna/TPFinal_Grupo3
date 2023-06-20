-- Agregar nuevas columnas necesarias en la tabla "Publicaciones"
USE DBTPFinalGRUPO3;
GO

ALTER TABLE Publicaciones
ADD IDLocalidad INT NOT NULL DEFAULT 2,
    IDProvincia INT NOT NULL DEFAULT 1;
GO

-- Agregar restricciones de clave externa a las nuevas columnas agregadas
ALTER TABLE Publicaciones
ADD CONSTRAINT FK_Publicaciones_Provincias FOREIGN KEY (IDProvincia) REFERENCES Provincias(ID),
    CONSTRAINT FK_Publicaciones_Localidades FOREIGN KEY (IDLocalidad) REFERENCES Localidades(ID);
GO

