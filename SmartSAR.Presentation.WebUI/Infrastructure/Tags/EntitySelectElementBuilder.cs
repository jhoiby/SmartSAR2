using System;
using System.Collections.Generic;
using HtmlTags;
using HtmlTags.Conventions;
using HtmlTags.Conventions.Elements;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//This code is from Jimmy Bogard's Contoso University with Razor Example
 //See: https://jimmybogard.com/migrating-contoso-university-example-to-razor-pages/ 

namespace Presentation.WebUI.Infrastructure.Tags
{
    public abstract class EntitySelectElementBuilder<T> : ElementTagBuilder where T : class
    {
        public override bool Matches(ElementRequest subject)
        {
            return typeof(T).IsAssignableFrom(subject.Accessor.PropertyType);
        }

        public override HtmlTag Build(ElementRequest request)
        {
            var results = Source(request);

            var selectTag = new SelectTag(t =>
            {
                t.Option(string.Empty, string.Empty); // blank default option
                foreach (var result in results)
                {
                    BuildOptionTag(t, result, request);
                }
            });

            var entity = request.Value<T>();

            if (entity != null)
            {
                selectTag.SelectByValue(GetValue(entity));
            }

            return selectTag;
        }

        protected virtual HtmlTag BuildOptionTag(SelectTag select, T model, ElementRequest request)
        {
            return select.Option(GetDisplayValue(model), GetValue(model));
        }

        protected abstract Guid GetValue(T instance);
        protected abstract string GetDisplayValue(T instance);

        protected virtual IEnumerable<T> Source(ElementRequest request)
        {
            // TODO: LOOK AT GETTING RID OF THIS DIRECT REFERENCE TO THE DB CONTEXT! WHY IS IT HERE?
            return request.Get<IdentityDbContext>().Set<T>();
        }
    }
}