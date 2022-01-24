namespace Auction.Entities
{
    public class AuctionItemEntity : BaseEntity
    {

        public string Name { get; set; }

        public BidderEntity Bidder { get; set; }
        public decimal Bid { get; set; }
    }
}
