using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UsersWebApiService.DataAccessLayer;
using UsersWebApiService.DataAccessLayer.Implementations;
using UsersWebApiService.DataAccessLayer.Interfaces;
using UsersWebApiService.Services.Implementations;
using UsersWebApiService.Services.Interfaces;
using UsersWebApiService.DataLayer.Mappers;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using UsersWebApiService.Handlers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UsersWebApiService",
        Description = "—ервис по управлению пользовател€ми",
        Contact = new OpenApiContact
        {
            Name = "Artem Losev",
            Email = "laa-1028@mail.ru",
            Url = new Uri("https://github.com/LaHa1ne"),
        }
    });
    options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUser_groupRepository, User_groupRepository>();
builder.Services.AddTransient<IUser_stateRepository, User_stateRepository>();

builder.Services.AddTransient<IUsersService, UsersService>();

builder.Services.AddAutoMapper(
    typeof(CreatedUserDTOToUserMapperProfile),
    typeof(UserToUserDTOMapperProfile));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();



