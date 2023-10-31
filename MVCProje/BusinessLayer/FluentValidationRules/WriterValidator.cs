using EntityLayer.Concrete; // Writer sınıfını kullanabilmek için ekledik
using FluentValidation;  // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // Regex sınıfını kullanabilmek için ekledik
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez!!!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez!!!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail alanı boş geçilemez!!!");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir mail adresi girmelisiniz!!!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında alanını boş geçemezsiniz!!!");
            RuleFor(x => x.WriterAbout).MinimumLength(5).WithMessage("En az 5 karakter girmelisiniz!!!");
            RuleFor(x => x.WriterAbout).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!!!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez!!!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan alanı boş geçilemez!!!");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Ünvan alanı en az 3 karakter olmalıdır!!! ");
            RuleFor(x => x.WriterTitle).MaximumLength(30).WithMessage("Ünvan alanı en fazla 30 karakter olabilir!!!");

            /* hakkında içeriğinde en bir a harfi geçmesi için ekledik*/
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında içeriğinde en bir tane a harfi geçmelidir!!!");
            bool IsAboutValid(string arg)
            {
                try
                {
                    Regex regex = new Regex(@"^(?=.*[a,A])");
                    return regex.IsMatch(arg);
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }
    }
}
