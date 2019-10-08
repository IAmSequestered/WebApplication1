using MAMC.BiPass.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    private BiPassDatabase_Context MyDatabase;

    public HomeController()
    {
      MyDatabase = new BiPassDatabase_Context();

    }

    public ActionResult Index()
    {
      

      var myList = MyDatabase.FHIRLocations.ToList();

      return View();
    }

    public ActionResult About()
    {

      int myLocationId = 9;

      var myPractitioners = MyDatabase.FHIRPractitioners.Where(l => l.FHIRLocations.Any(m => m.LocationId == myLocationId)).ToList();

      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}