using Adventura.Data;
using Adventura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Services
{
    public class ActivityService
    {
        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new Activity()
                {
                    ActivityType = model.ActivityType,
                    ActivityDescription = model.ActivityDescription,
                    ActivityLength = model.ActivityLength,
                    ActivityCost = model.ActivityCost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ActivityListItem> GetActivities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Activities
                        .Select(
                            e =>
                                new ActivityListItem
                                {
                                    ActivityType = e.ActivityType,
                                    ActivityDescription = e.ActivityDescription,
                                    ActivityLength = e.ActivityLength,
                                    ActivityCost = e.ActivityCost
                                }
                        );

                return query.ToArray();
            }
        }

    }
}
