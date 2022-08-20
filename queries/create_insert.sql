create table usuarios(
pk_id int primary key,
nombre varchar(30) not null,
apellido varchar(30) not null,
telefono varchar(30),
email varchar(30) not null,
contrasena varchar(30) not null,
);

insert into usuarios (pk_id, nombre, apellido, telefono, email, contrasena)
values(123, 'Cristina', 'Aguilar', '88449910', 'cris@gmail.com', 'cris123');

insert into usuarios (pk_id, nombre, apellido, telefono, email, contrasena)
values(321, 'Francisco', 'Mendoza', '78652610', 'fran@gmail.com', 'fran123');

insert into usuarios (pk_id, nombre, apellido, telefono, email, contrasena)
values(312, 'Tomyy', 'Herrera', '60249910', 'tommy@gmail.com', 'tommy123');

select pk_id,nombre,apellido,telefono,email,contrasena from usuarios where nombre= 'Cristina' and contrasena='cris123';