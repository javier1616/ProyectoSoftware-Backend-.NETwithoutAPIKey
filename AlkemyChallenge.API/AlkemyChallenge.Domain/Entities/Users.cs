using AlkemyChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlkemyChallenge.Domain.Entities
{
    public class Users
    {
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
