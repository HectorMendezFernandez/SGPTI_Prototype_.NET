--creamos tabla de usuarios
CREATE TABLE usuarios (
    pk_id INT PRIMARY KEY,
    nombre VARCHAR (50) NOT NULL,
    apellido VARCHAR (50) NOT NULL,
    telefono VARCHAR (50) NOT NULL,
    email VARCHAR (50) NOT NULL,
    contrasena VARCHAR (50) NOT NULL,
	userName VARCHAR (50) NOT NULL
);

--insertamos datos en la tabla
INSERT INTO usuarios(pk_id, nombre, apellido, telefono, email, contrasena, userName)
VALUES (123, 'Cristina','Aguilar',83492019, 'cris@gmail.com','cris123', 'crisUser');

INSERT INTO usuarios(pk_id, nombre, apellido, telefono, email, contrasena, userName)
VALUES (321, 'Francisco','Herrera',8292019, 'fran@gmail.com','fran123', 'franUser');

INSERT INTO usuarios(pk_id, nombre, apellido, telefono, email, contrasena, userName)
VALUES (132, 'Tommy','Aguilar',63492019, 'tom@gmail.com','tom123', 'tomUser');

--seleccionamos todas las filas
select * from usuarios;

--eliminamos tabla de usuarios
drop table usuarios;