using Application.Services.Repositories;

namespace Application.Features.MockAPIModels.Rules;

public class ObjectBusinessRules
{
    private readonly IObjectRepository _objectRepository;

    public ObjectBusinessRules(IObjectRepository objectRepository)
    {
        _objectRepository = objectRepository;
    }
    /// <summary>
    /// The rule that compares the name properties of the data to be added to the entire list before the Create function.
    /// </summary>
    /// <param name="objectModel"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task ObjectShouldBeNotExists(Domain.Models.Object objectModel)
    {
        if (string.IsNullOrEmpty(objectModel.Name))
            throw new Exception("Object name cannot be empty.");

        //The query should work with by Name property.
        var allObjects = await _objectRepository.GetAllObjectsAsync();
        
        if (allObjects.Any(obj => obj.Name.Equals(objectModel.Name, StringComparison.OrdinalIgnoreCase)))
            throw new Exception("Object with this name already exists.");
    }
    /// <summary>
    /// Check if there is any data with this Object ID in the list
    /// </summary>
    /// <param name="objectId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task ObjectShouldBeExistsById(string objectId)
    {
        var objectModel = await _objectRepository.GetObjectByIdAsync(objectId:objectId);
        if (objectModel == null)
            throw new Exception("Object Not Exists.");
        
         
    }
}
