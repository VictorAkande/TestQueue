using MassTransit;
using Model;
using PubConsumer.API;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardService,CardService>();

builder.Services.AddMassTransit(config =>
{

    config.SetKebabCaseEndpointNameFormatter();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://telleruser:tellerpass@10.100.72.111:5762/teller");
        cfg.ExchangeType = ExchangeType.Direct;
        // Manually declare the exchange


        //cfg.ReceiveEndpoint("Icard_Out", ep => { });
        //cfg.ReceiveEndpoint("Prime_Out", ep => { });
    });

});
    

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
