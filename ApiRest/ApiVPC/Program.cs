using ApiVPC.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the DBContext and connection to the DB.
builder.Services.AddDbContext<ApiVpContext>(options => {
    string connecStr = builder.Configuration.GetConnectionString("connecMysql");
    options.UseMySql(connecStr, ServerVersion.AutoDetect(connecStr));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

