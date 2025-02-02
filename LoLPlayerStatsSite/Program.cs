using LoLPlayerStatsSite.Components;
using LoLPlayerStatsSite.Db.AppDbContext;
using LoLPlayerStatsSite.Mapper;
using LoLPlayerStatsSite.RiotAPI;
using LoLPlayerStatsSite.Service;
using LoLPlayerStatsSite.Services;
using Microsoft.EntityFrameworkCore;
using Radzen;

namespace LoLPlayerStatsSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Connection to Db
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")), ServiceLifetime.Transient
            );

            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Add logging
            builder.Services.AddLogging();

            // Add services
            builder.Services.AddScoped<IChampionRatingService, ChampionRatingService>();
            builder.Services.AddScoped<IPlayerStatsService, PlayerStatsService>();
            builder.Services.AddTransient<IRiotAPIProvider, RiotAPIProvider>();

            builder.Services.AddHttpClient<IRiotAPIProvider, RiotAPIProvider>(client =>
            {
                var baseAddress = builder.Configuration.GetSection("RiotAPIkey")["BaseAddress"];
                var apiKey = builder.Configuration.GetSection("RiotAPIkey")["API-key"];

                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("X-Riot-API-Key", apiKey);
            });

            builder.Services.AddRadzenComponents();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
