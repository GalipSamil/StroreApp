﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entities.Dtos;
using StoreApp.Entities.Models;

namespace StoreApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion,Product>();
            CreateMap<ProductDtoForUpdate,Product>().ReverseMap();
            CreateMap<UserDtoForCreation,Product>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();

        }
    }
}
