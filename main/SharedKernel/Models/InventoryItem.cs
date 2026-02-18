using System.ComponentModel.DataAnnotations;

namespace SharedKernel.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityAvailable { get; set; }

        public DateTime LastUpdated { get; set; }
    }

}


//USE [InventoryServiceDb]
//GO

///****** Object:  Table [dbo].[InventoryItem]    Script Date: 18/02/2026 7:50:46 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[InventoryItem](
//	[Id] [int] IDENTITY(1,1) NOT NULL,
//	[ProductId] [nvarchar](max) NOT NULL,
//	[QuantityAvailable] [int] NOT NULL
//) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
//GO

//USE [InventoryServiceDb]
//GO

///****** Object:  Table [dbo].[InventoryItem]    Script Date: 18/02/2026 7:50:46 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[InventoryItem](
//	[Id] [int] IDENTITY(1,1) NOT NULL,
//	[ProductId] [nvarchar](max) NOT NULL,
//	[QuantityAvailable] [int] NOT NULL
//) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
//GO


// *** Inventory is not in use, but leaving it here for reference. ***

//USE [InventoryServiceDb]
//GO

///****** Object:  Table [dbo].[Inventory]    Script Date: 18/02/2026 7:52:47 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Inventory](
//	[Id] [int] IDENTITY(1,1) NOT NULL,
//	[ProductId] [nvarchar](max) NOT NULL,
//	[QuantityAvailable] [int] NOT NULL,
// CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
//(
//	[Id] ASC
//)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
//) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
//GO

//USE [InventoryServiceDb]
//GO

///****** Object:  Table [dbo].[Inventory]    Script Date: 18/02/2026 7:52:47 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Inventory](
//	[Id] [int] IDENTITY(1,1) NOT NULL,
//	[ProductId] [nvarchar](max) NOT NULL,
//	[QuantityAvailable] [int] NOT NULL,
// CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
//(
//	[Id] ASC
//)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
//) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
//GO

