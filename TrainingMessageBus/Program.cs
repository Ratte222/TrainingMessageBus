using MassTransit;
using System.Reflection;
using TrainingMessageBus.Consumers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.SetInMemorySagaRepositoryProvider();
            
            var entryAssemply = Assembly.GetEntryAssembly();
            x.AddConsumers(entryAssemply);
            x.AddSagaStateMachines(entryAssemply);
            x.AddSagas(entryAssemply);
            x.AddActivities(entryAssemply);

            x.AddConsumer<MessageConsumer>();

            //x.UsingInMemory((context, cfg) =>
            //{
            //    cfg.ConfigureEndpoints(context);
            //});
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ConfigureEndpoints(context);
            });
        });

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
    }
}