using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Api_Pedidos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api_Pedidos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration {get;}

        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllers();

            var keyByte = Encoding.ASCII.GetBytes("UmTokenGrandeEDiferente");

            services.AddAuthentication(options =>{
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>{
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyByte),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            services.AddEndpointsApiExplorer();

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDTarefas"));
            services.AddTransient<IProduto, ProdutoRepository>();
            services.AddTransient<IPedido, PedidoRepository>();
            services.AddTransient<IEmpresa, EmpresaRepository>();
            services.AddTransient<IUsuario, UsuarioRepository>();
            services.AddTransient<ICliente, ClienteRepository>();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}