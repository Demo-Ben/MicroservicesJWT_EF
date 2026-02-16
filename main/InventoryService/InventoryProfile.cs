using AutoMapper;
using InventoryService.DTOs;
using InventoryService.Models;

public class InventoryProfile : Profile
{
	public InventoryProfile()
	{
		CreateMap<InventoryItem, InventoryItemDto>();
		CreateMap<InventoryItemDto, InventoryItem>();
	}
}
