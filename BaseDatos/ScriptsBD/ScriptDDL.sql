USE [ComidasRapidas]
GO
/****** Object:  Table [dbo].[Alimento]    Script Date: 12/07/2024 11:54:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alimento](
	[IdAlimento] [varchar](50) NOT NULL,
	[NombreAlimento] [varchar](50) NOT NULL,
	[PrecioAlimento] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Alimento] PRIMARY KEY CLUSTERED 
(
	[IdAlimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bebida]    Script Date: 12/07/2024 11:54:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bebida](
	[IdBebida] [varchar](50) NOT NULL,
	[NombreBebida] [varchar](50) NOT NULL,
	[PrecioBebida] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Bebida] PRIMARY KEY CLUSTERED 
(
	[IdBebida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 12/07/2024 11:54:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdProducto] [varchar](50) NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[Cantidad] [varchar](6) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Descuento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/07/2024 11:54:20 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pp_listar]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Inventario;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pp_obtener](@idProducto varchar(50))
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM Inventario
	WHERE IdProducto = @idProducto;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pp_registrar]
(
	@idProducto varchar(50),
	@nombreProducto varchar(50),
	@cantidad varchar(6),
	@categoria varchar(50),
	@descuento varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Inventario
	(
		IdProducto,
		NombreProducto,
		Cantidad,
		Categoria,
		Descuento
	)
	VALUES
	(
		@idProducto,
		@nombreProducto,
		@cantidad,
		@categoria,
		@descuento
	)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pp_modificar]
(
	@idProducto varchar(50),
	@nombreProducto varchar(50),
	@cantidad varchar(6),
	@categoria varchar(50),
	@descuento varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Inventario SET
		NombreProducto = @nombreProducto,
		Cantidad = @cantidad,
		Categoria = @categoria,
		Descuento = @descuento
	WHERE IdProducto = @idProducto
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pp_eliminar]
(
	@idProducto varchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Inventario
	WHERE IdProducto = @idProducto
END
GO