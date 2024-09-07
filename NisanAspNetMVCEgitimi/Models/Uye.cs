using System.ComponentModel.DataAnnotations; // Model validation için gerekli kütüphane

namespace NisanAspNetMVCEgitimi.Models
{
    public class Uye
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez!"), StringLength(50)] // Required bu alanı zorunlu kılar, ErrorMessage hata mesajını özelleştirir. StringLength(50) ise bu alana en fazla 50 karakter girilmesine izin verir.
        public string Ad { get; set; }
        [Required(ErrorMessage = "{0} alanı boş geçilemez!"), StringLength(50)] // {0} yazan yere dinamik olarak property adı (Soyad) getirilir.
        public string Soyad { get; set; }
        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi!"), StringLength(50)] // Aşağıdaki alana email adresi türünde veri girilebilsin
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Geçersiz Telefon Formatı!")]
        public string? Telefon { get; set; }
        [Display(Name = "TC Kimlik Numarası"), StringLength(11)] // Ekranda TcKimlikNo yerine TC Kimlik Numarası yazısı yazsın
        [MinLength(11, ErrorMessage = "{0} 11 Karakter Olmalıdır!")]
        [MaxLength(11, ErrorMessage = "{0} 11 Karakter Olmalıdır!")]
        public string? TcKimlikNo { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? KullaniciAdi { get; set; }
        [Display(Name = "Şifre")]
        [StringLength(15, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 5)]
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string? Sifre { get; set; }
        [Display(Name = "Şifreyi Tekrar Giriniz")]
        [StringLength(15, ErrorMessage = "{0} {2} Karakterden Az Olamaz!", MinimumLength = 5)]
        [Compare("Sifre")] // Sifre property si ile karşılaştır
        public string? SifreTekrar { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
    }
}
