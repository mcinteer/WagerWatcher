using System;
using System.Web.Mvc;
using WagerWatcher;

namespace WagerWatcherWeb.Controllers
{
    public class UpdateDatabaseController : Controller
    {
        public ActionResult ChooseSchedule()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSchedule(string date, string period)
        {
            var strDate = date.Split('/');
            var prg = new Program();
            prg.Main(Int32.Parse(strDate[2]), Int32.Parse(strDate[0]), Int32.Parse(strDate[1]), Int32.Parse(period));
            return Redirect("~/dashboard");
        }

        
    }
}