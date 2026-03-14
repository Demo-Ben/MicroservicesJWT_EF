using AutoMapper;
using SharedKernel.DTOs;
using SharedKernel.Models;

public class OrderProfile : Profile
{
	public OrderProfile()
	{
		CreateMap<Order, OrderDto>();
		CreateMap<OrderDto, Order>();
	}
}
