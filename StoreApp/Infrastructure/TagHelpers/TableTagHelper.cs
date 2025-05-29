using Microsoft.AspNetCore.Razor.TagHelpers;
namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("table")]//Table icin kullanacagimiz bu attribute kullanilmali
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "table table-hover table-bordered"); //Bootstrap'in table ozelliginin eklenmesi bu komutla saglanacak. Anahtar-repair durumu vardir.
        } 
    }
}