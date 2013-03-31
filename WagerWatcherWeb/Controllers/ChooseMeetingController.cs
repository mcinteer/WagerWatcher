using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WagerWatcher;
using WagerWatcher.Repositories;
using WagerWatcherWeb.Models;

namespace WagerWatcherWeb.Controllers
{
    public class ChooseMeetingController : Controller
    {
        public ActionResult ChooseMeeting()
        {
            return View();
        }

        public ActionResult ListMeetings(string date)
        {
            var dateParts = date.Split('/');
            var dateTime = new DateTime(Int32.Parse(dateParts[2]), Int32.Parse(dateParts[0]), Int32.Parse(dateParts[1]));
            date = dateTime.ToString("yyy-MM-dd");
            var meetings = MeetingRepository.GetMeetingsByDate(date);
            var raceDay = new RaceDay() {Meetings = meetings};
            return View(raceDay.Meetings);
        }

        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public ActionResult ListRaces(string meetingid)
        {
            var races = RaceRepository.GetRacesInMeeting(new Meeting() {MeetingId = new Guid(meetingid)});
            return View(races);
        }

        public ActionResult HorsesInRace(Guid raceid)
        {
            var horses = HorseRepository.GetHorsesInRace(new Race() {RaceId = raceid});
            return View(horses);
        }
    }
}