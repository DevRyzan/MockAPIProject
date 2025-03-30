using Core.Persistence.Paging;
using System.Linq.Dynamic.Core;

namespace Application.Services.Repositories;

public interface IObjectRepository
{
    public Task<string> CreateObjectModel(Domain.Models.Object mockAPIModel);
    public Task<string> DeleteObjectModel(string objectId);
    public Task<IPaginate<Domain.Models.Object>> GetListAsync(
    string? nameFilter = null,
    int index = 0,
    int size = 10,
    CancellationToken cancellationToken = default);
    public Task<List<Domain.Models.Object>> GetAllObjectsAsync(CancellationToken cancellationToken = default);
    public Task<Domain.Models.Object> GetObjectByIdAsync(string objectId, CancellationToken cancellationToken = default);
}
