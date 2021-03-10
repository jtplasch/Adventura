using Adventura.Data;
using Adventura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adventura.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        private readonly LocationDbContext _context = new LocationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateActivity(Activity model)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllActivitiesForLocation(int id)
        {
            List<ActivityListItem> activities = await _context.Activities

                .Where(a => a.LocationId == id)
                .Select(a => new ActivityListItem()
                {
                    ActivityType = a.ActivityType,
                    Description = a.Description
                })
                .ToListAsync();
            return Ok(activities);
        }
    }
}
