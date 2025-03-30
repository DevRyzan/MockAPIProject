using Application.Features.MockAPIModels.Dtos;
using Application.Features.ObjectModels.Dtos;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ObjectModels.Profiles;
public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Domain.Models.Object, CreateObjectDto>().ReverseMap();
        CreateMap<IPaginate<Domain.Models.Object>, ObjectListModel>().ReverseMap();
        CreateMap<Domain.Models.Object, ObjectListDto>().ReverseMap();

    }
}