using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EwaveLivraria.Data.IoC;
using EwaveLivraria.Services.IoC;
using EwaveLivraria.Services.Settings;

namespace EwaveLivraria.API.IoC
{
    public static class ApplicationInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new ServicesMapperProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            RepositoriesInjector.RegisterServices(services);
            ServicesInjector.RegisterServices(services);

            var key = Encoding.ASCII.GetBytes(SecuritySettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}