using System.Reflection;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Server;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<EduEDiaryContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        var clientAddresses = builder.Configuration.GetSection("ClientAddresses").Get<Dictionary<string, string>>();
        if (clientAddresses == null || !clientAddresses.Any())
        {
            throw new Exception("'ClientAddresses' is not found in appsettings.json.");
        }
        policy.WithOrigins(clientAddresses.Values.ToArray())
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddTransient<IRepository<Student>, StudentRepository>();
builder.Services.AddTransient<IRepository<Subject>, SubjectRepository>();
builder.Services.AddTransient<IRepository<Class>, ClassRepository>();
builder.Services.AddTransient<IRepository<Grade>, GradeRepository>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors("AllowReactApp");
app.Run();