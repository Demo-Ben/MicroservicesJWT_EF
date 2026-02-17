using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SharedKernel.Models;
using System.Collections.Generic;

namespace InventoryService.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    public DbSet<InventoryItem> Inventory { get; set; }
}


// Add-Migration InitialCreate
// Update-Database



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

//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[Inventory]
//(
//    [Id][int] IDENTITY(1,1) NOT NULL,

//    [ProductId] [nvarchar] (max) NOT NULL,
//	  [QuantityAvailable] [int] NOT NULL,
//    [WarehousId] [varchar] (20) NOT NULL,
//    [LastUpdateAt] [datetime2] (7) NOT NULL,
// CONSTRAINT[PK_Inventory] PRIMARY KEY CLUSTERED
//(
//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
//GO
