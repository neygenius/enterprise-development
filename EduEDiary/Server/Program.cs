using System.Reflection;
using EduEDiary.Domain;
using EduEDiary.Domain.Repositories;
using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddSingleton<IRepository<Student>, StudentRepository>();
builder.Services.AddSingleton<IRepository<Subject>, SubjectRepository>();
builder.Services.AddSingleton<IRepository<Class>, ClassRepository>();
builder.Services.AddSingleton<IRepository<Grade>, GradeRepository>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();