
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        //Doğrulayıcılar (validators), form verisi (metin kutularına girilenler vb.)
        //sunucuya gitmeden önce verilerin kontrol edilmesi için kullanılır.
        //Bu şekilde hatalı verilerin sunucuya gelmeden değiştirilmesi sağlanarak
        //hem güvenlik, hem de sunucuda yapılacak işler ve
        //zaman açısından tasarruf sağlanır.
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız.");


        }
    }
}
