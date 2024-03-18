using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MiniCoreProjects
{
    public class CustomMyLinkTegHelper : TagHelper
    {
        public string MyWeb { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"{MyWeb}");
            output.Attributes.Add("id", "my-web");
            output.Content.SetContent("visit my website");
        }
    }
}
