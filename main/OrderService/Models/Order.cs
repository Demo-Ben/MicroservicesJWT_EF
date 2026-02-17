using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Models;

//public class Order
//{
//    public int Id { get; set; }
//    public string ProductId { get; set; }
//    public int Quantity { get; set; }
//    public decimal Amount { get; set; }
//}

public class Order
{
    [Key]
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    public required string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}


//USE[OrderServiceDb]
//GO

///****** Object:  Table [dbo].[Orders]    Script Date: 18/02/2026 7:47:01 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE[dbo].[Orders]
//(

//    [Id][int] IDENTITY(1,1) NOT NULL,

//    [ProductId] [nvarchar] (max) NOT NULL,
//	[Quantity]
//[int]
//NOT NULL,

//    [Amount] [decimal] (18, 2) NOT NULL,

//    [Status] [nvarchar] (max) NOT NULL,
//	[CreatedAt][datetime2] (7) NOT NULL,
// CONSTRAINT[PK_Orders] PRIMARY KEY CLUSTERED
//(
//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
//GO

//ALTER TABLE[dbo].[Orders] ADD CONSTRAINT[DF_Orders_Status]  DEFAULT(N'Pending') FOR[Status]
//GO

