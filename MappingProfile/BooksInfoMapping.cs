using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookShop.Models;
namespace BookShop.MappingProfile
{
    public class BooksInfoMapping : Profile
    {
        public BooksInfoMapping()
        {
         
            CreateMap<Authors, AuthorsInfo>().ReverseMap();
            CreateMap<Publishers, PublishersInfo>().ReverseMap();
            CreateMap<Titles, BooksInfo>()
            .ForMember(dest => dest.Au , act => act.MapFrom(src => src.Au))
            .ForMember(dest => dest.Pub, act => act.MapFrom(src => src.Pub));

            CreateMap<BookInsert, Titles>();
            CreateMap<BookUpdate, Titles>().ReverseMap();
            CreateMap<Authors, AuthorsUpdate>().ReverseMap();
        }
        
    }
}
