using System.Text.Json; // json işlemleri için gerekli kütüphane

namespace NisanAspNetMVCEgitimi.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value) // static classlarda static işaretli metot kullanıyoruz!
        {
            // this ISession session bölümü .net in session yapısını kullanarak genişletme yapacağız anlamına geliyor
            session.SetString(key, JsonSerializer.Serialize(value)); // Burada uygulamadaki session yapısına key ile belirlenen isimde object olarak her türlü veriyi alıp JsonSerializer.Serialize metoduyla nesneyi json tipine çevirip session da saklıyoruz.
        }
        public static T? GetJson<T>(this ISession session, string key) where T : class // Burada getjson metodu dışarıdan alacağı key deki session a ulaşıp içindeki datayı JsonSerializer.Deserialize metoduyla json dan nesneye çeviriyor. where T : class bölümü ise T nesnesinin class tipinde olması şartını bildiriyor.
        {
            var data = session.GetString(key);
            return data == null ? default : JsonSerializer.Deserialize<T>(data);
        }
    }
}
