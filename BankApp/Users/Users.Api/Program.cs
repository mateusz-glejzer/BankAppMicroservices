using Microsoft.EntityFrameworkCore;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using Users.Api;
using Users.Core.Repositories;
using Users.Infrastructure;
using Users.Infrastructure.Events.External.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer((builder.Configuration.GetSection("ConnectionString").Value)));
builder.Services.AddScoped<AccountCreatedHandler>();
builder.Services.AddInfrastructure();
builder.Services.AddTransient<IUserRepository, SqlServerRepository>();
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddHostedService<AccountCollector>();
builder.Services.AddSingleton<IConnectionProvider>(new ConnectionProvider("amqp://guest:guest@localhost:5672"));
builder.Services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
    "account_exchange",
    "account_queue",
    "account.*",
    ExchangeType.Topic));

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