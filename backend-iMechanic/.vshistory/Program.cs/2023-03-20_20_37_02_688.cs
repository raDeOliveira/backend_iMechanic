using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// MS SQL connection string
var sqlConnectionString = builder.Configuration.GetConnectionString("iMechanicDbContext");
//builder.Services.AddDbContext<iMechanicDbContext>(options => options.UseSqlServer(sqlConnectionString));

// MySQL connection string
builder.Services.AddDbContextPool<iMechanicDbContext>(options =>
        {
            var connetionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        });



//builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors",
        b => b.AllowAnyMethod()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
