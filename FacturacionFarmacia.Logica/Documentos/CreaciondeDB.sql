USE [master]
GO

CREATE DATABASE [facturacionFarmacia]
GO

USE [facturacionFarmacia]
Go

--Crear la tabla Rol
CREATE TABLE [dbo].[Rol](
[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Nombre] [varchar] (50) NOT NULL
)
GO

--Crear la tabla Usuario
CREATE TABLE [dbo].[Usuario] (
	[Id] [int] Primary key Identity(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Dui] [varchar](25) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Numero] [varchar](10) NOT NULL,
	[Login] [varchar](25) NOT NULL,
	[Password] [char](32) NOT NULL,
	[Estado] [TinyInt] NOT NULL,
	[FechaRegistro] [DateTime] NOT NULL,
	CONSTRAINT FK1_Rol_Usuario FOREIGN KEY (IdRol) REFERENCES Rol (Id)
)
GO

--Crear la tabla Tipo
CREATE TABLE [dbo].[Tipo](
[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Nombre] [varchar] (50) NOT NULL
)
GO

--Crear la tabla Producto
CREATE TABLE [dbo].[Producto](
[ID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[IdTipo] [int] NOT NULL,
[Nombre] [varchar](50) NOT NULL,
[Precio] [decimal](12,2) NOT NULL,
[Cantidad] [int] NOT NULL,
[Estado] [TinyInt] NOT NULL,
[Comentario] [varchar](100) NOT NULL,
CONSTRAINT FK1_Tipo_Producto FOREIGN KEY (IdTipo) REFERENCES Tipo (Id)
)
GO

--Crear la tabla Cliente
CREATE TABLE [dbo].[Cliente](
[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Dui] [varchar](50) NOT NULL,
[Nombre] [varchar](50) NOT NULL,
)
GO

--Crear la tabla Factura
CREATE TABLE [dbo].[Factura](
[ID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[IdCliente] [int] NOT NULL,
[EstadoInventario] [TinyInt] NOT NULL,
[FechaRegistro] [DateTime] NOT NULL
)

--Crear la tabla DetalleFactura
CREATE TABLE [dbo].[DetalleFactura](
[ID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
[IDFactura] [int] NOT NULL,
[IdProducto] [int] NOT NULL,
[cantidad] [int]
CONSTRAINT FK1_Factura_DetalleFactura FOREIGN KEY (IDFactura) REFERENCES Factura (ID),
CONSTRAINT FK2_Producto_DetalleFactura FOREIGN KEY (IdProducto) REFERENCES Producto (ID)
)
GO