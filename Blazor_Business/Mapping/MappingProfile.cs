using System;
using AutoMapper;
using Blazor_Infrastructure;
using Blazor_Infrastructure.Data.Entities;
using Blazor_Models;

namespace Blazor_Business.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Category, CategoryDTO>()
				.ReverseMap()
				.ForMember(x => x.CreatedDate, x => x.MapFrom(x => DateTime.Now));

			CreateMap<Product, ProductDTO>()
				.ReverseMap();
		}
	}
}

