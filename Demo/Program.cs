using Demo.Data;
using Demo.Helpers;
using Demo.Repositories;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<Datacontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection"));
});

builder.Services.Configure<AzureBlobSettings>(builder.Configuration.GetSection("AzureBlobStorage"));

builder.Services.AddScoped<AzureBlobService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAudioRepository, AudioRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
//        c.RoutePrefix = string.Empty;
//    });
//}

app.UseHttpsRedirection();
app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();



app.Run();
