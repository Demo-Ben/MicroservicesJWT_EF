namespace OrderService
{
    using AutoMapper;
    using OrderService.DTOs;
    using OrderService.Models;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Maps Order -> OrderDto
            CreateMap<Order, OrderDto>();

            // Optional: If you also need to map OrderDto -> Order
            // CreateMap<OrderDto, Order>();
        }
    }

}
