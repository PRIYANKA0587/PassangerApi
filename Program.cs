using Microsoft.EntityFrameworkCore;
using PassengerApi;
using PassengerApi.DataContext;
using PassengerApi.Repository;
using PassengerApi.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddDbContext<PassengerDbContext>(option => 
{ 
option.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
