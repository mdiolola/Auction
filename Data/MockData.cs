using Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class MockData
    {
        public List<AuctionItemEntity> AuctionItems =
            new List<AuctionItemEntity>
            {
                new AuctionItemEntity { Id = 1, Name = "Item 1", Bid = 100},
                new AuctionItemEntity { Id = 2, Name = "Item 2", Bid = 1000},
                new AuctionItemEntity { Id = 3, Name = "Item 3", Bid = 10000},
            };

        public List<AuctionListEntity> AuctionItemLists()
        {
            return new List<AuctionListEntity>
            {
                new AuctionListEntity
                {
                    Id = 1,
                    Title = "First Auction",
                    AuctionItemList = this.AuctionItems,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7)
                },
            };
        }

        public List<BidderEntity> Bidders =
            new List<BidderEntity>
            {
                new BidderEntity { Id = 1, Name = "Bidder 1" },
                new BidderEntity { Id = 2, Name = "Bidder 2" }
            };
    }
}
