using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Models;

namespace Auction.Services.Interfaces
{
    public interface IBidderService
    {
        public Bidder GetBidder(int id);

        public bool NewBid(AuctionItem obj);

        public bool IsBiddingActive(AuctionList id);
    }
}
