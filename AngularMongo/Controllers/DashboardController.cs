
using System.Collections.Generic;


using AngularMongo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularMongo.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        //[BasicWebAPIAuthenticationHandler]
        //[EnableCors("AllowOrigin")]
        //[Authorize]
        //[System.Web.Http.Route("GetDashboardItems")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        //[ServiceFilter(typeof(BasicWebAPIAuthenticationHandler))]
        public IEnumerable<DashboardViewModel> Get()
        {
            List<DashboardViewModel> dbItems = new List<DashboardViewModel>() 
            {
                new DashboardViewModel()
                {
                    name="Equipment",
                    desc="All equipment details",
                    css="equipment",
                    //url="/Equipment/EquipmentSearch"
                     url="/equipment"
                },
                 new DashboardViewModel()
                {
                    name="Workorders",
                    desc="All workorders details",
                    css="workorder",
                    //url="/Workorder/WorkorderSearch"
                    url="/workorder"
                }
            };

            return dbItems;
            //DashboardViewModel vm = new DashboardViewModel() { items = dbItems };
            //return View(vm);
        }
    }
}
