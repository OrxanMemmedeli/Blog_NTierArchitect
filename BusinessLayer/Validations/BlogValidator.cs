using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlıq hissəsi boş ola bilməz")
                .MinimumLength(2).WithMessage("Başlıq hissəsi ən az 2 simvol ola bilər")
                .MaximumLength(50).WithMessage("Başlıq hissəsi ən çox 50 simvol ola bilər");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Mətn hissəsi boş ola bilməz")
                .MinimumLength(10).WithMessage("Mətn hissəsi ən az 10 simvol ola bilər")
                .MaximumLength(1000).WithMessage("Mətn hissəsi ən çox 1000 simvol ola bilər");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Şəkil hissəsi boş ola bilməz");
        }
    }
}
