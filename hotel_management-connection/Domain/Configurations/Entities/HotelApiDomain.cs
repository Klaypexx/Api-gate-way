using Domain.Configurations.Repositiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.Entities
{
    public class HotelApiDomain : IHotelApiDomain
    {
        public string Address { get; set; }
        public HotelApiDomain(string address) {
            Address = address;
        }
    }
}
