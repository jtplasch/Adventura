using Adventura.Data;
using Adventura.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Tests
{
    public class ActivityTests
    {
        private List<Activity> _activities;

        [TestInitialize]
        public void Seed()
        {
            _activities = new List<Activity>();
            Activity testActivity = new Activity
            {
                ActivityType = TypeOfActivity.DiscGolfing,
                ActivityDescription = "Fall Creek 27 Hole",
                ActivityLength = 3,
                ActivityCost = default
            };
            _activities.Add(testActivity);
        }

    }
}
