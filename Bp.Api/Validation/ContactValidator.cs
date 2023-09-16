using Bp.Api.Data.Models;
using FluentValidation;

namespace Bp.Api.Validation
{
    public class ContactValidator :AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Id).LessThan(100).WithMessage("id 100 den büyük olamaz."); //Onun id sini kontrol et 100 den büyükse hata ver ve bu mesajı göster demek.

            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim Soyisim boş bırakılamaz.");




        }


    }
}
