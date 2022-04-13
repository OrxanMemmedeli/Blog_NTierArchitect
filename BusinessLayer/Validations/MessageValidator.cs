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
                .NotEmpty().WithMessage("Göndərənin adresi boş ola bilməz");            
            
            RuleFor(x => x.ReceiverID)
                .NotEmpty().WithMessage("Alıcının adresi boş ola bilməz")
                .NotEqual(x => x.SenderID).WithMessage("Göndərən və alıcı eyni şəxs ola bilməz");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Başlıq boş ola bilməz")
                .MinimumLength(5).WithMessage("Başlıq ən az 5 simvol ola bilər")
                .MaximumLength(100).WithMessage("Başlıq ən çox 100 simvol ola bilər");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Mesaj mətni boş ola bilməz")
                .MinimumLength(10).WithMessage("Mesaj mətni ən az 10 simvol ola bilər")
                .MaximumLength(5000).WithMessage("Mesaj mətni ən çox 5000 simvol ola bilər");
        }
    }
}
