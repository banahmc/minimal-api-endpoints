using WebApp.EndpointDefinitions.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(Program).Assembly);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseEndpointDefinitions();

app.Run();