using Microsoft.AspNetCore.Mvc.Formatters;

namespace DataFormaterAPI.MediaFormater
{
    public class HtmlOutputFormatter : StringOutputFormatter
    {
        public HtmlOutputFormatter()
        {
            SupportedMediaTypes.Add("text/html");
        }
    }
}
