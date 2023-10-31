using EntityLayer.Concrete; // Role sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidationRules
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı boş geçilemez!!!");
            RuleFor(x => x.RoleName).MinimumLength(1).WithMessage("Rol adı minimum 1 karakter olmalıdır!!!");
            RuleFor(x => x.RoleName).MaximumLength(20).WithMessage("Rol adı maksimum 20 karakter olmalıdır!!!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!!!");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Rol adı minimum 5 karakter olmalıdır!!!");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Rol adı maksimum 50 karakter olmalıdır!!!");
        }
    }
}
