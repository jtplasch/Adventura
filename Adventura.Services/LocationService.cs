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
        private readonly Guid _userid;
        public LocationService(Guid userid)
        {
            _userid = userid;
        }

        public bool CreateLocation(LocationCreate model)
        {           
            var entity = new Location()
            {                
                LocationName = model.LocationName,
                AdventureId = model.AdventureId
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
                            CreatedUtc = e.CreatedUtc,
                            AdventureId = e.AdventureId
                        }
                        );
                return query.ToArray();
            }
        }

        public LocationDelete GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == id);
                return
                    new LocationDelete
                    {
                        LocationName = entity.LocationName,
                        CreatedUtc = entity.CreatedUtc,
                        AdventureId = entity.AdventureId
                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == model.LocationId);

                entity.LocationId = model.LocationId;
                entity.LocationName = model.LocationName;
                entity.AdventureId = model.AdventureId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == locationId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
