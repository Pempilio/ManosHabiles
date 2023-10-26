use BDmanosHabiles

create table Administrador(
	cAdmin int primary key,
	nombre varchar(100),
	apellido varchar(100),
	correo varchar(100),
	passwrd varchar(100))

create table Especialidad(
	cEspe int primary key,
	nombre varchar(100))

create table Motivo(
	cMotivo int primary key,
	nombre varchar(100))

create table Asunto(
	cAsunto int primary key,
	nombre varchar(100))

create table Sexo(
	cSexo int primary key, -- masculino 1 | femenino 0 
	nombre varchar(100))

create table Cliente(
	cCliente int primary key,
	nombre varchar(100),
	apellido varchar(200),
	codigoPost int, -- zona
	correo varchar(100),
	passwrd varchar(100),
	fechaNaci datetime,
	estatus int, -- activo 1 | inactivo 0 
	descripcion varchar(300),
	cSexo int references Sexo)

create table Profesionista(
	cProf int primary key,
	nombre varchar(100),
	apellido varchar(100),
	codigoPost int,
	correo varchar(100),
	passwrd varchar(100),
	fechaNaci datetime,
	anosExp int,
	descripcion varchar(100),
	estatus int, -- activo 1 | inactivo 0 --
	cEspe int references Especialidad,
	cSexo int references Sexo)

create table Notificaciones(
	cNotif int primary key,
	fecha datetime,
	cAsunto int references Asunto,
	cCliente int references Cliente,
	cProf int references Profesionista
	)

create table Reporte(
	folio int primary key,
	fecha datetime,
	descripcion varchar(300),
	cMotivo int references Motivo
	)

create table genera(
	folio int references Reporte,
	cCliente int references Cliente,
	cProf int references Profesionista,
	primary key(folio,cCliente))

create table Anuncio(
	cAnuncio int primary key,
	semanas int,
	monto real,
	diasDescanso int,
	estancia int, -- true 1 | false 0 --
	edad int,
	descripcion varchar(200),
	horaEntrada time,
	horaSalida time,
	fechaInicio date,
	cEspe int references Especialidad,
	visibilidad int, -- visible 1 | oculto 0 --
	cCliente int references Cliente
	)
