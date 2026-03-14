using AutoMapper;
using SharedKernel.DTOs;
using SharedKernel.Models;

public class PaymentProfile : Profile
{
	public PaymentProfile()
	{
		CreateMap<Payment, PaymentDto>();
		CreateMap<PaymentDto, Payment>();
	}
}
