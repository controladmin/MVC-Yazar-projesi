using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete; // Content sınıfını kullanabilmek için ekledik


namespace BusinessLayer.FluentValidationRules
{
    public class ContentValidator : AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(x => x.ContentValue).NotEmpty().WithMessage("İçerik alanı boş geçilemez!!!");
            RuleFor(x => x.ContentValue).MinimumLength(5).WithMessage("İçerik alanı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.ContentValue).MaximumLength(500).WithMessage("İçerik alanı en fazla 500 karakter olmalıdır!!!");
        }
    }
}
