using Blog_NTierArchitect.Areas.Writer.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Areas.Writer.Models.ViewModelValidators
{
    public class WriterDataUpdateValidator : AbstractValidator<WriterDataUpdate>
    {
        public WriterDataUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad-Soyad hissəsi boş ola bilməz")
                .MinimumLength(2).WithMessage("Ad-Soyad hissəsi ən az 2 simvol ola bilər")
                .MaximumLength(50).WithMessage("Ad-Soyad hissəsi ən çox 50 simvol ola bilər");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email hissəsi boş ola bilməz")
                .EmailAddress().WithMessage("Email düzgün yazılmamışdır");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifrənin təkrarı boş ola bilməz");

            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword).WithMessage("Şifrə ilə təkrarı arasında uyğunsuzluq var.")
                .When(x => !String.IsNullOrWhiteSpace(x.Password)).WithMessage("Şifrə ilə təkrarı arasında uyğunsuzluq var.");

            RuleFor(x => x.About)
                .MinimumLength(10).WithMessage("Haqqında hissəsi ən az 10 simvol ola bilər");
        }
    }
}
