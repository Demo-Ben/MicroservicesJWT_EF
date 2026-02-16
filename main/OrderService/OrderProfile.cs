using AutoMapper;
using OrderService.DTOs;
using OrderService.Models;

public class OrderProfile : Profile
{
	public OrderProfile()
	{
		CreateMap<Order, OrderDto>();
		CreateMap<OrderDto, Order>();
	}
}
