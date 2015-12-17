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
using FixtureFinder.Models;

public class FixtureFinderController : Controller
{
   
    private FixtureRetriever footballFixtures = new FixtureRetriever();
    private FixtureFinderEntities1 db = new FixtureFinderEntities1();
    private DistanceMatrix distanceFinder = new DistanceMatrix();
   
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
        string travelmode = Request.QueryString["travelmode"];

        // call the model
        List<Event> games = footballFixtures.getPremierLeagueFixtures(days, location, travelmode); //Passing down the location into this method
        List<Event> distance = distanceFinder.distancefromLocation(games, location, travelmode);

        // now store the distances in the session - for easy retrieval next time!
        this.CacheEvents(distance);

        // pass it too the view
        return View(distance);
    }

    private void CacheEvents(List<Event> events)
    {
        this.Session["events"] = events;
    }

    // returns the event as cached in the session, looked up
    // from the given href - ugly, but kinda beautiful in its
    // own, quasimodoeqsue way :-)
    private Event LookupEvent(string href)
    {
        Event newEvent = null;

        List<Event> events = (List<Event>)this.Session["events"];
        if (events != null) // checking that you've managed to find the events in the session, will just return null if you haven't
        {
            foreach(Event e in events)
            {
                if (e.href.Equals(href))
                {
                    // wayhay! we've found the event!
                    newEvent = e;
                    break;
                }
            }
        }

        return newEvent;
    }


    public ActionResult Fixturedetails()
    {
        // extract the stadium id

        string stadium = Request.QueryString["stadium"];
        string userorigin = Request.QueryString["location"];
        string modeoftravel = Request.QueryString["travelmode"];
        string href = Request.QueryString["href"];

        // need to lookup the event info, keyed against the given href
        Event e = this.LookupEvent(href);

        if (e != null)
        {
            // convert to an int (since db lookup requires an int
            int stadiumId = Convert.ToInt32(stadium);
            StadiumInfo stadiuminfo = db.StadiumInfos.Find(stadiumId);

            ViewBag.stadium = stadiuminfo;
            ViewBag.userorigin = userorigin;
            ViewBag.modeoftravel = modeoftravel;
            ViewBag.e = e;
            return View();
        } else
        {
            // the event is null (wasn't found in the view.
            // show the user some sort of error page?
            return RedirectToAction("home", "FixtureFinder");
            //return Home(); // redirect them to the home page!
        }
    }
}
