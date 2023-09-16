using AutoMapper;
using Bp.Api.Data.Models;
using Bp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bp.Api.Service
{
    public class ContactService : IContactService
    {
        public IMapper mapper { get; }
        public IHttpClientFactory httpClientFactory { get; }

        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }



        public  ContactDVO GetContactById(int Id)
        { // Veri tabanından kaydın getirilmesi işlemi yapılacak.


            Contact dbContact = getDummyContact();

            var client = httpClientFactory.CreateClient("garantiapi");


            ContactDVO resultContact = mapper.Map<ContactDVO>(dbContact); 
            return resultContact;

        }




        private Contact getDummyContact()
        {
            var _contact1 = new Contact()
            {
                Id = 1,
                FirstName = "Salih",
                LastName = "Cantekin"
            };

            return _contact1;

        }

    }
}
