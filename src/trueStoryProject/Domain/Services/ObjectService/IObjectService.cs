using Domain.Models;

namespace Application.Services.MockAPIModelService;

public interface IObjectService
{
    public Task<string> CreateMockAPIModel(Domain.Models.Object mockAPIModel);


}
