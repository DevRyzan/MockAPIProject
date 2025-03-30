using Application.Features.MockAPIModels.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;

namespace Application.Services.MockAPIModelService;

public class ObjectManager : IObjectService
{
    private readonly IObjectRepository  _objectRepository;
    private readonly ObjectBusinessRules _mockAPIModelBusinessRules;
    public ObjectManager(IObjectRepository  objectRepository, ObjectBusinessRules objectBusinessRules)
    {
        _objectRepository = objectRepository;
        _mockAPIModelBusinessRules = objectBusinessRules;
    }
    public async Task<string> CreateObject(Domain.Models.Object mockAPIModel)
    {
        try
        { 
           // await _mockAPIModelBusinessRules.CheckIfObjectNameIsValid(mockAPIModel.Name);

            var newObject = await _objectRepository.CreateObjectModel(mockAPIModel);
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
            var deletedObject = await _objectRepository.DeleteObjectModel(objectId);
            return deletedObject;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while deleting object.", ex);
        }
    }
    public async Task<IPaginate<Domain.Models.Object>> GetObjectListAsync(
    string? nameFilter = null,
    int index = 0,
    int size = 10,
    CancellationToken cancellationToken = default)
    {
        try
        {
            var objectList = await _objectRepository.GetListAsync(nameFilter, index, size, cancellationToken);

            if (objectList == null || !objectList.Items.Any())
            {
                throw new Exception("No objects found.");
            }

            return objectList;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while fetching object list.", ex);
        }
    }

}
