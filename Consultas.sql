use BDmanosHabiles

insert into Sexo values(0,'Mujer')
insert into Sexo values(1,'Hombre')

select cSexo,nombre from Sexo

insert into Especialidad values(1,'Enfermeria')
insert into Especialidad values(2,'Mecanica')

select cEspe,nombre from Especialidad

insert into Profesionista values((select Isnull(max(cProf),0)+1 from Profesionista),
	'Emilio','Medina',14250,'emilio@gmail.com','emiliopwd','08-18-2004',3,'Me gusta la sandia',
	0,1,1)

select cProf,nombre,Profesionista.codigoPost from Profesionista where correo='emilio@gmail.com' and passwrd='emiliopwd'

select * from Profesionista

--Insertamos unos asuntos
insert into Asunto values(1,'Alguien está interesado en ti')
insert into Asunto values(2,'Alguien está interesado en tu anuncio')

select * from Anuncio

insert into Cliente values((select isnull(max(cCliente),0)+1 from Cliente),'Felipe','Mejia',
	15800,'felipe@gmail.com','felipepwd','12-07-1967',1,'Mi padre es una persona con taquicardía',1)

insert into Anuncio values (1,3,4000,2,1,84,'Busco asistente medico para persona con taquicardía',
	'8:00','17:00','10-28-2023',1,1,1)

insert into Anuncio values (2,3,4000,2,1,84,'Busco mecanico para mantenimiento de Porche 911 carrera',
	'8:00','17:00','10-28-2023',2,1,1)

select Cliente.cCliente as 'Num',Cliente.nombre as 'Nombre',Anuncio.descripcion as 'Descripción',Cliente.codigoPost as 'CP', Anuncio.monto as 'Sueldo',Sexo.nombre as 'Sexo'
	from Anuncio inner join Cliente on Cliente.cCliente=Anuncio.cCliente
	inner join Sexo on Cliente.cSexo=Sexo.cSexo
	where Anuncio.cEspe=1 and
		Cliente.codigoPost=15800 and
		Sexo.cSexo = 1
	order by Anuncio.monto desc

select cEspe from Profesionista where cProf=1

select Cliente.nombre,Cliente.codigoPost,Anuncio.semanas,Anuncio.monto,Anuncio.diasDescanso,
	Anuncio.edad,Anuncio.horaEntrada,Anuncio.horaSalida,Anuncio.fechaInicio,Anuncio.descripcion
	from Anuncio inner join Cliente on Anuncio.cCliente=Cliente.cCliente
	where Anuncio.cAnuncio = 1

select Cliente.cCliente from Cliente 
	inner join Anuncio on Cliente.cCliente=Anuncio.cCliente
	where Anuncio.cAnuncio = 1

select * from Notificaciones
insert into Notificaciones values((select isnull(max(cNotif),0)+1 from Notificaciones),CURRENT_TIMESTAMP,
	2,1,1)

insert into Notificaciones values((select isnull(max(cNotif),0)+1 from Notificaciones),CURRENT_TIMESTAMP,
	1,1,1)

select Cliente.nombre as 'Remitente',Asunto.nombre as 'Asunto',Anuncio.descripcion as 'Para este trabajo',Anuncio.cAnuncio as 'Num'
	from Notificaciones inner join Asunto on Asunto.cAsunto=Notificaciones.cAsunto
		inner join Cliente on Cliente.cCliente=Notificaciones.cCliente
		inner join Anuncio on Anuncio.cCliente=Cliente.cCliente
	where Notificaciones.cProf = 1 and Asunto.cAsunto = 1 and Anuncio.cEspe = 1

select Profesionista.cEspe from Profesionista where Profesionista.cProf = 1

select nombre,apellido,correo,passwrd,codigoPost,descripcion from Profesionista where Profesionista.cProf = 1

update Profesionista set nombre = 'Emilio', apellido='Medina',correo='emilio@gmail.com',passwrd='emiliopwd',codigoPost='14250',descripcion='me gusta el mamey' where Profesionista.cProf=1

select * from Profesionista