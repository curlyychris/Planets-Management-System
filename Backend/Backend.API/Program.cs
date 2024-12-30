using Backend.API;
using Backend.API.ApiEndpoints;
using Backend.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddApplication(builder.Configuration).AddSecurity(builder.Configuration);

var app = builder.Build();

app.MapApiEndpoint();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("defaultPolicy");
app.Run();
