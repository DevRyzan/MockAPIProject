
namespace Application.Services.Repositories;

public interface IObjectRepository
{
    public Task<string> CreateObjectModel(Domain.Models.Object mockAPIModel);
    public Task<string> DeleteObjectModel(string objectIds);

}
