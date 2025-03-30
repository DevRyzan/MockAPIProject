using Application.Features.MockAPIModels.Rules;
using Application.Features.ObjectModels.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Application.Services.MockAPIModelService;
/// <summary>
/// The Service Layer works directly with the Repository and Rule layers, the layer where all business blocks are managed.
/// </summary>
public class ObjectManager : IObjectService
{
    private readonly IObjectRepository  _objectRepository;
    private readonly ObjectBusinessRules _objectBusinessRules;
    public ObjectManager(IObjectRepository  objectRepository, ObjectBusinessRules objectBusinessRules)
    {
        _objectRepository = objectRepository;
        _objectBusinessRules = objectBusinessRules;
    }
    public async Task<string> CreateObject(Domain.Models.Object objectModel)
    {
        try
        { 
           await _objectBusinessRules.ObjectShouldBeNotExists(objectModel);

            var newObject = await _objectRepository.CreateObjectModel(objectModel);
            return newObject;
        }
        catch (Exception ex)
        { 
            throw new BusinessException(ObjectModelMessages.ErrorOccurredWhileCreatingObject);
        }
    }
    public async Task<string> DeleteObject(string objectId)
    {
        try
        {
            await _objectBusinessRules.ObjectShouldBeExistsById(objectId:objectId);

            var deletedObject = await _objectRepository.DeleteObjectModel(objectId:objectId);
            return deletedObject;
        }
        catch (Exception ex)
        {
            throw new BusinessException(ObjectModelMessages.ErrorOccurredWhileDeletingObject);
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

            //BusinessRule Call
            if (objectList == null || !objectList.Items.Any())
                throw new BusinessException(ObjectModelMessages.ObjectNotExists);
            

            return objectList;
        }
        catch (Exception ex)
        {
            throw new BusinessException(ObjectModelMessages.ErrorOccurredWhileFetchingObjectList);
        }
    }

}
