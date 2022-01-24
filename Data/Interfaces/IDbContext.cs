using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.Data.Interfaces
{
    public interface IDbContext
    {
        AuctionItemEntity GetAuctionItem(int id);

        IList<AuctionItemEntity> GetAllAuctionItem();

        AuctionListEntity GetAuctionList(int id);

        IList<AuctionListEntity> GetAllAuctionLists();

        BidderEntity GetBidder(int id);

        IList<BidderEntity> GetAllBidder();


        void UpdateAuctionItem(AuctionItemEntity entity);
    }
}
