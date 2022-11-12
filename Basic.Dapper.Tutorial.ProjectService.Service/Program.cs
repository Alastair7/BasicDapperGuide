using Autofac;
using Autofac.Configuration;
using Basic.Dapper.Tutorial.ProjectService.Repository.MemberRepository;
using Basic.Dapper.Tutorial.ProjectService.Repository.ProjectRepository;
using Basic.Dapper.Tutorial.ProjectServices.Business.MemberService;
using Basic.Dapper.Tutorial.ProjectServices.Business.ProjectService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("Config/autofac.json");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
