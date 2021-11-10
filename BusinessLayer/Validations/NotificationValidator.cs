using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Bildiriş tipi boş ola bilməz")
                .MinimumLength(2).WithMessage("Bildiriş tipi ən az 2 simvol ola bilər")
                .MaximumLength(20).WithMessage("Bildiriş tipi ən çox 20 simvol ola bilər");

            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Simvol class-ı boş ola bilməz");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Bildiriş mətni boş ola bilməz")
                .MinimumLength(2).WithMessage("Bildiriş mətni ən az 2 simvol ola bilər")
                .MaximumLength(50).WithMessage("Bildiriş mətni ən çox 50 simvol ola bilər");

            RuleFor(x => x.Color)
                .NotEmpty().WithMessage("Bildiriş rəngi boş ola bilməz");

            RuleFor(x => x.NotificationDate)
                .NotEmpty().WithMessage("Bildiriş tarixi boş ola bilməz");
        }
    }
}
