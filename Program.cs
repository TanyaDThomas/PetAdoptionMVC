using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Services;
using PetAdoptionsMVC.Service;


namespace PetAdoptionMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<PetAdoptionDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            // Animal
            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddScoped<IAnimalQueryService, AnimalService>();

            //Adopter
            builder.Services.AddScoped<IAdopterService, AdopterService>();
            builder.Services.AddScoped<IAdopterQueryService, AdopterService>();

            //Adoption
            builder.Services.AddScoped<IAdoptionService, AdoptionService>();
            builder.Services.AddScoped<IAdoptionQueryService, AdoptionService>();

            //Note
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<INoteQueryService, NoteService>();

            //Payment
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentQueryService, PaymentService>();

            //Warning
            builder.Services.AddScoped<IWarningService, WarningService >();
            builder.Services.AddScoped<IWarningQueryServices, WarningService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
