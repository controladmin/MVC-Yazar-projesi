using EntityLayer.Concrete; // Category sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {

        /* Bu yazılan validator kurllarını CategoryController kısmında kullanıyoruz*/
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez!!!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!!!");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("En az 5 karakter girmelisiniz!!!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!!!");
            RuleFor(x => x.CategoryDescription).MaximumLength(500).WithMessage("En fazla 500 karakter girebilirsiniz!!!");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("En az 5 karakter girmelisiniz!!!");

        }
    }
}
