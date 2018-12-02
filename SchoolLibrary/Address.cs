using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public struct Address
    {
        public string streetName;
        public string city;
        public string province;

        public Address(string streetName, string city, string province)
        {
            this.streetName = streetName;
            this.city = city;
            this.province = province;
        }
    }
}
