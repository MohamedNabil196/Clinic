using BackEnd.IRepo;
using BackEnd.IService;
using BackEnd.Mongo.IMongo;
using BackEnd.Mongo.MongoService;
using BackEnd.Repo;
using BackEnd.Services;
using Exam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
#region DatabaseCreation
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion
#region

builder.Services.Configure<StudentStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettings)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("StudentStoreDatabaseSettings:ConnectionString")));

#endregion
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRecordService, RecordService>();

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
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
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
