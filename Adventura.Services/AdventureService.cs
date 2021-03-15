﻿using Adventura.Data;
using Adventura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Services
{
    public class AdventureService
    {
        private readonly Guid _userId;

        public AdventureService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAdventure(AdventureCreate model)
        {
            var entity = new Adventure()
            {
                OwnerId = _userId,              
                Title = model.Title,
                Location = model.Location,
                Activities = model.Activities,
                CreatedUtc = DateTimeOffset.Now
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Adventures.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //below allows you to see all adventures belonging to a specific user
        public IEnumerable<AdventureListItems> GetAdventures()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Adventures
                        .Where(e => e.OwnerId == _userId)
                        .Select(e => new AdventureListItems
                            {
                                AdventureId = e.AdventureId,
                                Title = e.Title,
                                Location = e.Location,
                                Activities = e.Activities,
                                CreatedUtc = e.CreatedUtc
                            }
                        );
                return query.ToArray();                                                     
            }
        }

        public bool UpdateAdventure(AdventureEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Adventures
                    .Single();

                entity.AdventureId = model.AdventureId;
                entity.Title = model.Title;
                entity.Location = model.Location;
                entity.Activities = model.Activities;
                entity.CreatedUtc = model.CreatedUtc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdventure(int adventureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Adventures
                    .Single(e => e.AdventureId == adventureId);

                ctx.Adventures.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
