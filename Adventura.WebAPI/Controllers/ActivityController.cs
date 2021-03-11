using Adventura.Data;
using Adventura.Models;
using Adventura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adventura.WebAPI.Controllers
{
    [Authorize]
    public class ActivityController : ApiController
    {
        public IHttpActionResult Get()
        {
            ActivityService activityService = CreateActivityService();
            var activities = activityService.GetActivities();
            return Ok(activities);
        }
        public IHttpActionResult Post(ActivityCreate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActivityService();

            if (!service.CreateActivity(activity))
                return InternalServerError();

            return Ok();
        }
        private ActivityService CreateActivityService()
        {
            var activityService = new ActivityService();
            return activityService;
        }
    }
}
