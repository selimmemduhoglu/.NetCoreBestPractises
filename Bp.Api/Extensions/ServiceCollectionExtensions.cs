using Bp.Api.Data.Models;
using Bp.Api.Service;
using Bp.Api.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bp.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();

            services.AddTransient<IValidator<ContactDVO>,ContactValidator>(); // Transient kullanmak zorundaydık çünkü birden fazla FluentValidator için aynı anda işlem yapması gerekecekt.

            return services;
        }


    }
}
