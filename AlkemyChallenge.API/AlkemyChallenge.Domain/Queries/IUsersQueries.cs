using System;
using System.Collections.Generic;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesDTO;

namespace AlkemyChallenge.Domain.Queries
{
    public interface IUsersQueries
    {
        public Users GetUser(Users usr);
    }
}
