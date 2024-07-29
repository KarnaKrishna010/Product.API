using Product.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var MyAllowedSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("cnn");
Product.Repository.Configure.ConfigureServices(builder.Services, connectionString);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For Cors Policy
builder.Services.ConfigureCors(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors(MyAllowedSpecificOrigins);

app.MapControllers();

app.Run();
