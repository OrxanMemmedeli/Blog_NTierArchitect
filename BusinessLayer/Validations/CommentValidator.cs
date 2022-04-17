using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Mətn hissəsi boş ola bilməz")
                .MinimumLength(10).WithMessage("Mətn hissəsi ən az 10 simvol ola bilər")
                .MaximumLength(250).WithMessage("Mətn hissəsi ən çox 250 simvol ola bilər");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Ad və Soyadınız boş ola bilməz")
                .MinimumLength(5).WithMessage("Ad və Soyadınız ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Ad və Soyadınız ən çox 50 simvol ola bilər");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlıq boş ola bilməz")
                .MinimumLength(5).WithMessage("Başlıq ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Başlıq ən çox 50 simvol ola bilər");
        }
    }
}
