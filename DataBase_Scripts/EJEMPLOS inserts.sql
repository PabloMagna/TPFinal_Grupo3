
-- Inserts para la tabla Usuarios
INSERT INTO Usuarios (IDTipoUsuario, Contrasenia, Email, Estado, EsAdmin) VALUES
(1, 'contraseña1', 'usuario1@example.com', 1, 0),
(1, 'contraseña2', 'usuario2@example.com', 1, 0),
(2, 'contraseña3', 'admin@example.com', 1, 1);


-- Inserts para la tabla Personas
INSERT INTO Personas (IDUsuario, Dni, Nombre, Apellido, FechaNacimiento, UrlImagen, IDLocalidad, IDProvincia, Telefono) VALUES
(1, 12345678, 'Juan', 'Pérez', '1990-01-01', 'https://img.freepik.com/foto-gratis/personas-que-sonrie-alegre-hombres-guapos_1187-6057.jpg', 1, 1, '1234567890'),
(2, 23456789, 'María', 'González', '1985-05-10', 'https://example.com/imagen2.jpg', 2, 1, '0987654321');

-- Inserts para la tabla Refugios
INSERT INTO Refugios (IDUsuario, Direccion, Nombre, UrlImagen, IDLocalidad, IDProvincia, Telefono) VALUES
(3, 'Calle 123', 'Refugio Animal', 'https://thumbs.dreamstime.com/b/familia-que-se-familiariza-con-perros-en-refugio-para-animales-123287981.jpg', 3, 2, '9876543210');


-- Inserts para la tabla Publicaciones
INSERT INTO Publicaciones (Especie, Raza, Edad, Sexo, IDUsuario, Descripcion, Titulo, FechaHora, Estado, IDLocalidad, IDProvincia) VALUES
(1, 'Labrador Retriever', 2, 'M',1,'Buscando un hogar para este adorable perro.', 'Adopción de perro', '2023-06-15 10:00:00', 1,2,1),
(2, 'Persa', 1, 'H',2,'Buscando un hogar para este hermoso gato.', 'Adopción de gato', '2023-06-15 11:00:00', 1,2,1),
(1, 'Bulldog Francés', 3, 'M',3, 'Buscando un hogar para este simpático perro.', 'Adopción de perro', '2023-06-15 12:00:00', 1,2,1);

-- Inserts para la tabla ImagenesMascota
INSERT INTO ImagenesMascota (IDPublicacion, UrlImagen) VALUES
(1, 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Golden_Retriever_9-year_old.jpg/1200px-Golden_Retriever_9-year_old.jpg'),
(2, 'https://upload.wikimedia.org/wikipedia/commons/thumb/e/e4/Persian_in_Cat_Cafe.jpg/640px-Persian_in_Cat_Cafe.jpg'),
(3, 'https://example.com/imagen_perro2.jpg');

-- Inserts para la tabla Comentarios
INSERT INTO Comentarios (IDPublicacion, Descripcion, Estado, FechaHora) VALUES
(1, 'Qué hermoso perro, espero que encuentre un hogar pronto.', 1, '2023-06-18 10:30:00'),
(2, 'Me encanta este gato, es muy tierno.', 1, '2023-04-25 15:45:00'),
(3, 'Este perro es genial, ojalá encuentre un hogar donde lo cuiden mucho.', 1, '2023-01-15 09:00:00');


-- Inserts para la tabla Historias
INSERT INTO Historias (IDUsuario, Descripcion, UrlImagen, FechaHora, Estado) VALUES
(1, 'Hoy adopté a un perro y estoy muy feliz.', 'https://www.petclic.es/wikipets/wp-content/uploads/sites/default/files/library/dalmata_-_razas_de_perro.jpg', '2023-06-14 15:00:00', 1),
(2, 'Rescaté a un gatito de la calle, ahora tiene un hogar.', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/94/Gato_%282%29_REFON.jpg/1600px-Gato_%282%29_REFON.jpg', '2023-06-14 16:00:00', 1),
(3, 'Visitamos un refugio y conocimos a muchos animales que necesitan adopción.', 'https://example.com/imagen_historia3.jpg', '2023-06-14 17:00:00', 1);
