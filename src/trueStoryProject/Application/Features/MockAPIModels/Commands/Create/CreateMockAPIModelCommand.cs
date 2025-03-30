using Application.Features.MockAPIModels.Dtos;
using Application.Features.MockAPIModels.Rules;
using Application.Services.MockAPIModelService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Models;
using MediatR;


namespace Application.Features.MockAPIModels.Commands.Create;            

public partial class CreateMockAPIModelCommand:IRequest<CreateMockAPIModelDto>
{
    public CreateMockAPIModelDto CreateMockAPIModelDto { get; set; }


    public class CreateMockAPIModelCommandHandler : IRequestHandler<CreateMockAPIModelCommand, CreateMockAPIModelDto>
    {
        private readonly IMockAPIModelRepository _mockAPIModelRepository;
        private readonly IMockAPIService _mockAPIService;
        private readonly IMapper _mapper;
        private readonly MockAPIModelBusinessRules _brandBusinessRules;

        public CreateMockAPIModelCommandHandler(IMockAPIModelRepository mockAPIModelRepository,IMockAPIService 
            mockAPIService,IMapper mapper,MockAPIModelBusinessRules mockAPIModelBusinessRules)
        {
            _mockAPIModelRepository = mockAPIModelRepository;
            _mockAPIService = mockAPIService;
            _mapper = mapper;
            _brandBusinessRules = mockAPIModelBusinessRules;
        }

        public async Task<CreateMockAPIModelDto> Handle(CreateMockAPIModelCommand request, CancellationToken cancellationToken)
        {
            MockAPIModel newMockAPIModel = new()
            {
                Name = request.CreateMockAPIModelDto.Name,
                Description = request.CreateMockAPIModelDto.Description,
                Author = request.CreateMockAPIModelDto.Author,
            };

            _mockAPIService.CreateMockAPIModel(newMockAPIModel);


        }
    }
}
