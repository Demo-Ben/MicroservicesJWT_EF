using AutoMapper;
using SharedKernel.DTOs;
using SharedKernel.Models;

public class InventoryProfile : Profile
{
	public InventoryProfile()
	{
		CreateMap<InventoryItem, InventoryItemDto>();
		CreateMap<InventoryItemDto, InventoryItem>();
	}
}
