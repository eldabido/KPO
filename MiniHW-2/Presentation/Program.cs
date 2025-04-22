using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ZooManagement;
using MediatR;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

// Создание приложения и маленький тест.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1", new OpenApiInfo
    {
        Title = "ZooManagement",
        Version = "1"
    });
});

builder.Services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
builder.Services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
builder.Services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();
builder.Services.AddSingleton<IEventHandler, ZooManagement.EventHandler>();
builder.Services.AddSingleton<IAnimalTransferService, AnimalTransferService>();
builder.Services.AddSingleton<IFeedingOrganizationService, FeedingOrganizationService>();
builder.Services.AddSingleton<IZooStatisticsService, ZooStatisticsService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZooManagement 1");
        c.RoutePrefix = "swagger";
    });
}

await SeedInitialData(app.Services);
app.Run();

async Task SeedInitialData(IServiceProvider services)
{
    var animalRepo = services.GetRequiredService<IAnimalRepository>();
    var enclosureRepo = services.GetRequiredService<IEnclosureRepository>();

    var predatorEnclosure = new Enclosure(Guid.NewGuid(), "Predator", "La", 5);

    await enclosureRepo.AddAsync(predatorEnclosure);


    var lion = new Animal(Guid.NewGuid(), "Lion", "Sanya", new DateTime(2011, 12, 15), "Male", "Meat", predatorEnclosure.Id);

    await animalRepo.AddAsync(lion);


    predatorEnclosure.AddAnimal(lion.Id);


    await enclosureRepo.UpdateAsync(predatorEnclosure);

}
