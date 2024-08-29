using crudoperation.Interface;

namespace crudoperation.Services
{
    public class ServiceToScope
    {
        public ServiceToScope(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void AddToScope(IServiceCollection services)
        {
            services.AddTransient<Icrud, CrudService>(s => new CrudService(Configuration.GetSection("ConnectionStrings:ConnectionString1").Value));
        }
    }
}

