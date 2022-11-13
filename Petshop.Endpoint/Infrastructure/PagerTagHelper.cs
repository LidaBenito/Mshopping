using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Petshop.Utility.Paginations;

namespace Petshop.Endpoint.Infrastructure
{
    [HtmlTargetElement("div",Attributes ="page-model")]
    public class PagerTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperfactory;

        public PagerTagHelper(IUrlHelperFactory urlHelperfactory)
        {
            this.urlHelperfactory = urlHelperfactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public  ViewContext  ViewContext{ get; set; }
        public PageInfo PageModel{ get; set; }
        public string  PageAction{ get; set; }
        public Dictionary<string,object> PageUrlValue { get; set; }
        public bool PageClassesEnable { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassSelected { get; set; }
        public string PageClassNormal { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperfactory.GetUrlHelper(ViewContext);
            TagBuilder result = new("div");
            for (int i = 1; i <= PageModel.PageCount; i++)
            {
                TagBuilder tag = new("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNumber = i });
                if (PageClassesEnable)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.PageNumber ? PageClassSelected :
                        PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
