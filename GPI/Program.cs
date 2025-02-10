using GPI.Application;
using GPI.Infrastructure;
using GPI.Persistence;
using GPI.Presentation;
using GPI.Presentation.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication()
    .AddPersistence(builder.Configuration)
    .AddInfrastructure()
    .AddPresentation(builder.Configuration);

builder.Services.AddCors(cors =>
{
    cors.AddPolicy("Default", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:4200")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Default");

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<SignalRClient>("/hubs/client");
app.MapControllers();

SeedData(app);

app.Run();

return;

void SeedData(WebApplication application)
{
    using IServiceScope scope = application.Services.CreateScope();
    ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    ApplicationDbContext.SeedData(context);
}