DROP DATABASE IF EXISTS Proyecto;
CREATE DATABASE Proyecto;
USE Proyecto;

CREATE TABLE Roles(
RolUsuario int primary key,
NombreRol varchar(30)
);

INSERT INTO Roles(RolUsuario,NombreRol) VALUES 
(1,"ADMINISTRADOR"),
(3,"CLIENTE"),
(2,"SOCIO");

CREATE TABLE usuarios(
CodUsuario int auto_increment PRIMARY KEY,
NombreUsuario varchar (20),
PasswordUsuario varchar (15),
RolUsuario int,
Activo boolean default true,
constraint fk_usuario foreign key(RolUsuario) references roles(RolUsuario)
);

CREATE TABLE clientes(
idCliente int auto_increment PRIMARY KEY,
nombre varchar (20),
apellido varchar (20),
dni int,
aptoFisico bool,
esSocio bool
);

CREATE TABLE actividades(
	codActividad int auto_increment PRIMARY KEY,
    nombre varchar(30),
    precio float,
    horario datetime,
    cupo int,
    cupoDisponible int
);

CREATE TABLE cliente_actividad(
	idCliente int,
    codActividad int,
    PRIMARY KEY(idCliente, codActividad),
    FOREIGN KEY (idCliente) REFERENCES clientes(idCliente),
    FOREIGN KEY (codActividad) REFERENCES actividades(codActividad)
);

CREATE TABLE cuotas(
	idCuota int auto_increment primary key,
    fechaUltimoPago date,
    valorCuota float,
    formaPago varchar(30),
    fechaVencimiento date,
    idCliente int,
    FOREIGN KEY (idCliente) REFERENCES clientes(idCliente)
);
INSERT INTO usuarios (NombreUsuario,PasswordUsuario,RolUsuario) values 
("admin","admin",1);


delimiter //  
create procedure IngresoLogin(in Usu varchar(20),in Pass varchar(15))

/* =============================================================================
Se colocan dos parametros de entrada por eso son in
uno para el nombre de usuario y el otro para la contraseña
observar que la longitud debe ser igual que la longitud del atributo de la tabla
===================================================================================  */
begin
  /* proyecto en la consulta el rol que tiene el usuario que ingresa */
  
  select NombreRol
	from usuarios u inner join roles r on u.RolUsuario = r.RolUsuario
		where NombreUsuario = Usu and PasswordUsuario = Pass /* se compara con los parametros */
			and Activo = 1; /* el usuario debe estar activo */


end 
//

create procedure NuevoCliente(in Nom varchar(20),in Ape varchar(20),in clientDni int, in aptoFisico bool, esSocio bool, out rta int)
 begin
	 declare existe int default 0;
    
     
		/* ---------------------------------------------------------
			para saber si ya esta almacenado el postulante
		------------------------------------------------------- */	
		set existe = (select idCliente from clientes where dni = clientDni );
	 
	  if existe is null then	 
		 insert into clientes(nombre,apellido,dni,aptoFisico,esSocio) values(Nom,Ape,clientDni,aptoFisico,esSocio);
		 set rta  =  (SELECT LAST_INSERT_ID());
	  else
		 set rta = -1;
      end if;		 
    
     end //



delimiter ;
