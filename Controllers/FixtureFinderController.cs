using FixtureFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Text;
using FixtureFinder.Models.DistanceApi;
using FixtureFinder.Models.Feed;

public class FixtureFinderController : Controller
{
   
    private FixtureRetriever footballFixtures = new FixtureRetriever();
   
    // GET: FixtureFinder
    public ActionResult FixtureFinder()
    {
        return View();
    }

    public ActionResult Home()
    {
        return View();
    }

    public ActionResult About()
    {
        return View();
    }

    public ActionResult Contacts()
    {
        return View();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ActionResult Results()
    {

        // read out the user input
        //string location = Request.Form.Get("Location");
        //string days = Request.Form.Get("days");
        string days = Request.QueryString["days"];
        string location = Request.QueryString["Location"];

        // call the model
        List<Event> games = footballFixtures.getPremierLeagueFixtures(days, location); //Passing down the location into this method
      
        // pass it too the view
        return View(games);

    }


    public ActionResult Fixturedetails()
    {
        return View();
    }


  
}
