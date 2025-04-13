/*Burasi Session icerisinde classlari barindirmamizi saglayacaktir.*/
using System.Text.Json;
namespace StoreApp.Infrastructure.Extensions
{
    public static class SessionExtension /*Extensionlar static olarak tanimlanir.*/
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            /*this ISession session=Bu ifade mevcut bir ifadeyi genisletmek icin kullanilir.
            Ornegin burada ISession icerisine SetJson ekliyoruz.*/
            session.SetString(key, JsonSerializer.Serialize(value));
            /*Key-Value pair icin yukarida value kismini Serialize ederek eklendi.Herhangi bir object bu sekilde hafizada saklanir.*/
        }
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
            /*Bu generic metodu tanimlayarak type bagli bir islem yapabilecegimizi koda tanimladik.*/
        }
        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null
                ? default(T)
                : JsonSerializer.Deserialize<T>(data);
        }
    }
}
