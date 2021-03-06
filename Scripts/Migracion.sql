-- INSERTAR Usuario
IF (OBJECT_ID('LOS_SUPER_AMIGOS.crear_usuario') IS NOT NULL)
DROP PROCEDURE LOS_SUPER_AMIGOS.crear_usuario
GO

CREATE PROCEDURE LOS_SUPER_AMIGOS.crear_usuario
	@usuario_id numeric(18,0) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO LOS_SUPER_AMIGOS.Usuario default values
	SET @usuario_id = SCOPE_IDENTITY();
END
GO

-- INSERTAR Direcciones de Empresas
INSERT INTO LOS_SUPER_AMIGOS.Direccion
([calle],[numero],[piso],[depto],[cod_postal])
SELECT DISTINCT Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso, Publ_Empresa_Depto, Publ_Empresa_Cod_Postal
FROM gd_esquema.Maestra
WHERE ISNULL(Publ_Empresa_Dom_Calle,'')!=''

-- INSERTAR Direcciones de Clientes que vendieron
INSERT INTO LOS_SUPER_AMIGOS.Direccion
([calle],[numero],[piso],[depto],[cod_postal])
SELECT DISTINCT Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, Publ_Cli_Depto, Publ_Cli_Cod_Postal
FROM gd_esquema.Maestra
WHERE ISNULL(Publ_Cli_Dom_Calle,'')!=''

-- INSERTAR Direcciones de Clientes que compraron
INSERT INTO LOS_SUPER_AMIGOS.Direccion
([calle],[numero],[piso],[depto],[cod_postal])
SELECT DISTINCT Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal
FROM gd_esquema.Maestra
WHERE ISNULL(Cli_Dom_Calle,'')!='' and not exists (SELECT * FROM LOS_SUPER_AMIGOS.Direccion dir WHERE Cli_Dom_Calle = dir.calle and Cli_Nro_Calle = dir.numero and Cli_Piso = dir.piso and Cli_Depto = dir.depto and Cli_Cod_Postal = dir.cod_postal)

-- INSERTAR Empresas
INSERT INTO LOS_SUPER_AMIGOS.Empresa
   ( [razon_social], [cuit], [fecha_creacion], [mail], [direccion])
SELECT DISTINCT Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Fecha_Creacion, Publ_Empresa_Mail,
	(SELECT DISTINCT id FROM LOS_SUPER_AMIGOS.Direccion d WHERE (Publ_Empresa_Dom_Calle = d.calle and Publ_Empresa_Nro_Calle = d.numero and Publ_Empresa_Piso = d.piso and Publ_Empresa_Depto = d.depto and Publ_Empresa_Cod_Postal = d.cod_postal)) 
FROM gd_esquema.Maestra 
WHERE ISNULL(Publ_Empresa_Razon_Social, '') != ''

DECLARE @row_pos numeric(18,0)
DECLARE @row_count numeric(18,0)
SELECT @row_count = COUNT(*) FROM LOS_SUPER_AMIGOS.Empresa
SET @row_pos = 1

WHILE (@row_pos <= @row_count)
BEGIN
	DECLARE @id_e numeric(18,0)
	EXEC LOS_SUPER_AMIGOS.crear_usuario @id_e OUTPUT
	UPDATE LOS_SUPER_AMIGOS.Empresa SET usuario_id = @id_e WHERE id = @row_pos
	SET @row_pos = @row_pos + 1
END

-- INSERTAR Clientes
-- Todos los clientes que compraron
INSERT INTO LOS_SUPER_AMIGOS.Cliente
   ( [dni], [apellido], [nombre], [fecha_nacimiento], [mail], [direccion])
SELECT DISTINCT Cli_Dni, Cli_Apeliido, Cli_Nombre, Cli_Fecha_Nac, Cli_Mail,
	(SELECT DISTINCT id FROM LOS_SUPER_AMIGOS.Direccion d WHERE (Cli_Dom_Calle = d.calle and Cli_Nro_Calle = d.numero and Cli_Piso = d.piso and Cli_Depto = d.depto and Cli_Cod_Postal = d.cod_postal)) 
FROM gd_esquema.Maestra 
WHERE ISNULL(Cli_DNI, 0) != 0

-- Todos los clientes que vendieron
INSERT INTO LOS_SUPER_AMIGOS.Cliente
   ( [dni], [apellido], [nombre], [fecha_nacimiento], [mail], [direccion])
SELECT DISTINCT Publ_Cli_Dni, Publ_Cli_Apeliido, Publ_Cli_Nombre, Publ_Cli_Fecha_Nac, Publ_Cli_Mail,
	(SELECT DISTINCT id FROM LOS_SUPER_AMIGOS.Direccion d WHERE (Publ_Cli_Dom_Calle = d.calle and Publ_Cli_Nro_Calle = d.numero and Publ_Cli_Piso = d.piso and Publ_Cli_Depto = d.depto and Publ_Cli_Cod_Postal = d.cod_postal)) 
FROM gd_esquema.Maestra as m
WHERE ISNULL(Publ_Cli_DNI, 0) != 0 and not exists (SELECT * FROM LOS_SUPER_AMIGOS.Cliente as c WHERE m.Publ_Cli_Dni = c.dni)

SELECT @row_count = COUNT(*) FROM LOS_SUPER_AMIGOS.Cliente
SET @row_pos = 1

WHILE (@row_pos <= @row_count)
BEGIN
	DECLARE @id_c numeric(18,0)
	EXEC LOS_SUPER_AMIGOS.crear_usuario @id_c OUTPUT
	UPDATE LOS_SUPER_AMIGOS.Cliente SET usuario_id = @id_c WHERE id = @row_pos
	SET @row_pos = @row_pos + 1
END

-- INSERTAR Roles
INSERT INTO LOS_SUPER_AMIGOS.Rol(nombre)
VALUES('Administrador')

INSERT INTO LOS_SUPER_AMIGOS.Rol(nombre)
VALUES('Cliente')

INSERT INTO LOS_SUPER_AMIGOS.Rol(nombre)
VALUES('Empresa')

-- INSERTAR Roles_x_Usuario
INSERT INTO LOS_SUPER_AMIGOS.Rol_x_Usuario
(
	[rol_id],
	[usuario_id]
)
SELECT (SELECT id FROM LOS_SUPER_AMIGOS.Rol WHERE nombre = 'Empresa'), usuario_id FROM LOS_SUPER_AMIGOS.Empresa
INSERT INTO LOS_SUPER_AMIGOS.Rol_x_Usuario
(
	[rol_id],
	[usuario_id]
)
SELECT (SELECT id FROM LOS_SUPER_AMIGOS.Rol WHERE nombre = 'Cliente'), usuario_id FROM LOS_SUPER_AMIGOS.Cliente

-- INSERTAR Funcionalidad
INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Comprar');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Ofertar');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Vender');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Calificar vendedor');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Preguntar');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Agregar rol');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Deshabilitar rol');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Editar rol');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Crear usuario');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Editar usuario');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Habilitar usuario');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Deshabilitar usuario');

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad
(nombre)
VALUES ('Generar factura');

-- INSERTAR Funcionalidad_por_Rol
-- Agrego a administrador todas las funcionalidades
BEGIN TRANSACTION
	DECLARE @i int;
	SET @i = 0;
	
	WHILE((SELECT COUNT(*) FROM LOS_SUPER_AMIGOS.Funcionalidad) > @i)
	BEGIN
		SET @i = @i + 1;
		INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
		(funcionalidad_id,rol_id)
		VALUES(@i, 1);
	END
COMMIT

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(1,2);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(2,2);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(3,2);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(4,2);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(5,2);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(13,2);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(3,3);

INSERT INTO LOS_SUPER_AMIGOS.Funcionalidad_x_Rol
(funcionalidad_id,rol_id)
VALUES(13,3);

-- INSERTAR Visibilidad
INSERT INTO LOS_SUPER_AMIGOS.Visibilidad
([id],[descripcion],[precio],[porcentaje])
SELECT DISTINCT Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Precio FROM gd_esquema.Maestra
GO

-- INSERTAR Rubro
INSERT INTO LOS_SUPER_AMIGOS.Rubro
([descripcion])
SELECT DISTINCT Publicacion_Rubro_Descripcion FROM gd_esquema.Maestra WHERE ISNULL(Publicacion_Rubro_Descripcion, '') != ''
GO

-- INSERTAR Publicacion
IF (OBJECT_ID('LOS_SUPER_AMIGOS.agregar_id_publ') IS NOT NULL)
DROP FUNCTION LOS_SUPER_AMIGOS.agregar_id_publ
GO

CREATE FUNCTION LOS_SUPER_AMIGOS.agregar_id_publ
(
	@dni numeric(18,0),
	@razon_social nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @id numeric(18,0)
	IF @dni IS NULL
		BEGIN
			SELECT @id = usuario_id FROM LOS_SUPER_AMIGOS.Empresa WHERE razon_social = @razon_social
		END
	ELSE
		BEGIN
			SELECT @id = usuario_id FROM LOS_SUPER_AMIGOS.Cliente WHERE dni = @dni
		END
	RETURN @id
END
GO

-- SET IDENTITY_INSERT to ON.
SET IDENTITY_INSERT LOS_SUPER_AMIGOS.Publicacion ON;
GO

INSERT INTO LOS_SUPER_AMIGOS.Publicacion
([id], [descripcion], [stock], [fecha_inicio], [fecha_vencimiento], [precio], [rubro_id], [visibilidad_id], [usuario_id], [estado], [tipo])
SELECT DISTINCT Publicacion_Cod, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc, Publicacion_Precio, (SELECT id FROM LOS_SUPER_AMIGOS.Rubro r WHERE Publicacion_Rubro_Descripcion = r.descripcion), Publicacion_Visibilidad_Cod, LOS_SUPER_AMIGOS.agregar_id_publ(Publ_Cli_Dni, Publ_Empresa_Razon_Social),Publicacion_Estado,Publicacion_Tipo FROM gd_esquema.Maestra
WHERE ISNULL(Publicacion_Rubro_Descripcion, '') != ''

SET IDENTITY_INSERT LOS_SUPER_AMIGOS.Publicacion OFF;
GO

-- INSERTAR Calificaciones
SET IDENTITY_INSERT LOS_SUPER_AMIGOS.Calificacion ON;
GO

INSERT INTO LOS_SUPER_AMIGOS.Calificacion
([id], [cantidad_estrellas], [descripcion])
SELECT DISTINCT Calificacion_Codigo, Calificacion_Cant_Estrellas, Calificacion_Descripcion FROM gd_esquema.Maestra WHERE ISNULL(Calificacion_Codigo, -1) != -1

SET IDENTITY_INSERT LOS_SUPER_AMIGOS.Calificacion OFF;
GO

-- INSERTAR Ofertas
INSERT INTO LOS_SUPER_AMIGOS.Oferta
([monto], [fecha], [usuario_id], [publicacion_id], [calificacion_id])
SELECT Oferta_Monto, Oferta_Fecha, (SELECT usuario_id FROM LOS_SUPER_AMIGOS.Cliente WHERE dni = Cli_Dni), Publicacion_Cod, Calificacion_Codigo FROM gd_esquema.Maestra
WHERE ISNULL(Oferta_Monto, 0) != 0

-- INSERTAR Compras
INSERT INTO LOS_SUPER_AMIGOS.Compra
([cantidad], [fecha], [usuario_id], [publicacion_id], [calificacion_id])
SELECT Compra_Cantidad, Compra_Fecha, (SELECT usuario_id FROM LOS_SUPER_AMIGOS.Cliente WHERE dni = Cli_Dni), Publicacion_Cod, Calificacion_Codigo FROM gd_esquema.Maestra
WHERE ISNULL(Compra_Cantidad, 0) != 0

-- INSERTAR Formas_Pago
INSERT INTO LOS_SUPER_AMIGOS.Forma_Pago
   ( [descripcion])
SELECT DISTINCT Forma_Pago_Desc
FROM gd_esquema.Maestra 
WHERE ISNULL(Forma_Pago_Desc,'') != ''

-- INSERTAR Facturas
INSERT INTO LOS_SUPER_AMIGOS.Factura
   ( [nro], [fecha], [total], [forma_pago_id])
SELECT DISTINCT Factura_Nro, Factura_Fecha, Factura_Total, (SELECT id FROM LOS_SUPER_AMIGOS.Forma_Pago WHERE descripcion = Forma_Pago_Desc)
FROM gd_esquema.Maestra 
WHERE ISNULL(Factura_Nro,-1) != -1

-- INSERTAR Items_Factura
INSERT INTO LOS_SUPER_AMIGOS.Item_Factura
   ( [monto], [cantidad], [factura_nro], [publicacion_id])
SELECT DISTINCT Item_Factura_Monto, Item_Factura_Cantidad, Factura_Nro, Publicacion_Cod
FROM gd_esquema.Maestra 
WHERE ISNULL(Factura_Nro,-1) != -1

