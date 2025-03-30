using Core.Persistence.Paging;
using Domain.Models;

namespace Application.Services.MockAPIModelService;

public interface IObjectService
{
    public Task<string> CreateObject(Domain.Models.Object modelObject);
    public Task<string> DeleteObject(string objectId);
    public Task<IPaginate<Domain.Models.Object>> GetObjectListAsync(string? nameFilter = null
        ,int index = 0
        ,int size = 10
        ,CancellationToken cancellationToken = default);
        


}
