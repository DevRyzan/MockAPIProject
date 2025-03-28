﻿using Core.Persistence.Repositories;
using Domain.Models;

namespace Application.Services.Repositories;

public  interface IMockAPIModelRepository: IAsyncRepository<MockAPIModel>,IRepository<MockAPIModel>
{
}
