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
    public class LocationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            return Ok(locations);
        }

        [HttpPost]
        public IHttpActionResult Post(LocationList location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(LocationDelete location)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(location))
                return InternalServerError();

            return Ok();
        }

        private LocationService CreateLocationService()
        {
            var locationService = new LocationService();
            return locationService;
        }
    }
}
