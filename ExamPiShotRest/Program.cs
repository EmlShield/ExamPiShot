var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
const string AllowAllPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllPolicy,
                             policy =>
                             {
                                 policy.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                             });
});

var app = builder.Build();
app.UseCors(AllowAllPolicy);

// Configure the HTTP request pipeline.
app.MapOpenApi();


app.UseAuthorization();

app.MapControllers();

app.Run();
