
CREATE DATABASE Buscador
USE Buscador

CREATE TABLE Usuarios(
Id Int identity(1,1) primary key not null,
Nombre varchar(50),
Apellido varchar(50),
Edad int
)

CREATE PROCEDURE ListarUsuarios
AS BEGIN
SELECT * FROM Usuarios
END

CREATE PROCEDURE BuscarUsuarios
@TerminoBusqueda VARCHAR(100)
AS BEGIN
SELECT * FROM Usuarios
WHERE Nombre LIKE '%' + @TerminoBusqueda +'%' 
OR Apellido LIKE '%' + @TerminoBusqueda +'%' 
END