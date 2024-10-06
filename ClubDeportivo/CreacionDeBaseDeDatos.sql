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

INSERT INTO usuarios (NombreUsuario,PasswordUsuario,RolUsuario) values 
("Estiven","123456",1);


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
delimiter ;
