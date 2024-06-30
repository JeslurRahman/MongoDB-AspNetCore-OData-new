using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using MongoDB_OData.Data;
using MongoDB_OData.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoDbService>();

#region OData Configuration
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Customer>("Customers").EntityType.HasKey(c => c.Id);

builder.Services.AddControllers().AddOData(
            options =>
            {
                options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(1000).AddRouteComponents(
                    "odata",
                    modelBuilder.GetEdmModel());
            });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
