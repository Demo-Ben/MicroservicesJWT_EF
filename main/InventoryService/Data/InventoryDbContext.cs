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



//USE[InventoryServiceDb]
//GO

///****** Object:  Table [dbo].[InventoryItem]    Script Date: 18/02/2026 7:02:23 PM ******/
//IF EXISTS(SELECT* FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryItem]') AND type in (N'U'))
//DROP TABLE[dbo].[InventoryItem]
//GO

///****** Object:  Table [dbo].[InventoryItem]    Script Date: 18/02/2026 7:02:23 PM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[InventoryItem]
//(
//    [Id][int] IDENTITY(1,1) NOT NULL,
//    [ProductId] [int] NOT NULL,
//    [QuantityAvailable] [int] NOT NULL
//) ON[PRIMARY]
//GO





//USE[InventoryServiceDb]
//GO

///****** Object:  Table [dbo].[Inventory]    Script Date: 18/02/2026 7:00:48 PM ******/
//IF EXISTS(SELECT* FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
//DROP TABLE[dbo].[Inventory]
// GO

///****** Object:  Table [dbo].[Inventory]    Script Date: 18/02/2026 7:00:48 PM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[Inventory]
//(
//    [Id][int] IDENTITY(1,1) NOT NULL,
//    [ProductId] [int] NOT NULL,
//    [QuantityAvailable] [int] NOT NULL,
// CONSTRAINT[PK_Inventory] PRIMARY KEY CLUSTERED
//(
//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO




