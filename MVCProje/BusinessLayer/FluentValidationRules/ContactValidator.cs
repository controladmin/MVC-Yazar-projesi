using EntityLayer.Concrete; // COntact sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail alanı boş geçilemez!!!");
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Geçerli bir mail adresi girmelisiniz!!!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!!!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alanı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu alanı en fazla 50 karakter olmalıdır!!!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!!!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır!!!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!!!");
            RuleFor(x => x.Message).MinimumLength(5).WithMessage("Mesaj alanı ez az 5 karakter olmalıdır!!!");
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage("Mesaj alanı en fazla 1000 karakter olmalıdır!!!");
        }
    }
}
