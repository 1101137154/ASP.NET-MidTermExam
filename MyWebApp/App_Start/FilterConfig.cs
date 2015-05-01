using System.Web;
using System.Web.Mvc;

namespace MyWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //這行是預設的，意思就是他會捕捉到所有 Error，如果你在第一篇文章裡，把這一行註解掉，那他無法捕捉 Error，最後就沒辦法顯示我們自訂的 Error Page。
            filters.Add(new HandleErrorAttribute());
        }
    }
}