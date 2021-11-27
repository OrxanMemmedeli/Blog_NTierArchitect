using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.SenderID)
                .NotEmpty().WithMessage("Email boş ola bilməz");            
            
            RuleFor(x => x.ReceiverID)
                .NotEmpty().WithMessage("Email boş ola bilməz");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Başlıq boş ola bilməz")
                .MinimumLength(5).WithMessage("Başlıq ən az 5 simvol ola bilər")
                .MaximumLength(50).WithMessage("Başlıq ən çox 50 simvol ola bilər");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Mesaj mətni boş ola bilməz")
                .MinimumLength(10).WithMessage("Mesaj mətni ən az 10 simvol ola bilər")
                .MaximumLength(500).WithMessage("Mesaj mətni ən çox 500 simvol ola bilər");
        }
    }
}
