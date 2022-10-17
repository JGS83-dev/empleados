create database registro_empleados

use registro_empleados

create table empleados(
id_empleado int identity(1,1) primary key,
nombre varchar(100) not null,
apellido varchar(100) not null,
telefono varchar(25) not null,
correo varchar(100) not null,
fecha_contratacion date not null)

create table foto_empleado(
id_foto int identity(1,1) primary key,
id_usuario int foreign key references empleados(id_empleado) unique not null,
foto varchar(max) not null)