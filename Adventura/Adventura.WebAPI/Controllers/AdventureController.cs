using Adventura.Models;
using Adventura.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Adventura.WebAPI.Controllers
{
    [Authorize]
    public class AdventureController : ApiController
    {
        public IHttpActionResult Get()
        {`
            AdventureService adventureService = CreateAdventureService();
            var adventures = adventureService.GetAdventures();
            return Ok(adventures);
        }

        public IHttpActionResult Get(int id)
        {
            AdventureService adventureService = CreateAdventureService();
            var adventure = adventureService.GetAdventureById(id);
            return Ok(adventure);
        }

        public IHttpActionResult Post(AdventureCreate adventure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdventureService();

            if (!service.CreateAdventure(adventure))
                return InternalServerError();

            return Ok();
        }

        private AdventureService CreateAdventureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var adventureService = new AdventureService(userId);
            return adventureService;
        }
    }
}
