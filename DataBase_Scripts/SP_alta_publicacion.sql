create PROCEDURE SP_alta_publicacion

@titulo VARCHAR(50),
@especie INT,
@Raza VARCHAR(20),
@edad int,
@sexo char(1),
@idUsuario int,
@descripcion VARCHAR(500),
@fecha DATETIME,
@idLocalidad int,
@idProvincia int

AS
insert into Publicaciones values (@titulo, @especie, @Raza, @edad, @sexo, @idUsuario, @descripcion, @fecha, 1, @idLocalidad, @idProvincia)

