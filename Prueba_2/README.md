## Directorio para la prueba 1 ##

SENTENCIAS:


// Crear la base de datos y seleccionarla.

CREATE DATABASE pruebatecnica;
USE pruebatecnica;

// Crear la tabla usuarios

CREATE TABLE usuarios (
userId INT(11) NOT NULL AUTO_INCREMENT,
Login VARCHAR(100) NOT NULL,
Nombre VARCHAR(100) NOT NULL,
Paterno VARCHAR(100) NOT NULL,
Materno VARCHAR(100) NOT NULL,
PRIMARY KEY (userId)
);

//Crear la tabla empleados y establecer la relación mediante una llave foranea

CREATE TABLE empleados(
Sueldo DOUBLE NOT NULL,
FechaIngreso DATE NOT NULL,
userId INT(11) NOT NULL,
FOREIGN KEY (userId) REFERENCES usuarios (userId)
);

// Insertar los datos a la tabla de usuarios

INSERT INTO usuarios (Login, Nombre, Paterno, Materno) VALUES
    ('user01', 'BERE', 'NARANJO', 'GONZALEZ'),
    ('user02', 'ALEXIS', 'CAMPOS', 'NARANJO'),
    ('user03', 'SERGIO ALEJANDRO', 'CAMPOS', 'HERNANDEZ'),
    ('user04', 'DIEGO ISMAEL', 'BERUMEN', 'CEDILLO'),
    ('user05', 'AURORA', 'ESCALANTE', 'PALAFOX'),
    ('user06', 'JOYCELENE FABIOLA', 'ESTRADA', 'BARBA'),
    ('user07', 'FRANCISCO', 'ESTRADA', 'GOMEZ'),
    ('user08', 'LEONARDO DANIEL', 'FARIAS', 'ROSAS'),
    ('user09', 'RAMON ANDRES', 'FIERROS', 'ROBLES'),
    ('user10', 'EDGARD ANDRES', 'FLORES', 'OLIVARES'),
    ('user11', 'MARIA FERNANDA', 'FRANCO', 'ESQUIVEL'),
    ('user12', 'ALEJANDRO', 'GALVAN', 'MUÑIZ'),
    ('user13', 'MARTHA ALICIA', 'GUTIERREZ', 'ORTIZ'),
    ('user14', 'JOSAFAT GERARDO', 'HERNANDEZ', 'SAUCEDO'),
    ('user15', 'ROSALIA', 'JIMENEZ', 'GONZALEZ'),
    ('user16', 'LAURA CELENE', 'JIMENEZ', 'RIOS'),
    ('user17', 'ANGELICA', 'LOPEZ', 'CORTES'),
    ('user18', 'CRISTIAN IVAN', 'LOPEZ', 'GOMEZ'),
    ('user19', 'MARLENE GABRIELA', 'LOPEZ', 'MEZA'),
    ('user20', 'ALEJANDRA', 'MEDINA', 'IBARRA'),
    ('user21', 'CONSUELO YURIDIANA THALIA', 'MEJIA', 'ALVAREZ'),
    ('user22', 'JAVIER ADRIAN', 'MEJIA', 'ALVAREZ'),
    ('user23', 'JUAN CARLOS EVARISTO', 'PEÑA', 'GUTIERREZ'),
    ('user24', 'JAZMIN ALEJANDRA', 'PEREZ', 'VELEZ'),
    ('user25', 'GUSTAVO', 'RAMIREZ', 'RIVERA'),
    ('user26', 'CARLOS NIVARDO', 'RODRIGUEZ', 'ASCENCIO'),
    ('user27', 'KARLA JOHANA', 'ROMERO', 'LUEVANOS'),
    ('user28', 'YESSICA YOSELINNE', 'RUIZ', 'HERNANDEZ'),
    ('user29', 'CHRISTIAN EDUARDO', 'SALAS', 'SANCHEZ'),
    ('user30', 'LUIS ROBERTO', 'SALDAÑA', 'ESPINOZA'),
    ('user31', 'ADRIAN', 'SANCHEZ', 'ORTIZ'),
    ('user32', 'EDUARDO YAIR', 'SUAREZ', 'HERNANDEZ'),
    ('user33', 'JUAN FRANCISCO', 'TABAREZ', 'GARCIA'),
    ('user34', 'ZULEICA ELIZABETH', 'TERAN', 'TORRES'),
    ('user35', 'ADRIANA YUNUHEN', 'VARGAS', 'ALAYA'),
    ('user36', 'OSCAR URIEL', 'VELAZQUEZ', 'ALVAREZ'),
    ('user37', 'ERICK DE JESUS', 'CORONA', 'DIAZ'),
    ('user38', 'MARIA GUADALUPE', 'RAMOS', 'HERNANDEZ'),
    ('user39', 'JESSICA NOEMI', 'JIMENEZ', 'VENTURA'),
    ('user40', 'FLOR MARGARITA', 'ROJAS', 'HERNANDEZ'),
    ('user41', 'LUIS ANTONIO', 'ALVARADO', 'VALENCIA'),
    ('user42', 'EDGAR IVAN', 'AGUILAR', 'PADILLA'),
    ('user43', 'LUIS ALFONSO', 'MICHEL', 'SANCHEZ'),
    ('user44', 'JOSE CARLOS', 'SILVA', 'ROCHA'),
    ('user45', 'JUDITH', 'RODRIGUEZ', 'REYES'),
    ('user46', 'BRENDA SORAYA', 'CHAVEZ', 'GARCIA'),
    ('user47', 'ALMA ROSA', 'MARQUEZ', 'AGUILA');

// Insertar los datos a la tabla de empleados
INSERT INTO empleados (Sueldo, FechaIngreso, userId) VALUES
    ('8837','2000-01-11','1'),
    ('8837','2000-01-11','2'),
    ('15000','2000-01-11','3'),
    ('15000','2000-01-11','4'),
    ('7812','2000-01-18','5'),
    ('7812','2000-01-18','6'),
    ('10200','2000-01-18','7'),
    ('10200','2000-01-18','8'),
    ('13800','2001-05-20','9'),
    ('13800','2001-05-20','10'),
    ('18880','2001-05-20','11'),
    ('18880','2001-05-20','12'),
    ('8000','2001-07-13','13'),
    ('8000','2001-07-13','14'),
    ('6000','2001-07-13','15'),
    ('19470','2001-07-13','16'),
    ('19470','2001-07-13','17'),
    ('10200','2001-07-16','18'),
    ('10200','2001-07-16','19'),
    ('25000','2001-07-16','20'),
    ('7812','2001-07-16','21'),
    ('7812','2001-07-16','22'),
    ('12210','2001-11-24','23'),
    ('12210','2001-11-24','24'),
    ('7500','2001-11-24','25'),
    ('15020','2001-11-24','26'),
    ('15020','2001-11-24','27'),
    ('25000','2001-11-24','28'),
    ('7812','2001-11-24','29'),
    ('15020','2001-12-12','30'),
    ('15020','2001-12-12','31'),
    ('12210','2001-12-12','32'),
    ('12210','2001-12-12','33'),
    ('19470','2008-08-17','34'),
    ('19470','2008-08-17','35'),
    ('8000','2008-08-17','36'),
    ('8000','2008-08-17','37'),
    ('18880','2009-06-11','38'),
    ('18880','2009-06-11','39'),
    ('14000','2009-06-11','40'),
    ('13800','2009-06-11','41'),
    ('13800','2009-06-11','42'),
    ('15000','2009-10-06','43'),
    ('15000','2009-10-06','44'),
    ('13000','2009-10-06','45'),
    ('8837','2009-10-06','46');

// Depurar solo los ID diferentes de 6,7,9 y 10 de la tabla usuarios

DELETE FROM usuarios WHERE userId NOT IN (6,7,9,10);

//Actualizar el dato Sueldo en un 10 porciento a los empleados que tienen fechas entre el año 2000 y 2001

 UPDATE empleados SET Sueldo = Sueldo * 1.10
    WHERE FechaIngreso BETWEEN '2000-01-01' AND '2001-12-31';

//Realiza una consulta para traer el nombre de usuario y fecha de ingreso de los usuarios que gananen mas de 10000 y su apellido comience con T ordernado del mas reciente al mas antiguo

SELECT u.Login, e.FechaIngreso
    FROM usuarios u
    JOIN empleados e ON u.userId = e.userId
    WHERE e.Sueldo > 10000 AND u.Paterno LIKE 'T%'
    ORDER BY e.FechaIngreso DESC;

//Realiza una consulta donde agrupes a los empleados por sueldo, un grupo con los que ganan menos de 1200 y uno mayor o igual a 1200, ¿cuantos hay en cada grupo?

SELECT
    CASE
    WHEN Sueldo < 1200 THEN 'Menos de 1200'
    ELSE 'Mayor o igual a 1200'
    END AS SueldoGrupo,
    COUNT(*) AS cantidad FROM empleados GROUP BY SueldoGrupo;

*** HAY 46 empleados en el grupo 'Mayor o igual a 1200' y 0 en el grupo 'Menos de 1200' ***








