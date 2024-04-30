namespace Bookshelf
{
    /// <summary>
    /// Configures many parts of program like mvc and http request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor which injects configuration.
        /// </summary>
        /// <param name="configuration">Injected configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Injected configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Add services to the container.
        /// </summary>
        /// <param name="services">Services to add.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // Add any additional services your application needs
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="env">Web host environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add production error handling middleware
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Add a route for the post-login controller
                endpoints.MapControllerRoute(
                    name: "account",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
