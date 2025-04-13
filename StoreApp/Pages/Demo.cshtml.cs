using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace StoreApp.Pages
{
    public class DemoModel :PageModel
    {
        public string? FullName=>HttpContext?.Session?.GetString("name")??"User";/*Dogrudan Session kullanilabilmektedir.*/
        public void OnGet()
        {
            
        }
        public void OnPost([FromForm]string name)/*Name icin model binding yapacagiz parametrede*/
        {
            //FullName=name;
            HttpContext.Session.SetString("name",name);//Parametreden gelen deger bu sekilde Session icerisinde tutulacaktir.[Key-Value pair-->Parametre]
            /*Session icerisinde tutabilecegimiz data typelar
                -byte[]--> byte array
                -int-->integer
                -string
                -Eger class tutmak istiyorsak serialize ediyoruz. Daha sonra deserialize ederek tekrar class yapiyoruz.
            */
            /*HttpContext nesnesi icerisinde
              -connection
              -item
              -session
            gibi alanlar icerir.
            Requestler ile responselar organize etmek icin kullanacagiz.
            */
        }
    }
}