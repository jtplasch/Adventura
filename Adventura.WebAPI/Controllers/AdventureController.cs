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
    [Authorize]
    public class AdventureController : ApiController
    {
        public IHttpActionResult Post(AdventureCreate adventure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdventureService();

            if (!service.CreateAdventure(adventure))
                return InternalServerError();

            return Ok();
        }
       
        public IHttpActionResult Get()
        {
            AdventureService adventureService = CreateAdventureService();
            var adventures = adventureService.GetAdventures();
            return Ok(adventures);
        }
        public IHttpActionResult Put(AdventureEdit adventure)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdventureService();

            if (!service.UpdateAdventure(adventure))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAdventureService();

            if (!service.DeleteAdventure(id))
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
