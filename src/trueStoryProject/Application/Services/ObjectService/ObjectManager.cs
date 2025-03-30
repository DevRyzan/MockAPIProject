using Application.Features.MockAPIModels.Rules;
using Application.Services.Repositories;
using Domain.Models;

namespace Application.Services.MockAPIModelService;

public class ObjectManager : IObjectService
{
    private readonly IObjectRepository  _mockAPIModelRepository;
    private readonly ObjectBusinessRules _mockAPIModelBusinessRules;
    public ObjectManager(IObjectRepository  mockAPIModelRepository, ObjectBusinessRules mockAPIModelBusinessRules)
    {
        _mockAPIModelRepository = mockAPIModelRepository;
        _mockAPIModelBusinessRules = mockAPIModelBusinessRules;
    }
    public async Task<string> CreateObject(Domain.Models.Object mockAPIModel)
    {

        string newObject = await _mockAPIModelRepository.CreateMockAPIModel (mockAPIModel);

        return newObject;
    }
}
