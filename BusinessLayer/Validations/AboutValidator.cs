using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Validations
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.DetailsFirst)
                .NotEmpty().WithMessage("Haqqında mətninin ilk hissəsi boş ola bilməz")
                .MinimumLength(5).WithMessage("Haqqında mətninin ilk hissəsi ən az 5 simvol ola bilər")
                .MaximumLength(2500).WithMessage("Haqqında mətninin ilk hissəsi ən çox 2500 simvol ola bilər");            
            
            RuleFor(x => x.DetailsSecond)
                .MinimumLength(5).WithMessage("Haqqında mətninin ikinci hissəsi ən az 5 simvol ola bilər")
                .MaximumLength(10000).WithMessage("Haqqında mətninin ikinci hissəsi ən çox 10000 simvol ola bilər");            
                
            
            RuleFor(x => x.Map)
                .NotEmpty().WithMessage("Xəritə məlumatları boş ola bilməz");    
        }
    }
}
