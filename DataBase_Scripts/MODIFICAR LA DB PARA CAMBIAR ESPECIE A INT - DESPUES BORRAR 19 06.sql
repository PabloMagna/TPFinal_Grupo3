-- Paso 1: Realiza una copia de seguridad de la base de datos

-- Paso 2: Verifica restricciones y dependencias
USE DBTPFinalGRUPO3
-- Paso 3: Agrega una nueva columna
ALTER TABLE Mascotas
ADD NumeroEspecie INT; -- Puedes ajustar el valor predeterminado según corresponda

-- Paso 4: Actualiza los valores de la nueva columna
UPDATE Mascotas
SET NumeroEspecie = CASE
    WHEN Especie = 'Perro' THEN 1
    WHEN Especie = 'Gato' THEN 2
    -- Añade más casos según los valores existentes en la columna VARCHAR y su correspondiente valor INT
    ELSE 0 -- Valor predeterminado para casos no especificados
    END;

-- Paso 5: Verifica los datos actualizados

-- Paso 6: Actualiza dependencias y restricciones (si es necesario)

-- Paso 7: Elimina la columna antigua
ALTER TABLE Mascotas
DROP COLUMN Especie;

SELECT * FROM Mascotas
