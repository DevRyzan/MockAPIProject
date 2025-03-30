using Application.Features.MockAPIModels.Rules;
using Application.Services.Repositories; 

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
        try
        { 
           // await _mockAPIModelBusinessRules.CheckIfObjectNameIsValid(mockAPIModel.Name);

            var newObject = await _mockAPIModelRepository.CreateObjectModel(mockAPIModel);
            return newObject;
        }
        catch (Exception ex)
        { 
            throw new Exception("Error occurred while creating object.", ex);
        }
    }
    public async Task<string> DeleteObject(string objectId)
    {
        try
        {
            var deletedObject = await _mockAPIModelRepository.DeleteObjectModel(objectId);
            return deletedObject;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while deleting object.", ex);
        }
    }
}
