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
using FixtureFinder;

public class FixtureFinderController : Controller
{
   
    private FixtureRetriever footballFixtures = new FixtureRetriever();
    private FixtureFinderEntities1 db = new FixtureFinderEntities1();
   
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
        string days = Request.QueryString["Days"];
        string location = Request.QueryString["Location"];

        // call the model
        List<Event> games = footballFixtures.getPremierLeagueFixtures(days, location); //Passing down the location into this method
      
        // pass it too the view
        return View(games);

    }


    public ActionResult Fixturedetails()
    {
        // extract the stadium id

        string stadium = Request.QueryString["stadium"];
        string userorigin = Request.QueryString["location"];
        
        // convert to an int (since db lookup requires an int
        int stadiumId = Convert.ToInt32(stadium);
        StadiumInfo stadiuminfo = db.StadiumInfos.Find(stadiumId);
        
        ViewBag.stadium = stadiuminfo; 
        ViewBag.userorigin = userorigin;
        
        return View();
    }
}
