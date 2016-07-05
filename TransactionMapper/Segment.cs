using System;
using System.Linq;
using System.Net;

namespace TransactionMapper
{
    class Segment
    {
        public long RangeStart { get; }
        public long RangeEnd { get; }
        public string Name { get; }

        public Segment(string range, string name)
        {
            var ipAdresses = range.Split('-').Select(s => IPAddress.Parse(s)).Select(ip => BitConverter.ToUInt32(ip.GetAddressBytes().Reverse().ToArray(), 0)).ToList();
            RangeStart = ipAdresses.Min();
            RangeEnd = ipAdresses.Max();
            Name = name;
        }
    }
}