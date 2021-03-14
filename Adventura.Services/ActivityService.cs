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
        private readonly Guid _userId;

        public ActivityService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateActivity(ActivityCreate model)
        {
            var entity = new Activity()
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
                            e => new ActivityListItem
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

        public bool UpdateActivity(ActivityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single();

                entity.ActivityDescription = model.ActivityDescription;
                entity.ActivityLength = model.ActivityLength;
                entity.ActivityCost = model.ActivityCost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteActivity(int activityId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.ActivityId == activityId);

                ctx.Activities.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
