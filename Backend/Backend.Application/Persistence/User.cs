using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Persistence;

public class User:IdentityUser<Guid>
{
    public override Guid Id { get; set; }=Guid.NewGuid();  
    public List<Planet> Planets { get; set; }=new List<Planet>();
}
