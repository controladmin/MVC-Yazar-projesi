using EntityLayer.Concrete; // Heading sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
   public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık adı boş geçilemez!!!");
            RuleFor(x => x.HeadingName).MinimumLength(5).WithMessage("Başlık adı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Başlık adı en fazla 50 karakter olmalıdır!!!");
        }
    }
}
