using System;
using Backend.Application.Persistence;
using Backend.Application.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext dataContext;

    public UserRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    public Task<bool> DoesUserExist(Guid userId)
    {
        return dataContext.Users.AnyAsync(x=>x.Id==userId);
    }
}
