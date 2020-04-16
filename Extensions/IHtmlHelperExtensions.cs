using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mariage.Extensions 
{
    public static class IHtmlHelperExtensions
    {
        public static IHtmlContent YesNo(this IHtmlHelper htmlHelper, bool yes)
        {
            var htmlClass = yes ? "yes" : "no";
            return new HtmlString($"<span class=\"icon-{htmlClass}\"></span>");
        }
    }
}