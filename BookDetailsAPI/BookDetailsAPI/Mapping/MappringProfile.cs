using AutoMapper;
using SharedModels;
using BookDetailsAPI.Models;

namespace BookDetailsAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SharedModels.Book, BookDetailsAPI.Models.Book>().ReverseMap();
        }
    }
}
