using Manage.Place.Data.ContextConfig;
using Manage.Place.Data.Repositories;
using Manage.Place.Domain.Events;
using Manage.Place.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Manage.Place.CrossCutting.Ioc
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<DbContext, DataContext>();

            services.AddDbContext<DbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPlaceRepository, PlaceRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

        }
    }
}
