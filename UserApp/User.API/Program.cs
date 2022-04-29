using User.API;
using User.API.Middleware;
using User.Domain;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
ServiceProvider? provider      = builder.Services.BuildServiceProvider();
IConfiguration?  configuration = provider.GetService<IConfiguration>();
Configuration.connectionString = configuration.GetValue<string>("ConnectionStrings:default");

builder.Services.AddApplication();

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true
);


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseSimulatedLatency(
        TimeSpan.FromMilliseconds(100),
        TimeSpan.FromMilliseconds(300)
    );
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();