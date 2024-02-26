using Coffee.Memory;
using Сoffee;

namespace Coffee.Web
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            // будет корзина хранится в распределенной памяти, в классе мы можем обращаться к одной и той же памяти
            
            //services.AddSingleton<IProductRepository, ProductRepository>();
            //services.AddSingleton<ProductService>();
        }
        /*public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(x => x.MapControllers());
        }
        */
    }
    
}
