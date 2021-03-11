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
        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            return Ok(locations);
        }

        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
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
