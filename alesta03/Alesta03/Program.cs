global using Alesta03.Model;
global using Alesta03.Data;
using Alesta03.Services.CompanyServices.ProfileService;
using Alesta03.Services.GeneralService;
using Alesta03.Services.PersonServices.ExpReviewService;
using Alesta03.Services.PersonServices.InfoService;
using Alesta03.Services.PersonServices.ProfileService;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Alesta03.Services.AdvertApprovalService;
using Alesta03.Services.AdvertService;
using Alesta03.Services.PostServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IExpReviewService, ExpReviewService>();
//builder.Services.AddScoped<ICProfileService, CProfileService>();
builder.Services.AddScoped<IPProfileService, PProfileService>();
builder.Services.AddScoped<IPersonInfoWorkService, PersonInfoWorkService>();
builder.Services.AddScoped<IPersonInfoEduService, PersonInfoEduService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPostService, PostService>();    
builder.Services.AddScoped<IAdvertService, AdvertService>();
builder.Services.AddScoped<IAdvertApprovalService, AdvertApprovalService>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


//builder.Services.AddDbContext<DataContext>(options =>
//        options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStrings:Connection")));

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        builder.Configuration.GetSection("AppSettings:Token").Value!))

    };
});

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

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.Run();
