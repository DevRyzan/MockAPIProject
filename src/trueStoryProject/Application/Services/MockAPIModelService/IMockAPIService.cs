using Domain.Models;

namespace Application.Services.MockAPIModelService;

public interface IMockAPIService
{
    public Task<string> CreateMockAPIModel(MockAPIModel mockAPIModel);


}
