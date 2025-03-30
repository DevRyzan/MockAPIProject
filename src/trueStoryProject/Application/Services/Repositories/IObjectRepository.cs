using Core.Persistence.Repositories;
using Domain.Models;

namespace Application.Services.Repositories;

public interface IObjectRepositor 
{
    public Task<string> CreateMockAPIModel(Domain.Models.Object mockAPIModel);

}
