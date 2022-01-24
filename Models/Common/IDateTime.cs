using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Models.Common
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class DateTimeService : IDateTime
    {
        DateTime IDateTime.Now => DateTime.Now;
    }
}
