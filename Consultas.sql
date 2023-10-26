use BDmanosHabiles

insert into Sexo values(0,'Mujer')
insert into Sexo values(1,'Hombre')

select cSexo,nombre from Sexo

insert into Especialidad values(1,'Enfermeria')

select cEspe,nombre from Especialidad

insert into Profesionista values((select Isnull(max(cProf),0)+1 from Profesionista),
	'Emilio','Medina',14250,'emilio@gmail.com','emiliopwd','08-18-2004',3,'Me gusta la sandia',
	0,1,1)

select cProf,nombre from Profesionista where correo='emilio@gmail.com' and passwrd='emiliopwd'

select * from Profesionista

--Insertamos unos asuntos
insert into Asunto values(1,'Alguien está interesado en ti')
insert into Asunto values(2,'Alguien está interesado en tu anuncio')

select * from Anuncio

insert into Cliente values((select isnull(max(cCliente),0)+1 from Cliente),'Felipe','Mejia',
	15800,'felipe@gmail.com','felipepwd','12-07-1967',1,'Mi padre es una persona con taquicardía',1)

insert into Anuncio values (1,3,4000,2,1,84,'Busco asistente medico para persona con taquicardía',
	'8:00','17:00','10-28-2023',1,1,1)

select Cliente.nombre as 'Nombre',Anuncio.descripcion as 'Descripción',Cliente.codigoPost as 'CP', Anuncio.monto as 'Sueldo'
	from Anuncio inner join Cliente on Cliente.cCliente=Anuncio.cCliente
	where Anuncio.cEspe=1 order by Anuncio.monto desc

select cEspe from Profesionista where cProf=1