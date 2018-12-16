using HtmlTags;
using Microsoft.AspNetCore.Razor.TagHelpers;

// This code is from Jimmy Bogard's Contoso University with Razor Example
// See: https://jimmybogard.com/migrating-contoso-university-example-to-razor-pages/ 

namespace Presentation.WebUI.Infrastructure.Tags
{
    [HtmlTargetElement("display-label-tag", Attributes = nameof(For), TagStructure = TagStructure.WithoutEndTag)]
    public class DisplayLabelTagHelper : HtmlTagTagHelper
    {
        protected override string Category { get; } = nameof(TagConventions.DisplayLabels);
    }
}