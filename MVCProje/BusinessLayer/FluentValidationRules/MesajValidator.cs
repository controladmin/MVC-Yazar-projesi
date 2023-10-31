using EntityLayer.Concrete; // Mesaj sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class MesajValidator : AbstractValidator<Mesaj>
    {
        public MesajValidator()
        {
            //RuleFor(x => x.GondericiMail).NotEmpty().WithMessage("Gönderici maili boş geçilemez!!!");
            //RuleFor(x => x.GondericiMail).EmailAddress().WithMessage("Geçerli bir mail adresi girmelisiniz!!!");
            RuleFor(x => x.AliciMail).NotEmpty().WithMessage("Alıcı maili boş geçilemez!!!");
            RuleFor(x => x.AliciMail).EmailAddress().WithMessage("Geçerli bir mail adresi girmelisiniz!!!");
            RuleFor(x => x.Konu).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz!!!");
            RuleFor(x => x.Konu).MinimumLength(5).WithMessage("Konu alanı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.Konu).MaximumLength(50).WithMessage("Konu alanı en fazla 50 karakter olmalıdır!!!");
            RuleFor(x => x.MesajKonusu).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!!!");
            RuleFor(x => x.MesajKonusu).MinimumLength(5).WithMessage("Konu alanı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.MesajKonusu).MaximumLength(1000).WithMessage("Konu alanı en fazla 1000 karakter olmalıdır!!!");
        }
    }
}
