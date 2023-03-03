using Microsoft.EntityFrameworkCore;
using RentRoomOfEquipment.Data.Contracts;
using RentRoomOfEquipment.Entity;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
        services.AddDbContext<ROEContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RentRoomOfEquipmentContextLocal")));

        RegisterServices(services);
    }

    private void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IRentRoomService, RentRoomService>();

        services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseSwagger();
         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentRoomOfEquipment"));

         app.UseRouting();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
    }
}
