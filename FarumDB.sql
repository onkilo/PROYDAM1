if DB_ID('Farum') is not null
begin
	drop database Farum
end
go

create database Farum
go

use Farum
go

if OBJECT_ID('Usuario') is not null
begin
	drop table Usuario
end
go

create table Usuario
(
	IdUsuario int identity(1,1) primary key,
	Nombre varchar(100) not null,
	Correo varchar(100) not null unique,
	Telefono varchar(100),
	Contrasenia varchar(500),
	Direccion varchar(100),
	Activo char(2) default '01'
)
go

if OBJECT_ID('Genero') is not null
begin
	drop table Genero
end
go

create table Genero
(
	IdGenero int identity(1,1) primary key,
	Descripcion varchar(100) not null,
	Activo char(2) default '01'
)
go

if OBJECT_ID('Autor') is not null
begin
	drop table Autor
end
go

create table Autor
(
	IdAutor int identity(1,1) primary key,
	Nombres varchar(100) not null,
	Activo char(2) default '01'
)
go

if OBJECT_ID('Libro') is not null
begin
	drop table Libro
end
go

create table Libro
(
	IdLibro int identity(1,1) primary key,
	Nombre varchar(100) not null,
	Resenia varchar(500),
	Imagen varchar(100),
	FechaRegistro Date default GETDATE(),
	FechaAdquisicion date,
	Estado varchar(100),
	IdGenero int,
	IdAutor int,
	IdUsuario int,
	Activo char(2) default '01',
	Constraint fk_libro_genero Foreign key  (IdGenero) references Genero(IdGenero),
	Constraint fk_libro_autor Foreign key  (IdAutor) references Autor(IdAutor),
	Constraint fk_libro_usuaio Foreign key  (IdUsuario) references Usuario(IdUsuario)
)
go


if OBJECT_ID('Intercambio') is not null
begin
	drop table Intercambio
end
go

create table Intercambio
(
	IdIntercambio int identity(1,1) primary key,
	IdUsuIni int ,
	IdUsuDestino int,
	Direccion varchar(100),
	FechaIniciado Date default GETDATE(),
	FechaIntercambio date,
	HoraIntercambio varchar(10),
	IdLibroElegido int,
	IdLibroOfrecido int,
	Activo char(2) default '01',
	Estado varchar(2) default '01',
	Constraint fk_inter_libroelegido Foreign key  (IdLibroElegido) references Libro(IdLibro),
	Constraint fk_inter_libroofrecido Foreign key  (IdLibroOfrecido) references Libro(IdLibro),
	Constraint fk_inter_usuini Foreign key  (IdUsuIni) references Usuario(IdUsuario),
	Constraint fk_inter_usudest Foreign key  (IdUsuDestino) references Usuario(IdUsuario)
)
go

insert into Genero(Descripcion) values
('Novela'),
('Drama'),
('Épico'),
('Comedia'),
('Poesía'),
('Policiáco'),
('Misterio'),
('Historia'),
('Ciencia'),
('Física'),
('Programación'),
('Otro')
go

insert into Autor(Nombres) values
('Anónimo'),
('Homero'),
('Virgilio'),
('Dante Alighieri'),
('Mario Vargas Llosa'),
('Ciro Alegría'),
('César Vallejo'),
('J.R.R. Tolkien'),
('J. K. Rowling'),
('Stephen King'),
('Otro')