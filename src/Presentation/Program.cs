using PaymentGateway.Presentation.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.ConfigureAppSettings(builder.Configuration);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(opt =>
    {
        opt.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
    })
    .AddFluentValidators()
    .AddMongoDB()
    .AddAcquiringBank()
    .AddAplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
