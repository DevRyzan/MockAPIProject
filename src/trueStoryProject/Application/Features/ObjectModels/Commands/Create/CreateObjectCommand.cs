using Application.Features.MockAPIModels.Dtos;
using Application.Services.MockAPIModelService; 
using AutoMapper; 
using Domain.Models;
using MediatR; 


namespace Application.Features.MockAPIModels.Commands.Create;
/// <summary>
/// The Handler class works directly with the Controller class, which manages Request and Response.
/// </summary>
public partial class CreateObjectCommand:IRequest<string>
{
    public CreateObjectDto CreateObjectDto { get; set; }


    public class CreateObjectCommandHandler : IRequestHandler<CreateObjectCommand, string>
    {
        private readonly IObjectService _mockAPIService;
        private readonly IMapper _mapper;

        public CreateObjectCommandHandler(IObjectService 
            mockAPIService,IMapper mapper )
        {
            _mockAPIService = mockAPIService;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateObjectCommand request, CancellationToken cancellationToken)
        {
            Data newData = new()
            {
                Year = request
                .CreateObjectDto
                .CreateDataDto
                .Year,
                
                Price = request
                .CreateObjectDto
                .CreateDataDto
                .Price,

                CpuModel = request
                .CreateObjectDto
                .CreateDataDto
                .CpuModel,

                HardDiskSize = request
                .CreateObjectDto
                .CreateDataDto
                .HardDiskSize,
            };


            Domain.Models.Object newObject = new()
            {
                Name = request
                .CreateObjectDto
                .Name,

                Data = newData
            };

            var mappedObject = _mapper
                .Map<Domain
            .Models
                .Object>(newObject); 
            return await _mockAPIService.CreateObject(mappedObject);


        }
    }
}
