using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Ad və Soyadınız boş ola bilməz")
                .MinimumLength(10).WithMessage("Ad və Soyadınız ən az 10 simvol ola bilər")
                .MaximumLength(50).WithMessage("Ad və Soyadınız ən çox 50 simvol ola bilər");          

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email adresi düzgün daxil edilməyib")
                .MinimumLength(5).WithMessage("Email ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Email ən çox 50 simvol ola bilər");           
            
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Başlıq boş ola bilməz")
                .MinimumLength(5).WithMessage("Başlıq ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Başlıq ən çox 50 simvol ola bilər");               
            
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj mətni boş ola bilməz")
                .MinimumLength(10).WithMessage("Mesaj mətni ən az 10 simvol ola bilər")
                .MaximumLength(500).WithMessage("Mesaj mətni ən çox 500 simvol ola bilər");   
        }
    }
}
