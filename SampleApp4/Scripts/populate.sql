/****** Object:  Table [dbo].[Products]    Script Date: 7/5/2024 10:33:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[ProductName] [nvarchar](max) NULL,
	[CategoryName] [nvarchar](max) NULL,
	[SupplierID] [int] NULL,
	[Supplier] [nvarchar](max) NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](max) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[UnitsOnOrder] [int] NULL,
	[ReorderLevel] [int] NULL,
 CONSTRAINT [PK_ImportedProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ExcelMapperSamples] SET  READ_WRITE 
GO
