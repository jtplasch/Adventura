using Adventura.Data;
using Adventura.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.Services
{
    public class UserService
    {

        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItems> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.OwnerId == _userId)
                        .Select(e => new UserListItems
                        {
                            Id = e.Id,
                            FullName = e.FullName,
                            Email = e.Email,
                            Password = e.Password
                        }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Users
                    .Single();

                entity.FullName = model.FullName;
                entity.Email = model.Email;
                entity.Password = model.Password;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Users
                    .Single(e => e.Id == id);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
