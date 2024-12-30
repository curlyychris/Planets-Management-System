using System;

namespace Backend.Application.Repositories.IRepositories;

public interface IUserRepository
{
    public Task<bool> DoesUserExist(Guid userId);
}
