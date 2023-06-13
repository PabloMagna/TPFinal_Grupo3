CREATE DATABASE DBTPFinalGRUPO3;
GO

USE DBTPFinalGRUPO3;
GO

CREATE TABLE Usuarios (
	IDUsuario INT IDENTITY(1,1) PRIMARY KEY,
	IDTipoUsuario INT NOT NULL,
	Contraseña VARCHAR(20) NOT NULL,
	UrlImagen VARCHAR(200),
	Email VARCHAR(50) NOT NULL,
	Localidad VARCHAR(30),
	Provincia VARCHAR(30),
	Telefono VARCHAR(20),
	Estado INT NOT NULL
);
GO

CREATE TABLE Personas (
	IDPersona INT IDENTITY(1,1) PRIMARY KEY,
	Dni INT NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Apellido VARCHAR(20) NOT NULL,
	FechaNacimiento DATE
);
GO

CREATE TABLE Refugios (
	IDRefugio INT IDENTITY(1,1) PRIMARY KEY,
	Direccion VARCHAR(30),
	Nombre VARCHAR(20)
);
GO

CREATE TABLE Mascotas (
	IDMascota INT IDENTITY(1,1) PRIMARY KEY,
	Especia VARCHAR(20) NOT NULL,
	Raza VARCHAR(20) NOT NULL,
	Edad INT,
	Sexo CHAR,
	Descripcion VARCHAR(200),
	Estado INT NOT NULL
);
GO

CREATE TABLE Publicacion (
	IDPublicacion INT IDENTITY(1,1) PRIMARY KEY,
	IDMascota INT NOT NULL,
	IDUsuario INT NOT NULL,
	Descripcion VARCHAR(500) NOT NULL,
	Titulo VARCHAR(50) NOT NULL,
	Estado INT NOT NULL,
	FOREIGN KEY (IDMascota) REFERENCES Mascotas(IDMascota),
	FOREIGN KEY (IDUsuario) REFERENCES Usuarios(IDUsuario)
);
GO

CREATE TABLE ImagenesMascota (
	IDImagen INT IDENTITY(1,1) PRIMARY KEY,
	IDMascota INT NOT NULL,
	FOREIGN KEY (IDMascota) REFERENCES Mascotas(IDMascota)
);
GO

CREATE TABLE Comentarios (
	IDComentario INT IDENTITY(1,1) PRIMARY KEY,
	IDPublicacion INT NOT NULL,
	Descripcion VARCHAR(300) NOT NULL,
	Estado INT NOT NULL,
	FOREIGN KEY (IDPublicacion) REFERENCES Publicacion(IDPublicacion)
);
GO

CREATE TABLE Contacto (
	IDContacto INT IDENTITY(1,1) PRIMARY KEY,
	IDAdoptante INT,
	IDDonante INT,
	IDMascota INT,
	Estado INT NOT NULL,
	FOREIGN KEY (IDAdoptante) REFERENCES Usuarios(IDUsuario),
	FOREIGN KEY (IDDonante) REFERENCES Usuarios(IDUsuario),
	FOREIGN KEY (IDMascota) REFERENCES Mascotas(IDMascota)
);
GO
