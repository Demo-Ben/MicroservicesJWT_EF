using AutoMapper;
using PaymentService.DTOs;
using PaymentService.Models;

public class PaymentProfile : Profile
{
	public PaymentProfile()
	{
		CreateMap<Payment, PaymentDto>();
		CreateMap<PaymentDto, Payment>();
	}
}
