namespace StoreApp.Infrastructure.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue//Gelen ifadenin bir QueryString var mi?Kontrol et.
                ? $"{request.Path}{request.QueryString}"//Var ise Path ve query string ifadesini don
                : request.Path.ToString();//yok ise sadece path don.
        }
    }
}
