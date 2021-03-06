using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Gestao_de_Projetos.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gestao_de_Projetos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {      
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
           // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //  .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<Gestao_de_ProjetosContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("Gestao_de_ProjetosContext")));

            services.AddIdentity<IdentityUser, IdentityRole>(
                 options => {
                    // Sign in
                    options.SignIn.RequireConfirmedAccount = false;
                     options.SignIn.RequireConfirmedPhoneNumber = false;
                     options.SignIn.RequireConfirmedEmail = false;

                    // Password
                    options.Password.RequireUppercase = true;
                     options.Password.RequireLowercase = true;
                     options.Password.RequireDigit = true;
                     options.Password.RequireNonAlphanumeric = true;
                     options.Password.RequiredUniqueChars = 4;
                     options.Password.RequiredLength = 8;

                    // User
                    options.User.RequireUniqueEmail = true;

                    // Lockout
                    options.Lockout.AllowedForNewUsers = true;
                 })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();

            services.AddControllersWithViews();

            services.AddAuthorization(options => {
                options.AddPolicy("OnlyAdminAccess",
                policy => policy.RequireRole("Gestor"));
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Gestao_de_ProjetosContext bd, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            RolesConfig.CreateRolesAndUsers(userManager, roleManager).Wait();
            if (env.IsDevelopment())
            {
                //RolesConfig.CreateTestUsersAsync(userManager, roleManager).Wait();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                SeedDataDadosFIT.Populate(bd);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
