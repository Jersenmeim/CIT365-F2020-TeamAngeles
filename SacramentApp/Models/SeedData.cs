using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentApp.Data;
using SacramentApp.Models;
using System;
using System.Linq;

namespace SacramentApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentAppContext>>()))
            {
                // Look for any movies.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                var meetings = new Meeting[]
                {
                new Meeting{Date=DateTime.Parse("2020-07-05"), ConductingLeader="Bishop Dela Cruz", OpeningHymn="The Spirit of God", Invocation="Steven Meim", SacramentHymn="Sabbath Day", Benediction="Naomi Cruz", ClosingHymn="Press Forward Saints"},
                new Meeting{Date=DateTime.Parse("2020-07-12"), ConductingLeader="Bishop Dela Cruz", OpeningHymn="Morning Breaks", Invocation="Megan Escandor", SacramentHymn="As Now We Take the Sacrament", Benediction="John Smith", ClosingHymn="Iron Rod"},
                };
                foreach (Meeting s in meetings)
                {
                    context.Meeting.Add(s);
                }
                context.SaveChanges();



                var talks = new Talks[]
                {
                new Talks{NameSpeaker="Peter Reyes", Topic="Faith", MeetingId=1},
                new Talks{NameSpeaker="Mark Smith", Topic="Atonement", MeetingId=1},
                new Talks{NameSpeaker="John Depp", Topic="Hope", MeetingId=1},
                new Talks{NameSpeaker="Janica Vargas", Topic="Charity", MeetingId=2},
                new Talks{NameSpeaker="Nataniel Arroyo", Topic="Missionary Work", MeetingId=2},
                new Talks{NameSpeaker="Anthony Santos", Topic="Tithing", MeetingId=2}

                };
                foreach (Talks e in talks)
                {
                    context.Talks.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}