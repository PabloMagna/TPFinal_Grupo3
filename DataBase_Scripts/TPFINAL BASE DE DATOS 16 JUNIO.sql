go
CREATE DATABASE DBTPFinalGRUPO3;
go
USE DBTPFinalGRUPO3;
GO


GO

CREATE TABLE Provincias (
  ID int NOT NULL ,
  Nombre varchar(255) NOT NULL,
  PRIMARY KEY (ID)
) 

GO
CREATE TABLE Localidades (
  ID int NOT NULL ,
  IDProvincia INT NOT NULL,
  Nombre varchar(255) NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (IDProvincia) REFERENCES Provincias(ID) );



GO
CREATE TABLE Usuarios (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDTipoUsuario INT NOT NULL,
	Contrasenia VARCHAR(20) NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL,
	Estado INT NOT NULL,
	EsAdmin BIT NOT NULL,
);
GO


GO
CREATE TABLE Personas (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDUsuario INT NOT NULL,
	Dni INT NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Apellido VARCHAR(20) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	UrlImagen VARCHAR(500),
	IDLocalidad INT NOT NULL,
	IDProvincia INT NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID),
	FOREIGN KEY (IDProvincia) REFERENCES Provincias(ID),
	FOREIGN KEY (IDLocalidad) REFERENCES Localidades(ID)
);
GO
CREATE TABLE Refugios (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDUsuario INT NOT NULL,
	Direccion VARCHAR(30) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	UrlImagen VARCHAR(500),
	IDLocalidad INT NOT NULL,
	IDProvincia INT NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID),
	FOREIGN KEY (IDProvincia) REFERENCES Provincias(ID),
	FOREIGN KEY (IDLocalidad) REFERENCES Localidades(ID)
);
GO

CREATE TABLE Mascotas (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Especie INT NOT NULL,
	Raza VARCHAR(20) NOT NULL,
	Edad INT NOT NULL,
	Sexo CHAR NOT NULL,
	Descripcion VARCHAR(200) NOT NULL,
	Estado INT NOT NULL
);
GO

CREATE TABLE Publicaciones (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDMascota INT NOT NULL,
	IDUsuario INT NOT NULL,
	Descripcion VARCHAR(500) NOT NULL,
	Titulo VARCHAR(50) NOT NULL,
	FechaHora datetime NOT NULL,
	Estado INT NOT NULL,
	FOREIGN KEY (IDMascota) REFERENCES Mascotas(ID),
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID)
);
GO

CREATE TABLE ImagenesMascota (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDMascota INT NOT NULL,
	UrlImagen VARCHAR(500) NOT NULL,
	FOREIGN KEY (IDMascota) REFERENCES Mascotas(ID)
);
GO

CREATE TABLE Comentarios (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDPublicacion INT NOT NULL,
	Descripcion VARCHAR(300) NOT NULL,
	Estado INT NOT NULL,
	FechaHora datetime NOT NULL,
	FOREIGN KEY (IDPublicacion) REFERENCES Publicaciones(ID)
);
GO

CREATE TABLE Favoritos(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDUsuario int NOT NULL,
	IDPublicacion int NOT NULL,
	Estado int not null,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID),
	FOREIGN KEY (IDPublicacion) REFERENCES Publicaciones(ID)
);

GO

CREATE TABLE Historias (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDUsuario INT NOT NULL,
	Descripcion VARCHAR(300) NOT NULL,
	UrlImagen VARCHAR(500) NOT NULL,
	FechaHora datetime NOT NULL,
	Estado INT NOT NULL,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID)
);

GO
CREATE TABLE Adopciones (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	IDUsuario INT NOT NULL,
	IDPublicacion INT NOT NULL,
	Estado INT NOT NULL,
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(ID),
	FOREIGN KEY (IDPublicacion) REFERENCES Publicaciones(ID)
);