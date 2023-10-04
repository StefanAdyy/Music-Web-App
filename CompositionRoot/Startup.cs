using BusinessLogic;
using BusinessLogic.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompositionRoot
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
            services.AddSingleton<IArtistBL, ArtistBL>();
            services.AddSingleton<IArtistDataAccess, ArtistDataAccess>();
            services.AddSingleton<INationalityBL, NationalityBL>();
            services.AddSingleton<INationalityDataAccess, NationalityDataAccess>();
            services.AddSingleton<IAlbumArtistBL, AlbumArtistBL>();
            services.AddSingleton<IAlbumArtistDataAccess, AlbumArtistDataAccess>();
            services.AddSingleton<IAlbumBL, AlbumBL>();
            services.AddSingleton<IAlbumDataAccess, AlbumDataAccess>();
            services.AddSingleton<IAlbumSongBL, AlbumSongBL>();
            services.AddSingleton<IAlbumSongDataAccess, AlbumSongDataAccess>();
            services.AddSingleton<IMusicGenreBL, MusicGenreBL>();
            services.AddSingleton<IMusicGenreDataAccess, MusicGenreDataAccess>();
            services.AddSingleton<ISongBL, SongBL>();
            services.AddSingleton<ISongDataAccess, SongDataAccess>();
            services.AddSingleton<ISongArtistBL, SongArtistBL>();
            services.AddSingleton<ISongArtistDataAccess, SongArtistDataAccess>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompositionRoot", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompositionRoot v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
