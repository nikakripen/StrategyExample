using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransactionMapper
{
    class Transaction
    {
        public string UserId { get; }
        public long IpAddress { get; }

        public Transaction(string userId, string ip)
        {
            if (String.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }
            if (String.IsNullOrEmpty(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }

            IPAddress address = IPAddress.Parse(ip);
            UserId = userId;
            IpAddress = BitConverter.ToUInt32(address.GetAddressBytes().Reverse().ToArray(), 0);
        }
    }
}
