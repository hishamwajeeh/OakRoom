using AutoMapper;
using OakRoom.Application.Restaurants.Command.CreateRestaurant;
using OakRoom.Application.Restaurants.Command.UpdateRestaurant;
using OakRoom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakRoom.Application.Restaurants.Dtos
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<UpdateRestaurantCommand, Restaurant>();

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(d => d.Address, opt =>
                    opt.MapFrom(src => new Address
                    {
                        City = src.City,
                        PostalCode = src.PostalCode,
                        Street = src.Street
                    }));

            CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.PostalCode, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Street, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}
