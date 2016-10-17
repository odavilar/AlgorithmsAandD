using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTnH
{
    class User
    {
        public int id;
        public Name name;
        public Location location;
        public string email;
        public string picture;

        public User()
        {
            name = new Name();
            location = new Location();
        }

        public string getName()
        {
            return name.first + " " + name.last;
        }

        public string getNameWithTitle()
        {
            return name.title + " " + name.first + " " + name.last;
        }

        public string getAddress()
        {
            return location.street + ", " + location.city + ", " + location.state + ", " + location.postcode;
        }
    }
}
