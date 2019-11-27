using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HubSignalRLearning.Controllers
{
    public class DrawMocksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}