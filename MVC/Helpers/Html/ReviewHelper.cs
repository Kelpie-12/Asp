using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVC.Helpers.Html
{
    public static class ReviewHelper
    {     

        public static HtmlString CreateReviewContainer(this IHtmlHelper helper, MVC.Model.UserReview user)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "carousel-item active");
            div.InnerHtml.AppendHtml(TagP(user.Desc));
            div.InnerHtml.AppendHtml(TagDivMark(user.Mark.ToString()));
            div.InnerHtml.AppendHtml(TagDivUserName(user.UserName));
            TagBuilder a = new TagBuilder(DivRowTextCenter(DivColMd12(DivCarouselInner(div))));
            using (var writter = new StringWriter())
            {
                a.WriteTo(writter, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writter.ToString());
            }
        }
        private static TagBuilder TagP(string item)
        {
            TagBuilder p = new TagBuilder("div");
            p.Attributes.Add("class", "lead font-italic mx-4 mx-md-5");
            p.InnerHtml.Append(item);
            return p;
        }
        private static TagBuilder TagDivMark(string item)
        {
            TagBuilder div_mark = new TagBuilder("div");
            div_mark.Attributes.Add("class", "mt-5 mb-4");
            TagBuilder h = new TagBuilder("h6");
            h.InnerHtml.Append(item);
            div_mark.InnerHtml.AppendHtml(h);
            return div_mark;
        }
        private static TagBuilder TagDivUserName(string item)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "mt-5 mb-4");
            TagBuilder h = new TagBuilder("h5");
            h.InnerHtml.Append(item);
            div.InnerHtml.AppendHtml(h);
            return div;
        }
        private static TagBuilder DivCarouselInner(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "carousel-inner");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder DivRowTextCenter(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "row text-center");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }
        private static TagBuilder DivColMd12(TagBuilder tag)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "col-md-12");
            div.InnerHtml.AppendHtml(tag);
            return div;
        }

    }
}
