using EntityLayer.Concrete; // Admin sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!!!");
            RuleFor(x => x.AdminUserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır!!!");
            RuleFor(x => x.AdminUserName).MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olmalıdır!!!");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez!!!");
            RuleFor(x => x.AdminPassword).MinimumLength(3).WithMessage("Şifre en az 3 karakter olmalıdır!!!");
            RuleFor(x => x.AdminPassword).MaximumLength(50).WithMessage("Şifre en fazla 50 karakter olmalıdır!!!");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role seçimi yapmadınız!!!");
            RuleFor(x => x.AdminMail).NotEmpty().WithMessage("Mail adresi boş geçilemez!!!");
            RuleFor(x => x.AdminMail).EmailAddress().WithMessage("Geçerli bir mail adresi girmelisiniz!!!");

        }
    }
}
