using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SharedKernel.Models;

namespace PaymentService.Data;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

    public DbSet<Payment> Payments { get; set; }
}

// Add-Migration InitialCreate
// Update-Database


//USE [PaymentServiceDb]
//GO

///****** Object:  Table [dbo].[Payments]    Script Date: 18/02/2026 7:47:43 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Payments](
//	[Id] [int] IDENTITY(1,1) NOT NULL,
//	[TransactionId] [nvarchar](max) NULL,
//	[OrderId] [int] NOT NULL,
//	[Amount] [decimal](18, 2) NOT NULL,
//	[Status] [nvarchar](max) NOT NULL,
//	[PaidAt] [datetime2](7) NOT NULL,
//	[RefundedAt] [datetime2](7) NULL,
// CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
//(
//	[Id] ASC
//)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
//) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
//GO
