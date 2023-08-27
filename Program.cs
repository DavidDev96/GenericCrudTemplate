using GenericCRUDTemplate.Data.DataTransferObjects;
using GenericCRUDTemplate.Data.Models;
using GenericCRUDTemplate.MW.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<EntityLogic<Reminder, ReminderCreationDTO, ReminderUpdateDTO, ReminderInfoDTO>>();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("GenericCRUDTemplateDb"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).MigrationsHistoryTable("__MigrationHistoryCore"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
