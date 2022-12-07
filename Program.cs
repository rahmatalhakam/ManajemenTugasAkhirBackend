using System.Text;
using FluentValidation;
using ManajemenTugasAkhirGeologi.Commons.Models;
using ManajemenTugasAkhirGeologi.Extensions;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Services.Implementations;
using ManajemenTugasAkhirGeologi.GraphQL.Authorizations.Services.Interfaces;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Services.Implementations;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Services.Interfaces;
using ManajemenTugasAkhirGeologi.GraphQL.Students.Validators;
using ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Implementations;
using ManajemenTugasAkhirGeologi.GraphQL.Users.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

var connString = env.IsProduction() ? "Production" : "Development";
builder.Services.AddDbContext<AppDbContext>
    (opt => opt.UseMySql(configuration.GetConnectionString(connString)!, new MySqlServerVersion(new Version(8, 0, 31))));

builder.Services.AddValidatorsFromAssemblyContaining<StudentInputValidator>();

builder.Services.AddGraphQLService();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
    };
}); ;

builder.Services.AddTransient<DbInitializer>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddControllers();

var app = builder.Build();
await SeedDatabaseAsync();

app.MapGraphQL();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

async Task SeedDatabaseAsync()
{
    using (var scope = app!.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
        await dbInitializer.Initialize();
    }
}