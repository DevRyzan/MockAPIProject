using Application.Features.MockAPIModels.Dtos;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ObjectModels.Profiles;
public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Object, CreateObjectDto>().ReverseMap();
    }
}