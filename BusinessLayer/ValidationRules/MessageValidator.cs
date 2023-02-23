using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini Boş Geçemezsiniz.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("HATALI MAİL");
            RuleFor(x => x.subject).NotEmpty().WithMessage("Konuyu Boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş geçemezsiniz");
            RuleFor(x => x.subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.subject).MaximumLength(100).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız.");

        }
    }
}
