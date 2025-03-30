﻿using Domain.Models;

namespace Application.Services.MockAPIModelService;

public interface IObjectService
{
    public Task<string> CreateObject(Domain.Models.Object modelObject);
    public Task<string> DeleteObject(string objectId);


}
