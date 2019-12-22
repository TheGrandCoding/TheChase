using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TheChase.Classes
{
    public class User : JsonEntity, IEquatable<User>
    {
        public User(JObject obj) : base(obj)
        {
            Id = obj["id"].ToObject<uint>();
            Name = obj["name"].ToObject<string>();
        }
        public User() : base(null) { }

        public uint Id { get; set; }
        public string Name { get; set; }

        public override JObject ToObject()
        {
            var obj = new JObject();
            obj["id"] = Id.ToString();
            obj["name"] = Name;
            return obj;
        }

        public override bool Equals(object obj)
        {
            if (obj is User u)
            {
                return u.Equals(this);
            }
            return false;
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public static bool operator ==(User lhs, User rhs)
        {
            return object.ReferenceEquals(lhs, rhs) || !object.ReferenceEquals(lhs, null) && lhs.Equals(rhs);
        }
        public static bool operator !=(User a, User b)
        {
            return !(a == b);
        }
    }
}
