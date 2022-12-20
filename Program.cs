using Microsoft.EntityFrameworkCore;
using PassangerApi;
using PassangerApi.DataContext;
using PassangerApi.Repository;
using PassangerApi.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddDbContext<PassangerDbContext>(option => 
{ 
option.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<IPassangerRepository, PassangerRepository>();

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
