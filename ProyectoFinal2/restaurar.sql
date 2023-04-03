USE [BD2Final]
GO
/****** Object:  UserDefinedTableType [dbo].[Informacion16]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[Informacion16] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InformacionDetalle1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[InformacionDetalle1] AS TABLE(
	[ID_producto] [int] NULL,
	[Id_pago] [int] NULL,
	[Cantidad_vendidos] [int] NULL,
	[Sub_total] [money] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InformacionDetalle2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[InformacionDetalle2] AS TABLE(
	[ID_producto] [int] NULL,
	[Id_pago] [int] NULL,
	[Cantidad_vendidos] [int] NULL,
	[Sub_total] [money] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InformacionDetalle3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[InformacionDetalle3] AS TABLE(
	[ID_producto] [int] NULL,
	[Id_pago] [int] NULL,
	[Cantidad_vendidos] [int] NULL,
	[Sub_total] [money] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InformacionDetalle4]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[InformacionDetalle4] AS TABLE(
	[ID_producto] [int] NULL,
	[Id_pago] [int] NULL,
	[Cantidad_vendidos] [int] NULL,
	[Sub_total] [money] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[InformacionDetalle5]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[InformacionDetalle5] AS TABLE(
	[ID_producto] [int] NULL,
	[Id_pago] [int] NULL,
	[Cantidad_vendidos] [int] NULL,
	[Sub_total] [money] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalvarCantidad1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[SalvarCantidad1] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalvarCantidad2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[SalvarCantidad2] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalvarCantidad3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[SalvarCantidad3] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalvarCantidad4]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[SalvarCantidad4] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalvarCantidad5]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[SalvarCantidad5] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalvarCantidad6]    Script Date: 11/11/2020 1:03:52 p. m. ******/
CREATE TYPE [dbo].[SalvarCantidad6] AS TABLE(
	[Cantidad] [int] NULL,
	[ID_producto] [int] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[func_Existencia]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[func_Existencia](@valor int)
returns int
as
Begin
  Declare @cantidad int
  Select @cantidad= cantidad from Existencia INNER JOIN Producto on Producto.Id_producto = Existencia.Id_producto where Producto.Id_producto = @valor
  return @cantidad
End
GO
/****** Object:  UserDefinedFunction [dbo].[func_Existencia2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[func_Existencia2](@valor int)
returns int
as
Begin
  Declare @cantidad int
select @cantidad= sum(Controlalmacen.cantidad) from producto
INNER JOIN Existencia on Existencia.Id_producto = Producto.Id_producto
INNER JOIN Controlalmacen on Controlalmacen.Id_existencia = Existencia.Id_existencia 
Where Existencia.Id_producto = 2 and estado = 0
  return @cantidad
End
GO
/****** Object:  UserDefinedFunction [dbo].[func_Existencia3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[func_Existencia3](@valor int)
returns int
as
Begin
Declare @cantidad int
select @cantidad= sum(Controlalmacen.cantidad) from producto
INNER JOIN Existencia on Existencia.Id_producto = Producto.Id_producto
INNER JOIN Controlalmacen on Controlalmacen.Id_existencia = Existencia.Id_existencia 
Where Existencia.Id_producto = @valor and estado = 0
if(@cantidad is null)
select @cantidad = 0
return @cantidad
End
GO
/****** Object:  UserDefinedFunction [dbo].[func_masViejo]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[func_masViejo](@valor int)
returns int
as
Begin
declare @mas_viejo as int
select @mas_viejo =  producto.Id_producto from Controlalmacen
INNER JOIN PedidoProducto on PedidoProducto.Id_productoPedido= Controlalmacen.Id_productoPedido
INNER JOIN Producto on Producto.Id_producto = PedidoProducto.Id_producto
where PedidoProducto.Id_producto = 3
order by fecha_expiracion  desc
return @mas_viejo
End
GO
/****** Object:  UserDefinedFunction [dbo].[func_masViejoFecha]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[func_masViejoFecha](@valor int)
returns date
as
Begin
declare @mas_viejoFecha as date
select @mas_viejoFecha =  fecha_expiracion from Controlalmacen
INNER JOIN PedidoProducto on PedidoProducto.Id_productoPedido= Controlalmacen.Id_productoPedido
INNER JOIN Producto on Producto.Id_producto = PedidoProducto.Id_producto
where PedidoProducto.Id_producto = 3
order by fecha_expiracion desc
return @mas_viejoFecha
End
GO
/****** Object:  UserDefinedFunction [dbo].[func_UltimaFac]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[func_UltimaFac]()
returns int
as
Begin
 		declare @UltimoId as int
		Set @UltimoId =  IDENT_CURRENT('EncabezadoFacttura')
		return @UltimoId
End
GO
/****** Object:  UserDefinedFunction [dbo].[SubTotal]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[SubTotal](@cantidad int, @Id_producto int)
returns money
as
Begin
  declare @SubTotal money
  Select @SubTotal= @cantidad*precioVenta from Existencia INNER JOIN Producto on Producto.Id_producto = Existencia.Id_producto where Producto.Id_producto = @Id_producto
  return @SubTotal
End
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[Id_detalle] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Id_factura] [int] NULL,
	[Id_producto] [int] NULL,
	[Id_pago] [int] NULL,
	[cantidad_vendidos] [int] NOT NULL,
	[sub_total] [money] NOT NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[Id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metodo_pago]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metodo_pago](
	[Id_pago] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[metodo_pago] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Metodo_pago] PRIMARY KEY CLUSTERED 
(
	[Id_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[estadistica1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[estadistica1]
 AS SELECT  (COUNT( DetalleFactura.Id_pago )*100 /(select count(*) from [DetalleFactura]))AS MasUsado, Metodo_pago.metodo_pago  FROM  DetalleFactura
INNER JOIN Metodo_pago on Metodo_pago.Id_pago=DetalleFactura.Id_pago
GROUP BY Metodo_pago.metodo_pago 

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id_producto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Id_SubCategoriaProducto] [int] NULL,
	[nombre_producto] [varchar](50) NOT NULL,
	[precioVenta] [money] NOT NULL,
	[descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[estadistica2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[estadistica2]
 AS select top(10) sum(cantidad_vendidos) as Mas_vendidos, nombre_producto from DetalleFactura 
inner join Producto on Producto.Id_producto = DetalleFactura.Id_producto
GROUP BY Producto.nombre_producto

GO
/****** Object:  Table [dbo].[EncabezadoFacttura]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncabezadoFacttura](
	[Id_factura] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Id_empleado] [int] NULL,
	[Id_cliente] [int] NULL,
	[nit_empresa] [varchar](20) NOT NULL,
	[nombre_empresa] [varchar](50) NOT NULL,
	[fecha_venta] [datetime] NOT NULL,
	[total_venta] [money] NOT NULL,
	[Id_numFactura] [int] NULL,
 CONSTRAINT [PK_EncabezadoFacttura] PRIMARY KEY CLUSTERED 
(
	[Id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente2](
	[Id_cliente] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[primer_nombre] [varchar](30) NOT NULL,
	[segundo_nombre] [varchar](30) NOT NULL,
	[primer_apellido] [varchar](30) NOT NULL,
	[segundo_apellido] [varchar](30) NULL,
	[telefono] [int] NULL,
	[correo] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente2] PRIMARY KEY CLUSTERED 
(
	[Id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[estadistica3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[estadistica3]
AS SELECT sum(total_venta) as Clientes_con_mas_consumo, CONCAT(primer_nombre,' ',segundo_nombre,' ',primer_apellido,' ',segundo_apellido) as Nombre_cliente from EncabezadoFacttura
INNER JOIN Cliente2 on Cliente2.Id_cliente = EncabezadoFacttura.Id_cliente
group by  primer_nombre,segundo_nombre,primer_apellido,segundo_apellido  


GO
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProducto](
	[Id_categoriaProducto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[Id_categoriaProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_cliente] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [smallint] NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Controlalmacen]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Controlalmacen](
	[Id_almacen] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[cantidad] [int] NULL,
	[Id_productoPedido] [int] NULL,
	[fecha_expiracion] [datetime] NULL,
	[estado] [int] NULL,
	[Id_existencia] [int] NULL,
 CONSTRAINT [PK_Controlalmacen] PRIMARY KEY CLUSTERED 
(
	[Id_almacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Id_departamento] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[nombre_cargo] [varchar](40) NOT NULL,
	[sueldo] [float] NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Id_departamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Id_empleado] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[primer_nombre] [varchar](30) NOT NULL,
	[segundo_nombre] [varchar](30) NOT NULL,
	[primer_apellido] [varchar](30) NOT NULL,
	[segundo_apellido] [varchar](30) NULL,
	[fecha_cumpleaños] [date] NOT NULL,
	[telefono] [int] NULL,
	[correo] [varchar](50) NULL,
	[usuario] [varchar](30) NOT NULL,
	[contraseña] [varchar](60) NOT NULL,
	[Id_departamento] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[Id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Existencia]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Existencia](
	[Id_existencia] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[cantidad] [int] NOT NULL,
	[Id_producto] [int] NULL,
 CONSTRAINT [PK_Existencia] PRIMARY KEY CLUSTERED 
(
	[Id_existencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialPrecioVenta]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialPrecioVenta](
	[Id_PrecioHistorialProducto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Id_producto] [int] NULL,
	[fecha_mod] [datetime] NOT NULL,
	[precioVenta] [money] NOT NULL,
 CONSTRAINT [PK_HistorialPrecioVenta] PRIMARY KEY CLUSTERED 
(
	[Id_PrecioHistorialProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumFactura]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumFactura](
	[Id_numFactura] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[numero_factura] [int] NOT NULL,
	[Id_serie] [int] NULL,
 CONSTRAINT [PK_NumFactura] PRIMARY KEY CLUSTERED 
(
	[Id_numFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id_pedido] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[fecha_pedido] [date] NOT NULL,
	[fecha_envio] [date] NULL,
	[Id_proveedor] [int] NULL,
	[Id_empleado] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoProducto]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProducto](
	[Id_productoPedido] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[cantidad] [int] NOT NULL,
	[Id_producto] [int] NULL,
	[Id_pedido] [int] NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_PedidoProducto] PRIMARY KEY CLUSTERED 
(
	[Id_productoPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id_proveedor] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[nombre] [varchar](75) NOT NULL,
	[telefono] [int] NOT NULL,
	[correo] [varchar](75) NOT NULL,
	[comentario] [varchar](200) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[Id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Serie]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Serie](
	[Id_serie] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[serie] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Serie] PRIMARY KEY CLUSTERED 
(
	[Id_serie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategoriaProducto]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategoriaProducto](
	[Id_SubCategoriaProducto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Id_categoriaProducto] [int] NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SubCategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[Id_SubCategoriaProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 
GO
INSERT [dbo].[CategoriaProducto] ([Id_categoriaProducto], [nombre]) VALUES (1, N'Paletas')
GO
INSERT [dbo].[CategoriaProducto] ([Id_categoriaProducto], [nombre]) VALUES (2, N'Pinturas')
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente2] ON 
GO
INSERT [dbo].[Cliente2] ([Id_cliente], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [telefono], [correo]) VALUES (1, N'cliente1', N'cliente1', N'cliente1', N'cliente1', 123123, N'ejemplo@gmailc.om')
GO
INSERT [dbo].[Cliente2] ([Id_cliente], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [telefono], [correo]) VALUES (2, N'cliente2', N'cliente2', N'cliente2', N'cliente2', 53624742, N'cliente2@gmail.com')
GO
INSERT [dbo].[Cliente2] ([Id_cliente], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [telefono], [correo]) VALUES (3, N'cliente3', N'cliente3', N'cliente3', N'cliente3', 53624742, N'cliente2@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Cliente2] OFF
GO
SET IDENTITY_INSERT [dbo].[Controlalmacen] ON 
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (142, 1, 1031, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 1, 19)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (143, 1, 1031, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 1, 19)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (144, 1, 1031, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 19)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (145, 1, 1031, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 19)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (146, 1, 1031, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 19)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (147, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 1, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (148, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 1, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (149, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 1, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (150, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (151, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (152, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (153, 1, 1032, CAST(N'9999-12-31T00:00:00.000' AS DateTime), 0, 20)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (154, 1, 1033, CAST(N'2020-11-10T14:32:47.000' AS DateTime), 0, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (155, 1, 1033, CAST(N'2020-11-11T14:32:47.000' AS DateTime), 0, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (156, 1, 1033, CAST(N'2020-11-12T14:32:47.000' AS DateTime), 0, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (157, 1, 1033, CAST(N'2020-11-13T14:32:47.000' AS DateTime), 0, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (158, 1, 1033, CAST(N'2020-11-14T14:32:47.000' AS DateTime), 0, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (159, 1, 1033, CAST(N'2020-06-16T14:32:47.000' AS DateTime), 0, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (160, 1, 1033, CAST(N'2020-06-15T14:32:47.000' AS DateTime), 1, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (161, 1, 1033, CAST(N'2020-06-14T14:32:47.000' AS DateTime), 1, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (162, 1, 1033, CAST(N'2020-06-13T14:32:47.000' AS DateTime), 1, 21)
GO
INSERT [dbo].[Controlalmacen] ([Id_almacen], [cantidad], [Id_productoPedido], [fecha_expiracion], [estado], [Id_existencia]) VALUES (163, 1, 1033, CAST(N'2020-06-12T14:32:47.000' AS DateTime), 1, 21)
GO
SET IDENTITY_INSERT [dbo].[Controlalmacen] OFF
GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 
GO
INSERT [dbo].[Departamento] ([Id_departamento], [nombre_cargo], [sueldo]) VALUES (1, N'Administrador', 4000)
GO
INSERT [dbo].[Departamento] ([Id_departamento], [nombre_cargo], [sueldo]) VALUES (2, N'Cajero', 3000)
GO
INSERT [dbo].[Departamento] ([Id_departamento], [nombre_cargo], [sueldo]) VALUES (4, N'Bodeguero', 3500)
GO
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 
GO
INSERT [dbo].[DetalleFactura] ([Id_detalle], [Id_factura], [Id_producto], [Id_pago], [cantidad_vendidos], [sub_total]) VALUES (1030, 1022, 2, 1, 2, 40.0000)
GO
INSERT [dbo].[DetalleFactura] ([Id_detalle], [Id_factura], [Id_producto], [Id_pago], [cantidad_vendidos], [sub_total]) VALUES (1031, 1022, 3, 1, 3, 30.0000)
GO
INSERT [dbo].[DetalleFactura] ([Id_detalle], [Id_factura], [Id_producto], [Id_pago], [cantidad_vendidos], [sub_total]) VALUES (1032, 1022, 6, 2, 4, 40.0000)
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 
GO
INSERT [dbo].[Empleado] ([Id_empleado], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [fecha_cumpleaños], [telefono], [correo], [usuario], [contraseña], [Id_departamento]) VALUES (2, N'Cristian', N'Rene', N'Ivan', N'Tahay', CAST(N'1999-06-06' AS Date), 238949234, N'ejemplo1@gmail.com', N'tahayk1', N'1212', 1)
GO
INSERT [dbo].[Empleado] ([Id_empleado], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [fecha_cumpleaños], [telefono], [correo], [usuario], [contraseña], [Id_departamento]) VALUES (3, N'CajeroNombre1', N'CajeroNombre2', N'CajeroApellido1', N'CajeroApellido2', CAST(N'1999-06-06' AS Date), 5746252, N'ejemplo2@gmail.com', N'tahayk2', N'1212', 2)
GO
INSERT [dbo].[Empleado] ([Id_empleado], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [fecha_cumpleaños], [telefono], [correo], [usuario], [contraseña], [Id_departamento]) VALUES (7, N'Bodeguero1', N'Bodeguero1', N'Bodeguero1', N'Bodeguero1', CAST(N'1999-06-06' AS Date), 46373726, N'ejemplo3@gmail.com', N'tahayk3', N'1212', 4)
GO
INSERT [dbo].[Empleado] ([Id_empleado], [primer_nombre], [segundo_nombre], [primer_apellido], [segundo_apellido], [fecha_cumpleaños], [telefono], [correo], [usuario], [contraseña], [Id_departamento]) VALUES (9, N'Bodeguero1', N'Bodeguero1', N'Bodeguero1', N'Bodeguero1', CAST(N'1999-06-06' AS Date), 46373726, N'ejemplo3@gmail.com', N'tahayk4', N'1212', 4)
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[EncabezadoFacttura] ON 
GO
INSERT [dbo].[EncabezadoFacttura] ([Id_factura], [Id_empleado], [Id_cliente], [nit_empresa], [nombre_empresa], [fecha_venta], [total_venta], [Id_numFactura]) VALUES (1022, 2, 1, N'85907-8', N'Casa de la paleta', CAST(N'2020-11-10T14:34:14.800' AS DateTime), 110.0000, 1031)
GO
SET IDENTITY_INSERT [dbo].[EncabezadoFacttura] OFF
GO
SET IDENTITY_INSERT [dbo].[Existencia] ON 
GO
INSERT [dbo].[Existencia] ([Id_existencia], [cantidad], [Id_producto]) VALUES (19, 5, 2)
GO
INSERT [dbo].[Existencia] ([Id_existencia], [cantidad], [Id_producto]) VALUES (20, 7, 3)
GO
INSERT [dbo].[Existencia] ([Id_existencia], [cantidad], [Id_producto]) VALUES (21, 10, 6)
GO
SET IDENTITY_INSERT [dbo].[Existencia] OFF
GO
SET IDENTITY_INSERT [dbo].[Metodo_pago] ON 
GO
INSERT [dbo].[Metodo_pago] ([Id_pago], [metodo_pago]) VALUES (1, N'Efectivo')
GO
INSERT [dbo].[Metodo_pago] ([Id_pago], [metodo_pago]) VALUES (2, N'Cheque')
GO
INSERT [dbo].[Metodo_pago] ([Id_pago], [metodo_pago]) VALUES (3, N'Tarjeta de credito')
GO
SET IDENTITY_INSERT [dbo].[Metodo_pago] OFF
GO
SET IDENTITY_INSERT [dbo].[NumFactura] ON 
GO
INSERT [dbo].[NumFactura] ([Id_numFactura], [numero_factura], [Id_serie]) VALUES (1031, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[NumFactura] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 
GO
INSERT [dbo].[Pedido] ([Id_pedido], [fecha_pedido], [fecha_envio], [Id_proveedor], [Id_empleado]) VALUES (1034, CAST(N'2020-11-10' AS Date), CAST(N'2020-11-10' AS Date), 1, 2)
GO
INSERT [dbo].[Pedido] ([Id_pedido], [fecha_pedido], [fecha_envio], [Id_proveedor], [Id_empleado]) VALUES (1035, CAST(N'2020-11-10' AS Date), CAST(N'2020-11-10' AS Date), 2, 2)
GO
INSERT [dbo].[Pedido] ([Id_pedido], [fecha_pedido], [fecha_envio], [Id_proveedor], [Id_empleado]) VALUES (1036, CAST(N'2020-11-10' AS Date), CAST(N'2020-11-10' AS Date), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[PedidoProducto] ON 
GO
INSERT [dbo].[PedidoProducto] ([Id_productoPedido], [cantidad], [Id_producto], [Id_pedido], [estado]) VALUES (1031, 5, 2, 1034, 1)
GO
INSERT [dbo].[PedidoProducto] ([Id_productoPedido], [cantidad], [Id_producto], [Id_pedido], [estado]) VALUES (1032, 7, 3, 1035, 1)
GO
INSERT [dbo].[PedidoProducto] ([Id_productoPedido], [cantidad], [Id_producto], [Id_pedido], [estado]) VALUES (1033, 10, 6, 1036, 1)
GO
SET IDENTITY_INSERT [dbo].[PedidoProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([Id_producto], [Id_SubCategoriaProducto], [nombre_producto], [precioVenta], [descripcion]) VALUES (2, 2, N'paleta metal', 20.0000, N'sin')
GO
INSERT [dbo].[Producto] ([Id_producto], [Id_SubCategoriaProducto], [nombre_producto], [precioVenta], [descripcion]) VALUES (3, 3, N'paleta madena', 10.0000, N'sin')
GO
INSERT [dbo].[Producto] ([Id_producto], [Id_SubCategoriaProducto], [nombre_producto], [precioVenta], [descripcion]) VALUES (6, 4, N'pintura roja tecno', 10.0000, N'sin')
GO
INSERT [dbo].[Producto] ([Id_producto], [Id_SubCategoriaProducto], [nombre_producto], [precioVenta], [descripcion]) VALUES (7, 5, N'pintura negra valentine', 10.0000, N'sin')
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 
GO
INSERT [dbo].[Proveedores] ([Id_proveedor], [nombre], [telefono], [correo], [comentario]) VALUES (1, N'PaperPlus', 58576695, N'PaperPlus@gmail.com', N'Cartas')
GO
INSERT [dbo].[Proveedores] ([Id_proveedor], [nombre], [telefono], [correo], [comentario]) VALUES (2, N'Sicil', 58576695, N'Sicil@gmail.com', N'Manualidades')
GO
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Serie] ON 
GO
INSERT [dbo].[Serie] ([Id_serie], [serie]) VALUES (1, N'A')
GO
INSERT [dbo].[Serie] ([Id_serie], [serie]) VALUES (6, N'B')
GO
INSERT [dbo].[Serie] ([Id_serie], [serie]) VALUES (7, N'C')
GO
SET IDENTITY_INSERT [dbo].[Serie] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategoriaProducto] ON 
GO
INSERT [dbo].[SubCategoriaProducto] ([Id_SubCategoriaProducto], [Id_categoriaProducto], [nombre]) VALUES (2, 2, N'galon')
GO
INSERT [dbo].[SubCategoriaProducto] ([Id_SubCategoriaProducto], [Id_categoriaProducto], [nombre]) VALUES (3, 1, N'Paleta pequeña')
GO
INSERT [dbo].[SubCategoriaProducto] ([Id_SubCategoriaProducto], [Id_categoriaProducto], [nombre]) VALUES (4, 1, N'Paleta mediana')
GO
INSERT [dbo].[SubCategoriaProducto] ([Id_SubCategoriaProducto], [Id_categoriaProducto], [nombre]) VALUES (5, 2, N'medio galon')
GO
SET IDENTITY_INSERT [dbo].[SubCategoriaProducto] OFF
GO
ALTER TABLE [dbo].[Cliente2] ADD  DEFAULT ((0)) FOR [telefono]
GO
ALTER TABLE [dbo].[Empleado] ADD  DEFAULT ((0)) FOR [telefono]
GO
ALTER TABLE [dbo].[PedidoProducto] ADD  CONSTRAINT [DF_PedidoProducto_estado]  DEFAULT ((0)) FOR [estado]
GO
ALTER TABLE [dbo].[Controlalmacen]  WITH CHECK ADD  CONSTRAINT [FK_Controlalmacen_Existencia] FOREIGN KEY([Id_existencia])
REFERENCES [dbo].[Existencia] ([Id_existencia])
GO
ALTER TABLE [dbo].[Controlalmacen] CHECK CONSTRAINT [FK_Controlalmacen_Existencia]
GO
ALTER TABLE [dbo].[Controlalmacen]  WITH CHECK ADD  CONSTRAINT [Relationship54] FOREIGN KEY([Id_productoPedido])
REFERENCES [dbo].[PedidoProducto] ([Id_productoPedido])
GO
ALTER TABLE [dbo].[Controlalmacen] CHECK CONSTRAINT [Relationship54]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [Relationship24] FOREIGN KEY([Id_factura])
REFERENCES [dbo].[EncabezadoFacttura] ([Id_factura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [Relationship24]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [Relationship25] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([Id_producto])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [Relationship25]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [Relationship39] FOREIGN KEY([Id_pago])
REFERENCES [dbo].[Metodo_pago] ([Id_pago])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [Relationship39]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [Relationship48] FOREIGN KEY([Id_departamento])
REFERENCES [dbo].[Departamento] ([Id_departamento])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [Relationship48]
GO
ALTER TABLE [dbo].[EncabezadoFacttura]  WITH CHECK ADD  CONSTRAINT [Relationship42] FOREIGN KEY([Id_empleado])
REFERENCES [dbo].[Empleado] ([Id_empleado])
GO
ALTER TABLE [dbo].[EncabezadoFacttura] CHECK CONSTRAINT [Relationship42]
GO
ALTER TABLE [dbo].[EncabezadoFacttura]  WITH CHECK ADD  CONSTRAINT [Relationship45] FOREIGN KEY([Id_cliente])
REFERENCES [dbo].[Cliente2] ([Id_cliente])
GO
ALTER TABLE [dbo].[EncabezadoFacttura] CHECK CONSTRAINT [Relationship45]
GO
ALTER TABLE [dbo].[EncabezadoFacttura]  WITH CHECK ADD  CONSTRAINT [Relationship59] FOREIGN KEY([Id_numFactura])
REFERENCES [dbo].[NumFactura] ([Id_numFactura])
GO
ALTER TABLE [dbo].[EncabezadoFacttura] CHECK CONSTRAINT [Relationship59]
GO
ALTER TABLE [dbo].[Existencia]  WITH CHECK ADD  CONSTRAINT [Relationship60] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([Id_producto])
GO
ALTER TABLE [dbo].[Existencia] CHECK CONSTRAINT [Relationship60]
GO
ALTER TABLE [dbo].[HistorialPrecioVenta]  WITH CHECK ADD  CONSTRAINT [Relationship10] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([Id_producto])
GO
ALTER TABLE [dbo].[HistorialPrecioVenta] CHECK CONSTRAINT [Relationship10]
GO
ALTER TABLE [dbo].[NumFactura]  WITH CHECK ADD  CONSTRAINT [Relationship58] FOREIGN KEY([Id_serie])
REFERENCES [dbo].[Serie] ([Id_serie])
GO
ALTER TABLE [dbo].[NumFactura] CHECK CONSTRAINT [Relationship58]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [Relationship46] FOREIGN KEY([Id_proveedor])
REFERENCES [dbo].[Proveedores] ([Id_proveedor])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [Relationship46]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [Relationship47] FOREIGN KEY([Id_empleado])
REFERENCES [dbo].[Empleado] ([Id_empleado])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [Relationship47]
GO
ALTER TABLE [dbo].[PedidoProducto]  WITH CHECK ADD  CONSTRAINT [Relationship37] FOREIGN KEY([Id_producto])
REFERENCES [dbo].[Producto] ([Id_producto])
GO
ALTER TABLE [dbo].[PedidoProducto] CHECK CONSTRAINT [Relationship37]
GO
ALTER TABLE [dbo].[PedidoProducto]  WITH CHECK ADD  CONSTRAINT [Relationship38] FOREIGN KEY([Id_pedido])
REFERENCES [dbo].[Pedido] ([Id_pedido])
GO
ALTER TABLE [dbo].[PedidoProducto] CHECK CONSTRAINT [Relationship38]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [Relationship20] FOREIGN KEY([Id_SubCategoriaProducto])
REFERENCES [dbo].[SubCategoriaProducto] ([Id_SubCategoriaProducto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [Relationship20]
GO
ALTER TABLE [dbo].[SubCategoriaProducto]  WITH CHECK ADD  CONSTRAINT [Relationship19] FOREIGN KEY([Id_categoriaProducto])
REFERENCES [dbo].[CategoriaProducto] ([Id_categoriaProducto])
GO
ALTER TABLE [dbo].[SubCategoriaProducto] CHECK CONSTRAINT [Relationship19]
GO
/****** Object:  StoredProcedure [dbo].[BuscarCategoria]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarCategoria] @Nombre CHAR(20)  
AS  
SELECT @Nombre = RTRIM(@Nombre) + '%';  
SELECT * FROM CategoriaProducto 
WHERE nombre LIKE @Nombre;  
GO
/****** Object:  StoredProcedure [dbo].[BuscarCategoria2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[BuscarCategoria2] @Nombre varchar(20)  
AS  
SELECT @Nombre = RTRIM(@Nombre) + '%';  
SELECT * FROM CategoriaProducto 
WHERE nombre LIKE @Nombre;  
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ControlAlmacen1]
(@cantidad_producto_llegada int, @descripcion varchar(50),@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia
		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad_producto_llegada, descripcion, Id_productoPedido,cantidad_producto_Nollegado) VALUES(@cantidad_producto_llegada,@descripcion,@Id_productoPedido,@cantidad_producto_Nollegado)
		--encuentra el ultimo id de control almacen
		declare @UltimoId as int
		Set @UltimoId =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		INSERT INTO Existencia (cantidad,Id_almacen,Id_producto) VALUES (@cantidad_producto_llegada,@UltimoId,@Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISNTEICAS DE PRODUCTO YA EXITE
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL +@cantidad_producto_llegada
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(@Id_producto = @Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ControlAlmacen2]
(@cantidad_producto_llegada int, @descripcion varchar(50),@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia
		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad_producto_llegada, descripcion, Id_productoPedido,cantidad_producto_Nollegado) VALUES(@cantidad_producto_llegada,@descripcion,@Id_productoPedido,@cantidad_producto_Nollegado)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + @cantidad_producto_llegada
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISNTEICAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_almacen,Id_producto) VALUES (@cantidad_producto_llegada,@UltimoId_almacen,@Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId_almacen as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ControlAlmacen3]
(@cantidad_producto_llegada int, @descripcion varchar(50),@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia
		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad_producto_llegada, descripcion, Id_productoPedido,cantidad_producto_Nollegado) VALUES(@cantidad_producto_llegada,@descripcion,@Id_productoPedido,@cantidad_producto_Nollegado)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + @cantidad_producto_llegada
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISNTEICAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_almacen,Id_producto) VALUES (@cantidad_producto_llegada,@UltimoId_almacen,@Id_producto)
		--
		update PedidoProducto set estado = 1 where (Id_productoPedido =@Id_productoPedido)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId_almacen as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen4]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ControlAlmacen4]
(@cantidad_producto_llegada int, @descripcion varchar(50),@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia
		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad_producto_llegada, descripcion, Id_productoPedido,cantidad_producto_Nollegado) VALUES(@cantidad_producto_llegada,@descripcion,@Id_productoPedido,@cantidad_producto_Nollegado)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + @cantidad_producto_llegada
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISNTEICAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_almacen,Id_producto) VALUES (@cantidad_producto_llegada,@UltimoId_almacen,@Id_producto)
		--
		update PedidoProducto set estado = 1 where (Id_productoPedido =@Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId_almacen as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen5]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ControlAlmacen5]
(@cantidad_producto_llegada int, @descripcion varchar(50),@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia
		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad_producto_llegada, descripcion, Id_productoPedido,cantidad_producto_Nollegado) VALUES(@cantidad_producto_llegada,@descripcion,@Id_productoPedido,@cantidad_producto_Nollegado)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + @cantidad_producto_llegada
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISNTEICAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_almacen,Id_producto) VALUES (@cantidad_producto_llegada,@UltimoId_almacen,@Id_producto)
		--
		update PedidoProducto set estado = 1 where (Id_productoPedido =@Id_productoPedido)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId_almacen as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen6]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_ControlAlmacen6]
(@cantidad_producto_llegada int, @descripcion varchar(50),@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia
		--Variable a 1
		update PedidoProducto set estado = 1 where (Id_productoPedido =@Id_productoPedido)
		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad_producto_llegada, descripcion, Id_productoPedido,cantidad_producto_Nollegado) VALUES(@cantidad_producto_llegada,@descripcion,@Id_productoPedido,@cantidad_producto_Nollegado)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + @cantidad_producto_llegada
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISNTEICAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_almacen,Id_producto) VALUES (@cantidad_producto_llegada,@UltimoId_almacen,@Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId_almacen as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen7]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ControlAlmacen7]
(@fecha_expiracion datetime,@Id_productoPedido int,@cantidad_producto_Nollegado int, @Id_producto int,@Id_existencia int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia

		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad,Id_productoPedido,fecha_expiracion,estado,Id_existencia) VALUES(1,@Id_productoPedido,@fecha_expiracion,'0',@Id_existencia)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + 1
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISTENCIAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_producto) VALUES (1,@Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen8]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ControlAlmacen8]
(@fecha_expiracion datetime,@Id_productoPedido int, @Id_producto int,@Id_existencia int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia

		--aqui llena control almacen
		INSERT INTO  Controlalmacen (cantidad,Id_productoPedido,fecha_expiracion,estado,Id_existencia) VALUES(1,@Id_productoPedido,@fecha_expiracion,'0',@Id_existencia)
		--encuentra el ultimo id de control almacen
		declare @UltimoId_almacen as int
		Set @UltimoId_almacen =  IDENT_CURRENT('Controlalmacen')
		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + 1
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--falta ver lo actual
		--aqui llena existencia SI LAS EXISTENCIAS DE PRODUCTO YA EXITE
	    INSERT INTO Existencia (cantidad,Id_producto) VALUES (1,@Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_ControlAlmacen9]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_ControlAlmacen9]
(@fecha_expiracion datetime,@Id_productoPedido int, @Id_producto int, @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarExistencia

		--primero que nada nada hay que ver si el producto existe en la tabla existencia o hay que crearla
		declare @EXISTENCIAPRODUCTO as int
		select @EXISTENCIAPRODUCTO =  Id_existencia from Existencia where Id_producto = @Id_producto
		select @EXISTENCIAPRODUCTO
		--si es null crea la existencia con 0 y extraigo el Id_exitencia --sino solo extraigo el Id_exitencia
		if(@EXISTENCIAPRODUCTO is null)
		INSERT INTO Existencia(cantidad,Id_producto) VALUES (0,@Id_producto)
		--Ahora extrae el @Id_exitencia
		declare @Id_existencia int 
		select  @Id_existencia =  Id_existencia from Existencia where Id_producto = @Id_producto
		--AQUI SE LLENA EL CONTROLALMACEN
		INSERT INTO  Controlalmacen (cantidad,Id_productoPedido,fecha_expiracion,estado,Id_existencia) VALUES(1,@Id_productoPedido,@fecha_expiracion,'0',@Id_existencia)
		

		--IF PARA VER SI ACTUALIZA O CREA
		IF EXISTS(SELECT TOP(1) 1 FROM Existencia WHERE Id_producto = @Id_producto)
		BEGIN
		--aqui llena existencia SI LAS EXISTENCIAS DE PRODUCTO YA EXITE
		declare @EXISTENCIA_ACTUAL as int
		select  @EXISTENCIA_ACTUAL = sum(cantidad)  from Existencia where Id_producto = @Id_producto
		declare @SUMA_EXISTENCIA int
		select @SUMA_EXISTENCIA = @EXISTENCIA_ACTUAL + 1
		UPDATE Existencia SET cantidad = @SUMA_EXISTENCIA  WHERE(Id_producto = @Id_producto)
		END ELSE BEGIN
		--aqui llena existencia SI EL PRODUCTO LLEGA POR PRIMERA VEZ
	    INSERT INTO Existencia (cantidad,Id_producto) VALUES (1,@Id_producto)
		END
		--envia el mensaje de que control almacen fue creado 
	    SET @mensaje= 'Se ha grabado con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarExistencia
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaFactura1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_CreaFactura1]
(@serie varchar(50),@Id_empleado int,@Id_cliente int,@detalle as dbo.InformacionDetalle1 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
			--crea el numero de factura
			INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(1,@serie)
			declare @UltimoId_factura as int
			Set @UltimoId_factura =  IDENT_CURRENT('NumFactura')
			--Crea el encabazado de la factura
			Insert Into EncabezadoFacttura(Id_empleado,Id_cliente,nit_empresa,nombre_empresa,fecha_venta,Id_numFactura) Values (@Id_empleado,@Id_cliente,'85907-8','Casa de la paleta',GETDATE(),@UltimoId_factura)
			--crea detalle de factura
			--declarar variable para ver ultimo encabezado de factura ha sido creado
			declare @Id_factura int
			Select @Id_factura=SCOPE_IDENTITY()
			--crea el datalle
			Insert Into DetalleFactura(Id_factura,Id_producto,Id_pago,cantidad_vendidos,sub_total)
			Select @Id_factura,ID_producto,Id_pago,Cantidad_vendidos,Sub_total from @detalle
			SET @mensaje= 'Se ha grabado el prestamo ' + Cast(@Id_factura as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaFactura2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_CreaFactura2]
(@serie int,@Id_empleado int,@Id_cliente int,@detalle as dbo.InformacionDetalle2 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
			--crea el numero de factura
			INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(1,@serie)
			declare @UltimoId_factura as int
			Set @UltimoId_factura =  IDENT_CURRENT('NumFactura')
			--Crea el encabazado de la factura
			Insert Into EncabezadoFacttura(Id_empleado,Id_cliente,nit_empresa,nombre_empresa,fecha_venta,Id_numFactura) Values (@Id_empleado,@Id_cliente,'85907-8','Casa de la paleta',GETDATE(),@UltimoId_factura)
			--crea detalle de factura
			--declarar variable para ver ultimo encabezado de factura ha sido creado
			declare @Id_factura int
			Select @Id_factura=SCOPE_IDENTITY()
			--crea el datalle
			Insert Into DetalleFactura(Id_factura,Id_producto,Id_pago,cantidad_vendidos,sub_total)
			Select @Id_factura,ID_producto,Id_pago,Cantidad_vendidos,Sub_total from @detalle
			SET @mensaje= 'Se ha grabado el prestamo ' + Cast(@Id_factura as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaFactura3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_CreaFactura3]
(@serie int,@Id_empleado int,@Id_cliente int,@detalle as dbo.InformacionDetalle3 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
			--crea el numero de factura
			INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(1,@serie)
			declare @UltimoId_factura as int
			Set @UltimoId_factura =  IDENT_CURRENT('NumFactura')
			--Crea el encabazado de la factura con valor total de 0
			Insert Into EncabezadoFacttura(Id_empleado,Id_cliente,nit_empresa,nombre_empresa,fecha_venta,total_venta,Id_numFactura) Values (@Id_empleado,@Id_cliente,'85907-8','Casa de la paleta',GETDATE(),0,@UltimoId_factura)
			--crea detalle de factura
			--declarar variable para ver ultimo encabezado de factura ha sido creado
			declare @Id_factura int
			Select @Id_factura=SCOPE_IDENTITY()
			--crea el datalle
			Insert Into DetalleFactura(Id_factura,Id_producto,Id_pago,cantidad_vendidos,sub_total)
			Select @Id_factura,ID_producto,Id_pago,Cantidad_vendidos,Sub_total from @detalle
			--se busca el total de momento
			declare @Gran_total money
			Select @Gran_total = sum (sub_total) from DetalleFactura where Id_factura= @Id_factura
			--se actualiza la factura con el total real
			UPDATE EncabezadoFacttura SET  total_venta = @Gran_total WHERE Id_factura=@UltimoId_factura
			SET @mensaje= 'Se ha grabado el prestamo ' + Cast(@Id_factura as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaFactura4]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_CreaFactura4]
(@serie int,@Id_empleado int,@Id_cliente int,@detalle as dbo.InformacionDetalle4 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
			--crea el numero de factura
			INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(1,@serie)
			declare @UltimoId_factura as int
			Set @UltimoId_factura =  IDENT_CURRENT('NumFactura')
			--Crea el encabazado de la factura con valor total de 0
			Insert Into EncabezadoFacttura(Id_empleado,Id_cliente,nit_empresa,nombre_empresa,fecha_venta,total_venta,Id_numFactura) Values (@Id_empleado,@Id_cliente,'85907-8','Casa de la paleta',GETDATE(),0,@UltimoId_factura)
			--crea detalle de factura
			--declarar variable para ver ultimo encabezado de factura ha sido creado
			declare @Id_factura int
			Select @Id_factura=SCOPE_IDENTITY()
			--crea el datalle
			Insert Into DetalleFactura(Id_factura,Id_producto,Id_pago,cantidad_vendidos,sub_total)
			Select @Id_factura,ID_producto,Id_pago,Cantidad_vendidos,Sub_total from @detalle
			--se busca el total de momento
			declare @Gran_total money
			Select @Gran_total = sum (sub_total) from DetalleFactura where Id_factura= @Id_factura
			--se actualiza la factura con el total real
			UPDATE EncabezadoFacttura SET  total_venta = @Gran_total WHERE Id_factura=@UltimoId_factura
			SET @mensaje= 'Se ha grabado el prestamo ' + Cast(@Id_factura as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaFactura5]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_CreaFactura5]
(@serie int,@Id_empleado int,@Id_cliente int,@detalle as dbo.InformacionDetalle5 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
			--crea el numero de factura
			INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(1,@serie)
			declare @UltimoId_factura as int
			Set @UltimoId_factura =  IDENT_CURRENT('NumFactura')
			--Crea el encabazado de la factura con valor total de 0
			Insert Into EncabezadoFacttura(Id_empleado,Id_cliente,nit_empresa,nombre_empresa,fecha_venta,total_venta,Id_numFactura) Values (@Id_empleado,@Id_cliente,'85907-8','Casa de la paleta',GETDATE(),0,@UltimoId_factura)
			--crea detalle de factura
			--declarar variable para ver ultimo encabezado de factura ha sido creado
			declare @Id_factura int
			Select @Id_factura=SCOPE_IDENTITY()
			--crea el datalle
			Insert Into DetalleFactura(Id_factura,Id_producto,Id_pago,cantidad_vendidos,sub_total)
			Select @Id_factura,ID_producto,Id_pago,Cantidad_vendidos,Sub_total from @detalle
			--se busca el total de momento
			declare @Gran_total money
			Select @Gran_total = sum (sub_total) from DetalleFactura where Id_factura= @Id_factura
			--se actualiza la factura con el total real
			declare @Id_factura_ultima as int
			Set @Id_factura_ultima =  IDENT_CURRENT('EncabezadoFacttura')
			UPDATE EncabezadoFacttura SET  total_venta = @Gran_total WHERE Id_factura=@Id_factura_ultima
			SET @mensaje= 'Se ha grabado el prestamo ' + Cast(@Id_factura as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaFactura7]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_CreaFactura7]
(@serie int,@Id_empleado int,@Id_cliente int,@detalle as dbo.InformacionDetalle5 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
--ahora debe incrementar el numero de factura
--saca la letra dependiendo del id_serie
declare @letra varchar(5)
select  @letra =  serie  from Serie 
INNER JOIN NumFactura on NumFactura.Id_serie = serie.Id_serie
where NumFactura.Id_serie = @serie--aquiiiiiiiiiiiiiiiiiiiii
select @letra
declare @UltimoNumFactura as varchar(5)
select  @UltimoNumFactura = numero_factura FROM Serie  INNER JOIN NumFactura ON NumFactura.Id_serie = serie.Id_serie where serie =@letra--aquiiiiii
select  @UltimoNumFactura 
--mira si la serie es nueva
if(@UltimoNumFactura is null)
begin 
INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(1,@serie)--aquiiiiiiiiiiiiiiiiiiiii
end
else begin 
--en caso contrario suma +1
--laja el ultimo numero de factura
declare @ultima int 
select @ultima = numero_factura from Serie
inner join NumFactura on NumFactura.Id_serie = Serie.Id_serie where serie = @letra
group by numero_factura order by numero_factura
--ahora si inserta dependiendo del id_serie
declare @siguiente int 
select @siguiente = @ultima+1
INSERT INTO  NumFactura (numero_factura,Id_serie) VALUES(@siguiente,@serie)--aquiiiiiiiiiiiiiiiiiiiii
end
declare @UltimoId_factura int
Set @UltimoId_factura =  IDENT_CURRENT('NumFactura')
select numero_factura from  NumFactura where Id_numFactura = @UltimoId_factura
			--Crea el encabazado de la factura con valor total de 0
			Insert Into EncabezadoFacttura(Id_empleado,Id_cliente,nit_empresa,nombre_empresa,fecha_venta,total_venta,Id_numFactura) Values (@Id_empleado,@Id_cliente,'85907-8','Casa de la paleta',GETDATE(),0,@UltimoId_factura)
			--crea detalle de factura
			--declarar variable para ver ultimo encabezado de factura ha sido creado
			declare @Id_factura int
			Select @Id_factura=SCOPE_IDENTITY()
			--crea el datalle
			Insert Into DetalleFactura(Id_factura,Id_producto,Id_pago,cantidad_vendidos,sub_total)
			Select @Id_factura,ID_producto,Id_pago,Cantidad_vendidos,Sub_total from @detalle
			--se busca el total de momento
			declare @Gran_total money
			Select @Gran_total = sum (sub_total) from DetalleFactura where Id_factura= @Id_factura
			--se actualiza la factura con el total real
			declare @Id_factura_ultima as int
			Set @Id_factura_ultima =  IDENT_CURRENT('EncabezadoFacttura')
			UPDATE EncabezadoFacttura SET  total_venta = @Gran_total WHERE Id_factura=@Id_factura_ultima
			SET @mensaje= 'Se ha grabado la factura ' + Cast(@Id_factura as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_CreaPedidoP6]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_CreaPedidoP6]
(@estudiante int,@preveedor int,@detalle as dbo.informacion16 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarPedido
			Insert Into Pedido(fecha_pedido, fecha_envio, Id_proveedor, Id_empleado) Values (GETDATE(), null, @preveedor, @estudiante)
			Select @CodigoPedido=SCOPE_IDENTITY()
			Insert Into PedidoProducto(cantidad,Id_producto,Id_pedido) 
			Select cantidad,Id_producto, @CodigoPedido from @detalle
			SET @mensaje= 'Se ha grabado el prestamo ' + Cast(@CodigoPedido as nvarchar(8))+ ' con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarPedido
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End

GO
/****** Object:  StoredProcedure [dbo].[sp_Historial1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Historial1]
(@mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarHistorial
		declare @UltimoId as int 
		Set @UltimoId =  IDENT_CURRENT('Producto')
		declare @UltimoPrecio as money 
		select @UltimoPrecio = [precioVenta] FROM Producto WHERE Id_producto = @UltimoId 
		INSERT INTO HistorialPrecioVenta
        (Id_producto, fecha_mod, precioVenta)
		VALUES(@UltimoId,GETDATE(),@UltimoPrecio)
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@UltimoId as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarHistorial
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End


GO
/****** Object:  StoredProcedure [dbo].[sp_Historial2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_Historial2]
(@Id_producto int,@valor_actual money,@mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarHistorial 
		INSERT INTO HistorialPrecioVenta
        (Id_producto, fecha_mod, precioVenta)
		VALUES(@Id_producto,GETDATE(),@valor_actual)
	    SET @mensaje= 'Se ha grabado el historial ' + Cast(@Id_producto as nvarchar(8))+ ' con éxito!' COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarHistorial
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End


GO
/****** Object:  StoredProcedure [dbo].[sp_PedidoFinalizado1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[sp_PedidoFinalizado1]
(@Id_pedido int,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarFactura
			declare @total int
			select @total =  COUNT(PedidoProducto.Id_pedido) from Pedido
			INNER JOIN  PedidoProducto on PedidoProducto.Id_pedido = Pedido.Id_pedido 
			where PedidoProducto.Id_pedido=@Id_pedido
			select @total

			declare @completados int
			select @completados =  COUNT(PedidoProducto.estado) from PedidoProducto
			where PedidoProducto.Id_pedido=@Id_pedido and estado = 1
			select @completados
			if(@completados = @total)
			begin
				update Pedido set fecha_envio =GETDATE() where Id_pedido =@Id_pedido
				SET @mensaje= 'Pedido completado con exito!'
			end
			ELSE
			begin
				SET @mensaje= 'El pedido aun no ha sido finalizado'
			end
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarFactura
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_PedidoProductoFinalizado2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_PedidoProductoFinalizado2]
(@Id_pedido int,@Id_producto int,@Id_pedidoProducto int,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarPedidoFinalizado
			-- total de pedido producto por pedido y producto
			declare @total int
			select @total =  PedidoProducto.cantidad from PedidoProducto where Id_pedido = @Id_pedido and Id_producto = @Id_producto

			declare @completados int 
			select @completados =  sum(Controlalmacen.cantidad) from Controlalmacen
			where Controlalmacen.Id_productoPedido = @Id_pedidoProducto
			select @completados
			if(@completados = @total)
			begin
				update PedidoProducto set estado = 1 where Id_productoPedido =@Id_pedidoProducto
				SET @mensaje= 'Pedido completado con exito!'
			end
			ELSE
			begin
				SET @mensaje= 'El pedido aun no ha sido finalizado'
			end
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarPedidoFinalizado
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_PedidoProductoFinalizado3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_PedidoProductoFinalizado3]
(@Id_pedido int,@Id_producto int,@Id_pedidoProducto int,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	declare @CodigoPedido int
	Begin Try
		BEGIN TRANSACTION GrabarPedidoFinalizado
			declare @total int
			select @total =  PedidoProducto.cantidad from PedidoProducto where Id_pedido = @Id_pedido and Id_producto = @Id_producto
			declare @completados int 
			select @completados =  sum(Controlalmacen.cantidad) from Controlalmacen
			where Controlalmacen.Id_productoPedido = @Id_pedidoProducto
			select @completados
			if(@completados = @total)
				update PedidoProducto set estado = 1 where Id_productoPedido = @Id_pedidoProducto
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarPedidoFinalizado
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SalvarCantidad1]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_SalvarCantidad1]
(@detalle as dbo.SalvarCantidad1 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarCantidad
			UPDATE Existencia SET  cantidad = Cantidad WHERE Id_producto=ID_producto
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarCantidad
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SalvarCantidad2]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_SalvarCantidad2]
(@detalle as dbo.SalvarCantidad2 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarCantidad
			UPDATE Existencia SET  cantidad = Cantidad WHERE Id_producto=ID_producto
			SET @mensaje= 'Se han restaurando las existencias  con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarCantidad
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SalvarCantidad3]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_SalvarCantidad3]
(@detalle as dbo.SalvarCantidad3 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarCantidad
			UPDATE Existencia SET  cantidad = Cantidad WHERE Id_producto=ID_producto

			UPDATE Existencia SET cantidad=cantidad where Id_producto=Id_producto
			Select Cantidad,ID_producto from @detalle
			SET @mensaje= 'Se han restaurando las existencias  con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarCantidad
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SalvarCantidad4]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_SalvarCantidad4]
(@detalle as dbo.SalvarCantidad4 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarCantidad

			UPDATE Existencia SET  cantidad = 100 WHERE Id_producto=3
			Select Cantidad,ID_producto from @detalle

			SET @mensaje= 'Se han restaurando las existencias  con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarCantidad
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SalvarCantidad5]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_SalvarCantidad5]
(@detalle as dbo.SalvarCantidad5 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarCantidad
			UPDATE Existencia SET cantidad = Cantidad WHERE Id_producto IN (SELECT Id_producto FROM @detalle);
			SET @mensaje= 'Se han restaurando las existencias  con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarCantidad
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SalvarCantidad6]    Script Date: 11/11/2020 1:03:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_SalvarCantidad6]
(@detalle as dbo.SalvarCantidad6 readonly,  @mensaje nvarchar(250) OUTPUT)
As
Begin
	Begin Try
		BEGIN TRANSACTION GrabarCantidad
			UPDATE Existencia SET cantidad = Cantidad WHERE Id_producto IN (SELECT ID_producto FROM @detalle);
			SET @mensaje= 'Se han restaurando las existencias  con éxito!'
			COMMIT TRAN Grabar
	End Try
	Begin Catch
		ROLLBACK TRANSACTION GrabarCantidad
		Set @mensaje = 'Error: ' + ERROR_MESSAGE()
	End Catch
End
GO
