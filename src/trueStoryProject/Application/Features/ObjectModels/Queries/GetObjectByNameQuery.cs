using Application.Features.MockAPIModels.Rules;
using Application.Features.ObjectModels.Dtos;
using Application.Services.MockAPIModelService;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ObjectModels.Queries;

public class GetObjectByNameQuery:IRequest<ObjectListModel>
{
    public string Name { get; set; }
    public PageRequest PageRequest { get; set; }
    public class GetObjectByNameQueryHandler : IRequestHandler<GetObjectByNameQuery, ObjectListModel>
    { 
        private readonly IMapper _mapper;
        private readonly IObjectService _objectService;
        private readonly ObjectBusinessRules _objectBusinessRules;

        public GetObjectByNameQueryHandler(IObjectService objectService
            , IMapper mapper
            , ObjectBusinessRules objectBusinessRules)
        { 
            _mapper = mapper;
            _objectService = objectService;
            _objectBusinessRules = objectBusinessRules;
        }

        public async Task<ObjectListModel> Handle(GetObjectByNameQuery request, CancellationToken cancellationToken)
        {
            //var objectList = await _objectService.GetObjectListAsync(
            //    nameFilter: request.Name,
            //    index: request.PageRequest.Page,
            //    size: request.PageRequest.PageSize,
            //    cancellationToken: cancellationToken
            //);

            IPaginate<Domain.Models.Object> listObject = await _objectService.GetObjectListAsync(
                nameFilter: request.Name,
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            ObjectListModel mappedObjectList = _mapper.Map<ObjectListModel>(listObject);


            return mappedObjectList;
        }
    }
}
