using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using RedditSharp;
using RHAA.Services;
using RHAA.Models;
using System.Runtime.Serialization.Json;

namespace RHAA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var reddit = new Reddit();
            //var user = reddit.LogIn("EddieValiantsRabbit", "camaro");
            var all = reddit.GetSubreddit("/r/news");

            var listOfPosts = all.Hot.Take(25);

            ViewBag.Posts = new List<RedditSharp.Things.Post>();
            ViewBag.Posts = listOfPosts;
           
            ViewBag.Greeting = "Good " + SpareParts.DeterminePartOfDay();
            WebRequest weatherRequest = WebRequest.Create(@"http://api.openweathermap.org/data/2.5/weather?zip=94040,us&appid=8b3de9d1132f5c7199d2650d858cef68");
            weatherRequest.ContentType = "application/json; charset=utf-8";

            WeatherResponse jsonResponse = new WeatherResponse();

            using (HttpWebResponse weatherResponse = weatherRequest.GetResponse() as HttpWebResponse)
            {
                if (weatherResponse.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    weatherResponse.StatusCode,
                    weatherResponse.StatusDescription));
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WeatherResponse));
                object objResponse = jsonSerializer.ReadObject(weatherResponse.GetResponseStream());
                jsonResponse
                = objResponse as WeatherResponse;
                
            }


            ViewBag.CurrentMonth = SpareParts.GetCurrentMonth(DateTime.Now.Month);
            ViewBag.CurrentDayOfMonth = DateTime.Now.Day;
            ViewBag.CurrentDayOfWeek = DateTime.Now.DayOfWeek;
            ViewBag.CurrentHour = DateTime.Now.Hour;
            ViewBag.CurrentMinute = DateTime.Now.Minute;
            ViewBag.CurrentSecond = DateTime.Now.Second;
            ViewBag.CurrentTemp = (jsonResponse.main.Temp - 273.15) * 1.8 + 32;
            ViewBag.WeatherDescription = jsonResponse.weather[0].Description;
            


            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}