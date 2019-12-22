using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChase.Classes;

namespace TheChase
{
    public static class Common
    {
        public static Dictionary<uint, User> Users = new Dictionary<uint, User>();
        public static uint USER_ID = 1;
        public static User GetUser(uint id)
        {
            if (id == 0)
                return null;
            Users.TryGetValue(id, out var u);
            return u;
        }
    }
}
