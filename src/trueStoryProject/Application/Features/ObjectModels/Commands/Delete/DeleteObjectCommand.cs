using Application.Services.MockAPIModelService;
using MediatR;

namespace Application.Features.ObjectModels.Commands.Delete;

public class DeleteObjectCommand:IRequest<string>
{
    public string ObjectId { get; set; }

    public DeleteObjectCommand(string objectId)
    {
        ObjectId = objectId;
    }

    public class DeleteObjectCommandHandler : IRequestHandler<DeleteObjectCommand, string>
    {
        private readonly IObjectService _mockAPIService;

        public DeleteObjectCommandHandler(IObjectService mockAPIService)
        {
            _mockAPIService = mockAPIService;
        }

        public async Task<string> Handle(DeleteObjectCommand request, CancellationToken cancellationToken)
        {
            return await _mockAPIService.DeleteObject(request.ObjectId);
        }
    }
}
