using Bp.Api.Data.Models;
using Bp.Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;

        public ContactController(IConfiguration Configuration, IContactService contactService)
        {
            configuration = Configuration;
            this.contactService = contactService;
        }

        [HttpGet]
        public string Get()
        {
            return configuration["README"].ToString();
        }

        [ResponseCache(Duration = 10)] //ilk istek geldiğinde bu method çalışacak ve cache te tutulacak. 10 sn boyunca da cache den cevap verecek. Burada cache in çalışması için methoda gelen parametrenin aynı olması lazım fakrlı olursa yeni bir data olacağı için cache ten cevap verilmez.
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contactService.GetContactById(id);

        }

        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contactDVO)
        {
            return contactDVO;

        }
    }
}

/*
 
Bu Solution da olan konular ; 
 
1 - Proje Yapısı
2 - Ortam'a bağlı ayarlar
3 - Uygulama Sağlık Durumu
4 - Model Dönüşümleri
5 - Doğrulama ve Kontrol Mekanizmaları
6 - Cevap Belleği
7 - Harici Serviskeri Çağırmada Performans
8 - İleri Seviyede Merkezi Log Sistemi
9 - Arka Plan Servisleri
10 - Domain Design
11 - Configurations
12 - HealthCheck
13 - Mapping
14 - Validation
15 - ResponseCaching
16 - IHttpClientFactory
17 - Logging With Serilog
18 - Hosted Services with backgrounService







 */