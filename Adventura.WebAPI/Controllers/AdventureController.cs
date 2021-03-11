using Adventura.Data;
using Adventura.Models;
using Adventura.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Adventura.WebAPI.Controllers
{
    public class AdventureController : ApiController
    {
        private readonly AdventureDbContext _context = new AdventureDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateAdventure(Adventure model)
        {
            if (ModelState.IsValid)
            {
                _context.Adventures.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
                return BadRequest(ModelState);
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> GetAllAdventures()
        {
            List<Adventure> adventures = await _context.Adventures.ToListAsync();

            List<AdventureListItems> adventureList = adventures
                .Select(a => new AdventureListItems()
                {
                    Title = a.Title,
                    Location = a.Location,
                    Activities = a.Activities,
                    CreatedUtc = a.CreatedUtc,
                    AdventureId = a.AdventureId,
                }).ToList();

            return Ok(adventureList);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAdventureById(int id)
        {
            Adventure adventure = await _context.Adventures.FindAsync(id);

            if(adventure == default)
            {
                return NotFound();
            }

            AdventureDetail adventureDetail = new AdventureDetail()
            {
                AdventureId = adventure.AdventureId,
                Title = adventure.Title,
                Location = adventure.Location,
                Activities = adventure.Activities,
                CreatedUtc = adventure.CreatedUtc,
            };
            return Ok(adventureDetail);
        }

        private AdventureService CreateAdventureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var adventureService = new AdventureService(userId);
            return adventureService;
        }
    }
}
