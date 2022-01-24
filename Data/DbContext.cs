using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Data.Interfaces;
using Auction.Entities;

namespace Auction.Data
{
    public class DbContext : IDbContext
    {

        private List<AuctionItemEntity> AuctionItems;

        private List<AuctionListEntity> AuctionLists;

        private List<BidderEntity> Bidders;

        public DbContext()
        {
            var mData = new MockData();
            this.AuctionItems = mData.AuctionItems;
            this.AuctionLists = mData.AuctionItemLists();
            this.Bidders = mData.Bidders;
        }

        public AuctionItemEntity GetAuctionItem(int id)
        {
            return AuctionItems.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<AuctionItemEntity> GetAllAuctionItem()
        {
            return AuctionItems;
        }

        public IList<AuctionListEntity> GetAllAuctionLists()
        {
            return this.AuctionLists;
        }

        public AuctionListEntity GetAuctionList(int id)
        {
            return AuctionLists.Where( x => x.Id == id).FirstOrDefault();
        }

        public void UpdateAuctionItem(AuctionItemEntity entity)
        {
            var currentData = AuctionItems.Where(x => x.Id == entity.Id).FirstOrDefault();
            AuctionItems.Remove(currentData);
            AuctionItems.Add(entity);            
        }

        public BidderEntity GetBidder(int id)
        {
            return Bidders.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<BidderEntity> GetAllBidder()
        {
            return Bidders;
        }
    }
}
