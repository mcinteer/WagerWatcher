using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace WagerWatcher.Repositories
{
    public class RaceRepository
    {
       
        public static void Add(Race race)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(race);
                transaction.Commit();
            }
        }


        public static void Update(Race race)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(race);
                transaction.Commit();
            }
        }

        public void Remove(Race race)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(race);
                transaction.Commit();
            }
        }

        public static Race GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Race>(id);
            }
        }

        public static IList<Race> GetRacesInMeeting(Meeting meeting)
        {
            IList<Race> races;
            using (var session = NHibernateHelper.OpenSession())
            {
                races = session
                    .CreateCriteria(typeof (Race))
                    .Add(Restrictions.Eq("MeetingId", meeting.MeetingId))
                    .List<Race>();
            }
            return races;
        }

        public static IList<HorseInRace> GetHorsesInRace(Race race)
        {
            IList<HorseInRace> horses;
            using (var session = NHibernateHelper.OpenSession())
            {
                horses = session
                    .CreateCriteria(typeof (HorseInRace))
                    .Add(Restrictions.Eq("RaceId", race.RaceId))
                    .List<HorseInRace>();
            }
            return horses;
        }

        public static Race GetRaceByDateAndMeetingAndRaceNum(string normTime, Guid? meetingId, int raceNum)
        {
            Race race;
            using (var session = NHibernateHelper.OpenSession())
            {
                race = session
                    .CreateCriteria(typeof (Race))
                    .Add(Restrictions.Eq("NormTime", normTime))
                    .Add(Restrictions.Eq("MeetingId", meetingId))
                    .Add(Restrictions.Eq("RaceNum", raceNum))
                    .UniqueResult<Race>();
            }
            return race;
        }
    }
}
