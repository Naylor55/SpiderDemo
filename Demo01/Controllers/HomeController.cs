using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HtmlAgilityPack;

namespace Demo01.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult ParseHtmlDemo01()
        {
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("http://www.cnblogs.com/Naylor/p/6279595.html");
            HtmlNode HtmlNode = doc.GetElementbyId("topics");
            string OuterHtml = HtmlNode.OuterHtml;
            ViewBag.cpost = OuterHtml;
            List<string> allarticle = GetArticleList();
            ViewBag.allarticle = allarticle;
            return View();
        }

      

        /// <summary>
        /// 获取博客园主页第一页的文章列表
        /// </summary>
        private List<string> GetArticleList()
        {
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("http://www.cnblogs.com/");
            HtmlNode allitem = doc.GetElementbyId("post_list");
            HtmlNodeCollection items = allitem.ChildNodes;
            List<string> articles = new List<string>();
            foreach (HtmlNode child in items)
            {
                if (child.Attributes["class"] == null || child.Attributes["class"].Value != "post_item")
                {
                    continue;
                }
                HtmlNode hn = HtmlNode.CreateNode(child.OuterHtml);
                string link = hn.SelectSingleNode("//*[@class=\"titlelnk\"]").OuterHtml;
                articles.Add(link);
            }
            return articles;
        }
    }
}