using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;
using AlkemyChallenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlkemyChallenge.AccessData.Queries
{
    public class UsersQueries : IUsersQueries
    {

        private readonly APIDbContext _context;

        public UsersQueries(APIDbContext context)
        {
            _context = context;
        }


        public Users GetUser(Users usr)
        {

            var user = _context.Set<Users>().Where(u => u.Username == usr.Username && u.Password == usr.Password).FirstOrDefault();

            return user;
        }

    }
}