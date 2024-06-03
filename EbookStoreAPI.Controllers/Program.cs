using EbookStoreAPI.DAL.AutoMapper;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DAL.Repositories;
using EbookStoreAPI.DBConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using EUserStoreAPI.DAL.Repositories;
using EbookStoreAPI.Services.Authentication.Interfaces;
using EbookStoreAPI.Services.Authentication.Repository;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Repository;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(BookMappingProfile));

// Add DALS.
builder.Services.AddScoped<IBookDAL, BookDAL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IRoleDAL, RoleDAL>();
builder.Services.AddScoped<IShoppingCartDAL, ShoppingCartDAL>();
builder.Services.AddScoped<IShoppingCartDetailDAL, ShoppingCartDetailDAL>();
builder.Services.AddScoped<ISaleDAL, SaleDAL>();
builder.Services.AddScoped<ISaleDetailDAL, SaleDetailDAL>();


// Add Services
builder.Services.AddScoped<ITokenManagerService, TokenManagerService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShopCartService, ShopCartService>();
builder.Services.AddScoped<ISaleService, SaleService>();



builder.Services.AddScoped<ShopCartService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Costumer Swagger
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "EbokStoreAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});

//For Database EntityFramework
builder.Services.AddDbContext<EbookStoreDbContext>(options =>
{
    options
        .UseSqlServer(configuration.GetConnectionString("EBOOK_CONN"))
        .UseLazyLoadingProxies(true)
        .LogTo(s => System.Console.WriteLine(s));
});

//For Authentication
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
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

var app = builder.Build();

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader());


// Configure the HTTP request pipeline.
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
