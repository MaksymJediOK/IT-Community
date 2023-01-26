using IT_Community.Server.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IT_Community.Server.Infrastructure.Services;
using IT_Community.Server.Core.GenericRepository;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Infrastructure.Helpers;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ITCommunityConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IGenericRepository<Post>, GenericRepository<Post>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPostsService, PostsService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SecurityRequirementsOperationFilter>();

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "IT-Community API",
        Description = "API for IT-Community WebApp",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Email = "IT-Community@gmail.com",
            Name = "XXXXXX"
        }
    });
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
/*
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();
*/

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

app.UseAuthorization();

app.MapControllers();

app.Run();
