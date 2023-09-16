using AutoMapper;
using Bp.Api.Data.Models;
using Bp.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace Bp.Api.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }

        public class AutoMapperMappingProfile : Profile
        {
            public AutoMapperMappingProfile()
            {
                CreateMap<Contact, ContactDVO>()
                    .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                    .ForMember(x=>x.Id, y=>y.MapFrom(z=>z.Id)) // bunu yazmasamda olurdur direkt defdaultta maplicekti zaten
                    .ReverseMap();

            }

        }
    }
}
