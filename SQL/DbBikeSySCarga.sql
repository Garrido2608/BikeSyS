USE BikeSys;
GO


-- ROLES

INSERT INTO Rol (Nombre) VALUES 
('Admin'),
('Empleado'),
('Cliente');
GO

-- USUARIOS

INSERT INTO Usuario (Email, Clave, Activo, IdRol) VALUES 
('admin@test.com', '123456', 1, 1),
('edu@empleado.com', '1234', 1, 2);
GO

-- ESTADOS

INSERT INTO Estado (Nombre) VALUES 
('Recibido'),
('Finalizado');
GO


-- PROVINCIAS

INSERT INTO Provincia (Nombre) VALUES 
('Córdoba'),
('Buenos Aires'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Corrientes'),
('Entre Ríos'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquén'),
('Río Negro'),
('Salta'),
('San Juan'),
('San Luis'),
('Santa Cruz'),
('Santa Fe'),
('Santiago del Estero'),
('Tierra del Fuego'),
('Tucumán');
GO


-- LOCALIDADES

INSERT INTO Localidad (Nombre, IdProvincia) VALUES 
('Córdoba Capital', 1),
('Villa Allende', 1),
('La Calera', 1),
('Villa Carlos Paz', 1),
('Alta Gracia', 1),
('Río Ceballos', 1),
('Mendiolaza', 1);
GO


-- MARCAS 

INSERT INTO Marca (Nombre) VALUES 
('Venzo'),
('Vairo'),
('SLP'),
('Specialized'),
('Giant');
GO


-- MODELOS 

INSERT INTO Modelo (TipoModelo) VALUES 
('Mountain Bike (MTB)'),
('BMX'),
('Ruta / Pista'),
('Urbana'),
('Enduro');
GO


-- TIPO DE RUEDA

INSERT INTO TipoRueda (Nombre) VALUES 
('Rodado 12'),
('Rodado 16'),
('Rodado 20 (BMX / Plegable)'),
('Rodado 24 (Juvenil)'),
('Rodado 26'),
('Rodado 27.5'),
('Rodado 28 / 700c (Ruta / Urbana)'),
('Rodado 29');
GO


-- REPUESTOS 

INSERT INTO Repuesto (Nombre, Precio, Stock) VALUES 
('Cámara Rodado 16', 5500.00, 15),
('Cámara Rodado 20', 6200.00, 20),
('Cámara Rodado 26', 7500.00, 25),
('Cámara Rodado 27', 8200.00, 18),
('Cámara Rodado 28', 8500.00, 15),
('Cámara Pico Auto', 9000.00, 30),
('Pastillas de Freno a Disco', 6800.00, 40),
('Patines de Freno V-Brake', 3500.00, 35),
('Cubierta MTB Rodado 29', 28500.00, 12),
('Cubierta BMX Rodado 20', 22000.00, 10),
('Cubierta Urbana Rodado 26', 19500.00, 14),
('Cadena Shimano 8v', 24000.00, 10),
('Piñón a Rosca 7 Velocidades', 16500.00, 8),
('Juego de Dirección Ahead 1 1/8"', 12000.00, 10),
('Caja Pedalera Sellada a Rulemanes', 18000.00, 12),
('Cable y Funda de Freno / Cambio', 4200.00, 50),
('Puños de Goma / Silicona (Par)', 5800.00, 20),
('Pedales de Aluminio Plataforma (Par)', 14500.00, 15);
GO


-- TIPOS DE SERVICIO

INSERT INTO TipoServicio (Nombre, Precio) VALUES 
('Service Completo', 35000.00),
('Cambio de Juego de Dirección', 8500.00),
('Cambio de Frenos', 7000.00),
('Cambio de Manillar', 6500.00),
('Centrado de Rueda (por rueda)', 9000.00),
('Purgado de Freno Hidráulico', 12000.00),
('Cambio de Caja Pedalera', 11000.00),
('Colocación de Cámara / Parche por Pinchadura', 4000.00);
GO