﻿using System;
using System.ComponentModel.DataAnnotations;
using HtmlTags;
using HtmlTags.Conventions;

// This code is from Jimmy Bogard's Contoso University with Razor Example
// See: https://jimmybogard.com/migrating-contoso-university-example-to-razor-pages/ 

namespace Presentation.WebUI.Infrastructure.Tags
{
    public class TagConventions : HtmlConventionRegistry
    {
        public TagConventions()
        {
            Editors.Always.AddClass("form-control");

            Editors.IfPropertyIs<DateTime?>().ModifyWith(m => m.CurrentTag
                .AddPattern("9{1,2}/9{1,2}/9999")
                .AddPlaceholder("MM/DD/YYYY")
                .AddClass("datepicker")
                .Value(m.Value<DateTime?>() != null ? m.Value<DateTime>().ToShortDateString() : string.Empty));
            Editors.If(er => er.Accessor.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase)).BuildBy(a => new HiddenTag().Value(a.StringValue()));
            Editors.IfPropertyIs<byte[]>().BuildBy(a => new HiddenTag().Value(Convert.ToBase64String(a.Value<byte[]>())));


            Labels.Always.AddClass("control-label");
            Labels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));

            // Just assume a "Data." prefix for attributes.
            Labels
                .Always
                .ModifyWith(er => er.CurrentTag.Text(er.CurrentTag.Text().Replace("Data ", "")));

            //Editors.BuilderPolicy<InstructorSelectElementBuilder>();
            //Editors.BuilderPolicy<DepartmentSelectElementBuilder>();
            DisplayLabels.Always.BuildBy<DefaultDisplayLabelBuilder>();
            DisplayLabels.ModifyForAttribute<DisplayAttribute>((t, a) => t.Text(a.Name));
            Displays.IfPropertyIs<DateTime>().ModifyWith(m => m.CurrentTag.Text(m.Value<DateTime>().ToShortDateString()));
            Displays.IfPropertyIs<DateTime?>().ModifyWith(m => m.CurrentTag.Text(m.Value<DateTime?>()?.ToShortDateString()));
            Displays.IfPropertyIs<decimal>().ModifyWith(m => m.CurrentTag.Text(m.Value<decimal>().ToString("C")));
        }

        public ElementCategoryExpression DisplayLabels => new ElementCategoryExpression(Library.TagLibrary.Category(nameof(DisplayLabels)).Profile(TagConstants.Default));
    }
}