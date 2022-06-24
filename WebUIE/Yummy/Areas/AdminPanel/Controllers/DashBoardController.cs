using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy.DAL;

namespace Yummy.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class DashBoardController : Controller
    {

        // GET: DashBoardController
       
        public ActionResult Index()
        {
            return View();
        }

    }
}
