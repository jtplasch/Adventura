using Adventura.Data;
using Adventura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Services
{
    public class LocationService
    {
        public bool CreateLocation(LocationCreate model)
        {
            var entity = new Location()
            {
                LocationId = model.LocationId,
                LocationName = model.LocationName,
                AdventureId = model.AdventureId,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //below allows you to see all adventures belonging to a specific user
        public IEnumerable<LocationList> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Select
                        (e => new LocationList
                        {
                            LocationId = e.LocationId,
                            LocationName = e.LocationName,
                            AdventureId = e.AdventureId,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
