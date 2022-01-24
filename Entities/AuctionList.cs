using System;
using System.Collections.Generic;

namespace Auction.Entities
{
    public class AuctionListEntity : BaseEntity
    {
        public string Title { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IList<AuctionItemEntity> AuctionItemList { get; set; }
    }
}
