using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator: AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz!");
            RuleFor(x => x.Range).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz!");
            RuleFor(x => x.SkillName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın!");
            RuleFor(x => x.Range).LessThan(101).WithMessage("100'ün üzerinde sayı giremezsiniz!");
        }
    }
}
