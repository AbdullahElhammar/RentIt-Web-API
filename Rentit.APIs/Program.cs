
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rentit.BL;
using Rentit.DAL;
using System.Security.Claims;
using System.Text;

namespace Rentit.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string? connectionString = builder.Configuration.GetConnectionString("con1");

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddScoped<IPropertyRepo,PropertyRepo>();

            builder.Services.AddScoped<IPropertyManager,PropertyManager>();

            builder.Services.AddScoped<IRequestHostRepo, RequestHostRepo>();

            builder.Services.AddScoped<IRequestHostManger,RequestHostManager>(); 
            
            builder.Services.AddScoped<IRequestRentRepo, RequestRentRepo>();  
            
            builder.Services.AddScoped<IRequestRentManager, RequestRentManager>();  

            builder.Services.AddScoped<IClientManager, ClientManager>();    

            builder.Services.AddScoped<IClientRepo, ClientRepo>();

            builder.Services.AddScoped<IAttributeRepo, AttributeRepo>();    

            builder.Services.AddAuthorization(options =>
            {
                // awel policy feeh 2 claims aw 2 requirments kol policy w leeha el shroot bet3ta 
                options.AddPolicy("AdminRole", policy =>
                policy.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("UserRole", policy =>
                policy.RequireClaim(ClaimTypes.Role, "User"));

            });


            builder.Services.AddIdentity<Account, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                //2qsa mn keda han2fel el account beta3to lmodet 2 mins
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

            }).AddEntityFrameworkStores<MyContext>();
            //el mohskla dalw2ty b override N el authntication beta3k cookie authenictcation w e7na 3ayzeen token 

            builder.Services.AddDbContext<MyContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("con1")));
            

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "default";
                //challenge m3naha neo hayrg3lo un authrozied laken the cookie btrg3lo page 
                //ya3ni seeebo zy mhwa w adeelo 401
                options.DefaultChallengeScheme = "default";
            })
            .AddJwtBearer("default", options =>
            {
                var secertKey = builder.Configuration.GetValue<string>("Secertkey");
                var secertKeyInBytes = Encoding.ASCII.GetBytes(secertKey);
                var key = new SymmetricSecurityKey(secertKeyInBytes);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
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

            app.UseCors();


            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
