using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Persistence;

public class DataContext:IdentityDbContext<User,IdentityRole<Guid>,Guid>
{
    public DataContext(DbContextOptions<DataContext>options):base(options)
    {
        
    }
    public required DbSet<Planet> Planets {get; set;}
}
