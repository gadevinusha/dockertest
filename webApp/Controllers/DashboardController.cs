using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApp.Models.Dashboard;

namespace webApp.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult View()
        {
            List<DashboardItem> dbItems = new List<DashboardItem>()
            {
                new DashboardItem()
                {
                    name="Equipment",
                    desc="All equipment details",
                    css="equipment",
                    Url="/Equipment/EquipmentSearch"
                },
                 new DashboardItem()
                {
                    name="Workorders",
                    desc="All workorders details",
                    css="workorder",
                    Url="/Workorder/WorkorderSearch"
                }
            };
            DashboardViewModel vm = new DashboardViewModel() { items = dbItems };
            return View(vm);
        }
    }
}