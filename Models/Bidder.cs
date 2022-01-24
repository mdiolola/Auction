using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.Models
{
    public class Bidder: BaseModel<BidderEntity>
    {
        public string Name { get; set; }

        public override BidderEntity ToEntity()
        {
            return new BidderEntity
            {
                Id = this.Id,
                Name = this.Name
            };           
        }

        public Bidder(BidderEntity entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }
    }
}
