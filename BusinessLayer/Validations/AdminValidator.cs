using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad-Soyad hissəsi boş ola bilməz")
                .MinimumLength(2).WithMessage("Ad-Soyad hissəsi ən az 2 simvol ola bilər")
                .MaximumLength(50).WithMessage("Ad-Soyad hissəsi ən çox 50 simvol ola bilər");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("İstifadəçi adı hissəsi boş ola bilməz")
                .MinimumLength(2).WithMessage("İstifadəçi adı hissəsi ən az 2 simvol ola bilər")
                .MaximumLength(50).WithMessage("İstifadəçi adı hissəsi ən çox 50 simvol ola bilər");
            RuleFor(x => x.About)
                .MinimumLength(2).WithMessage("Haqqında hissəsi ən az 2 simvol ola bilər")
                .MaximumLength(250).WithMessage("Haqqında hissəsi ən çox 250 simvol ola bilər");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email hissəsi boş ola bilməz")
                .EmailAddress().WithMessage("Email düzgün yazılmamışdır");
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Istifadəçi səlahiyyəti hissəsi boş ola bilməz");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz")
                .MinimumLength(6).WithMessage("Şifrə minimum 6 simvol ola bilər. (nümunə Aa123!!)")
                .MaximumLength(20).WithMessage("Şifrə maksimum 20 simvol ola bilər. (nümunə Aa123!!)")
                .Matches("[A-Z]").WithMessage("Şifrədə ən azı 1 BÖYÜK simvol olmalıdır (nümunə Aa123!!)")
                .Matches("[a-z]").WithMessage("Şifrədə ən azı 1 KİÇİK simvol olmalıdır (nümunə Aa123!!)")
                .Matches("[0-9]").WithMessage("Şifrədə ən azı 1 RƏQƏM olmalıdır (nümunə Aa123!!)")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifrədə xüsusi simvollar olmalıdır. (nümunə Aa123!!)");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifrənin təkrarı boş ola bilməz")
                .MinimumLength(6).WithMessage("Şifrə minimum 6 simvol ola bilər. (nümunə Aa123!!)")
                .MaximumLength(20).WithMessage("Şifrə maksimum 20 simvol ola bilər. (nümunə Aa123!!)");

            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword).WithMessage("Şifrə ilə təkrarı arasında uyğunsuzluq var.")
                .When(x => !String.IsNullOrWhiteSpace(x.Password)).WithMessage("Şifrə ilə təkrarı arasında uyğunsuzluq var.");

        }
    }
}
