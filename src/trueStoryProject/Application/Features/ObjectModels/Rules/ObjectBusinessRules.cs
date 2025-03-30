using Application.Services.Repositories;

namespace Application.Features.MockAPIModels.Rules;

public class ObjectBusinessRules
{
    private readonly IObjectRepository _mockAPIModelRepository;

    public ObjectBusinessRules(IObjectRepository mockAPIModelRepository)
    {
        _mockAPIModelRepository = mockAPIModelRepository;
    }
    //public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    //{
    //    User? user = await _userRepository.GetAsync(u => u.Email == email);
    //    if (user != null) throw new BusinessException("Mail already exists");

    //}

}
