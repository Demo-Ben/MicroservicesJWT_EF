using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SharedKernel.Models
{
    public class Payment
    {

        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; } // ← THIS is the one you use
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // "Success", "Failed", "Refunded"
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public DateTime? RefundedAt { get; set; } =  DateTime.UtcNow;
    }
}


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

