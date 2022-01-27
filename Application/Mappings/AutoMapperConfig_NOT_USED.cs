using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class AutoMapperConfig_NOT_USED
    {
        public static IMapper Initlialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDto>();
                cfg.CreateMap<CreatePostDto, Post>();
                cfg.CreateMap<UpdatePostDto, Post>();
            }).CreateMapper();
        }
    }
}
