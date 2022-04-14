using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kateqoriya boş ola bilməz")
                .MinimumLength(5).WithMessage("Kateqoriya ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Kateqoriya ən çox 50 simvol ola bilər");

            RuleFor(x => x.Desctiption)
                .NotEmpty().WithMessage("Açıqlama mətni boş ola bilməz")
                .MinimumLength(5).WithMessage("Açıqlama mətni ən az 5 simvol ola bilər")
                .MaximumLength(250).WithMessage("Açıqlama mətni ən çox 250 simvol ola bilər");
        }
    }
}
