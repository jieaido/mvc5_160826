using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.HtmlHelps
{
    public static class PageingHelps
    {
        public static MvcHtmlString PageLinks(this HtmlHelper htmlHelper, PageingInfo pageingInfo,
            Func<int, string> pageUrlFunc)
        {
            StringBuilder result=new StringBuilder();
            for (int i = 0; i < pageingInfo.TotalPages; i++)
            {
                TagBuilder tag=new TagBuilder("a");
                tag.MergeAttribute("href",pageUrlFunc(i));
                tag.InnerHtml = i.ToString();
                if (i==pageingInfo.currentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}