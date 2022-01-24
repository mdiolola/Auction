using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.Models
{
    public class AuctionItem : BaseModel<AuctionItemEntity>
    {
        public string Name { get; set; }

        public Bidder Bidder { get; set; }

        public decimal Bid { get; set; }

        public AuctionItem(AuctionItemEntity ent)
        {
            this.Id = ent.Id;
            this.Name = ent.Name;
            this.Bidder = ent.Bidder == null ? null : new Bidder(ent.Bidder);
            this.Bid = ent.Bid;
        }

        public override AuctionItemEntity ToEntity()
        {
            return new AuctionItemEntity
            {
                Id = this.Id,
                Name = this.Name,
                Bidder = this.Bidder.ToEntity(),
                Bid = this.Bid
            };
        }
    }
}
