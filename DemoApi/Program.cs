using DemoApi.Context;
using DemoApi.Services.AuthService;
using DemoApi.Services.Login;
using DemoApi.Services.Page;
using DemoApi.Services.Role;
using DemoApi.Services.Student;
using DemoApi.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register custom services
builder.Services.AddSingleton<DapperConnection>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPageService,PageService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IPermissonUserService,PermissonUserService>();

// Add Authorization
builder.Services.AddAuthorization();

// Load JWT settings from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json",optional: false,reloadOnChange: true);

var jwtSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
    };
});

// Configure Swagger for JWT authentication
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo
    {
        Version = "v1",
        Title = "Demo API",
        Description = "A simple example for swagger api information",
    });
    c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

});

var allowedOrigins = new string[] {
    "http://localhost:3000",
    "http://localhost:4200",
    "http://localhost:7223"
};


// Build the application
var app = builder.Build();

// Enable middleware
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json","API v1");
});

app.UseCors(builder =>
{
    builder.WithOrigins(allowedOrigins)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
           .WithMethods("GET","POST","OPTIONS");
});
app.UseHttpsRedirection();
app.UseRouting();

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
