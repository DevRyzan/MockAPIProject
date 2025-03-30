using Application.Features.MockAPIModels.Dtos;
using Application.Features.MockAPIModels.Rules;
using Application.Services.MockAPIModelService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Models;
using MediatR;


namespace Application.Features.MockAPIModels.Commands.Create;            

public partial class CreateObjectCommand:IRequest<string>
{
    public CreateObjectDto CreateObjectDto { get; set; }


    public class CreateMockAPIModelCommandHandler : IRequestHandler<CreateObjectCommand, string>
    {
        private readonly IObjectService _mockAPIService;
        private readonly IMapper _mapper;
        private readonly ObjectBusinessRules _brandBusinessRules;

        public CreateMockAPIModelCommandHandler(IObjectRepository mockAPIModelRepository,IObjectService 
            mockAPIService,IMapper mapper,ObjectBusinessRules mockAPIModelBusinessRules)
        {
            _mockAPIService = mockAPIService;
            _mapper = mapper;
            _brandBusinessRules = mockAPIModelBusinessRules;
        }

        public async Task<string> Handle(CreateObjectCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Object newMockAPIModel = new()
            {
                Name = request.CreateObjectDto.Name
            };

            return await _mockAPIService.CreateObject(newMockAPIModel);


        }
    }
}
