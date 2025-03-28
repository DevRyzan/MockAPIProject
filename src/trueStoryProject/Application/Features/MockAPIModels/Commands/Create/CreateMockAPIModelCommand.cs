
using Application.Features.MockAPIModels.Dtos;
using Application.Features.MockAPIModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System.Drawing;

namespace Application.Features.MockAPIModels.Commands.Create
{
    public partial class CreateMockAPIModelCommand:IRequest<CreateMockAPIModelDto>
    {
        public string Name { get; set; }


        public class CreateMockAPIModelCommandHandler : IRequestHandler<CreateMockAPIModelCommand, CreateMockAPIModelDto>
        {
            private readonly IMockAPIModelRepository _mockAPIModelRepository;
            private readonly IMapper _mapper;
            private readonly MockAPIModelBusinessRules _brandBusinessRules;

            public CreateMockAPIModelCommandHandler(IMockAPIModelRepository mockAPIModelRepository,IMapper mapper,MockAPIModelBusinessRules mockAPIModelBusinessRules)
            {
                _mockAPIModelRepository = mockAPIModelRepository;
                _mapper = mapper;
                _brandBusinessRules = mockAPIModelBusinessRules;
            }

            public async Task<CreateMockAPIModelDto> Handle(CreateMockAPIModelCommand request, CancellationToken cancellationToken)
            {
               

            }
        }
    }
}
