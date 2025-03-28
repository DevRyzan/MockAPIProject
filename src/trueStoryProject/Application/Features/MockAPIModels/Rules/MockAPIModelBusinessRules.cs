using Application.Services.Repositories;

namespace Application.Features.MockAPIModels.Rules;

public class MockAPIModelBusinessRules
{
    private readonly IMockAPIModelRepository _mockAPIModelRepository;

    public MockAPIModelBusinessRules(IMockAPIModelRepository mockAPIModelRepository)
    {
        _mockAPIModelRepository = mockAPIModelRepository;
    }


}
