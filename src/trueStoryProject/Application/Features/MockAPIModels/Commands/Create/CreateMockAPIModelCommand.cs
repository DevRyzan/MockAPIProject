
using Application.Features.MockAPIModels.Dtos;
using AutoMapper;
using MediatR;
using System.Drawing;

namespace Application.Features.MockAPIModels.Commands.Create
{
    public partial class CreateMockAPIModelCommand:IRequest<CreateMockAPIModelDto>
    {
        public string Name { get; set; }


        public class CreateMockAPIModelCommandHandler : IRequest<CreateMockAPIModelCommand, CreateMockAPIModelDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateMockAPIModelCommandHandler()
            {
                
            }


        }
    }
}
