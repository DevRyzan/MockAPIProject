using Core.Persistence.Repositories;
using Domain.Models;

namespace Application.Services.Repositories;

public interface IObjectRepository
{
    public Task<string> CreateObjectModel(Domain.Models.Object mockAPIModel);

}
