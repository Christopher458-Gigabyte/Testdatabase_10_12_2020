using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testdatabase_10_12_2020.Data;

namespace Testdatabase_10_12_2020
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
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

    //        services.AddIdentityCore<IdentityRole>()
    //.AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapRazorPages();
            });
        }


        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var SignInManager = serviceProvider.GetRequiredService<SignInManager<IdentityUser>>();

            IdentityResult roleResult;
            IdentityResult roleResult2;
            //here in this line we are adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            var roleCheck2 = await RoleManager.RoleExistsAsync("Manager");
            if (!roleCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));

            }
            if (!roleCheck2)
            {
                //here in this line we are creating admin role and seed it to the database

                roleResult2 = await RoleManager.CreateAsync(new IdentityRole("Manager"));
            }
            //here we are assigning the Admin role to the User that we have registered above 
            //Now, we are assinging admin role to this user("Ali@gmail.com"). When will we run this project then it will
            //be assigned to that user.
            IdentityUser user = await UserManager.FindByEmailAsync("ad@outlook.de");
            IdentityUser user2 = await UserManager.FindByEmailAsync("man@outlook.de");
            var User = new IdentityUser();
            var User2 = new IdentityUser();
            await UserManager.AddToRoleAsync(user, "Admin");
            await UserManager.AddToRoleAsync(user2, "Manager");
            await UserManager.AddToRoleAsync(user, "Manager");
        }



    }
}
