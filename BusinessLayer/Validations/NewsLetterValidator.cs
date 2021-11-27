using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class NewsLetterValidator : AbstractValidator<NewsLetter>
    {
        public NewsLetterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email adresi düzgün daxil edilməyib")
                .MinimumLength(5).WithMessage("Email ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Email ən çox 50 simvol ola bilər");
        }
    }
}
