using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _net_core一个接口多种注入的实现.Models;
using _net_core一个接口多种注入的实现.interfaces;

namespace _net_core一个接口多种注入的实现.Controllers
{
    public class HomeController : Controller
    {
        private readonly Func<string, IDemo> _Provider;

        //This first way
        //private readonly IEnumerable<IDemo> demos;
        IDemo A, B;
        public HomeController(Func<string,IDemo> Provider)//IEnumerable<IDemo> demos)
        {
            this._Provider = Provider;
             A = _Provider("AService");
             B = _Provider("BService");
            //this.demos = demos;
            //A = demos.FirstOrDefault(x => x.GetType().Name.Equals("AService"));
            //B = demos.FirstOrDefault(x => x.GetType().Name.Equals("BService"));
        }

        public IActionResult Index()
        {
            var a= A.gethello();
            var b= B.gethello();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
