using EntityLayer.Concrete; // About sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!!!");
            RuleFor(x => x.AboutDetails1).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.AboutDetails1).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olmalıdır!!!");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!!!");
            RuleFor(x => x.AboutDetails2).MinimumLength(5).WithMessage("Açıklama alanı en az 5 karakter olmalıdır!!!");
            RuleFor(x => x.AboutDetails2).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olmalıdır!!!");
            //RuleFor(x => x.AboutImage).NotEmpty().WithMessage("Resim alanı boş geçilemez!!!");
        }
    }
}
