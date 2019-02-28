using System.Web;
using System.Web.Mvc;

namespace Sedas_Ticaret
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
