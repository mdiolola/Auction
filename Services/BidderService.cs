using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Models;
using Auction.Services.Interfaces;
using Auction.Models.Common;
using Auction.Data.Interfaces;

namespace Auction.Services
{
    public class BidderService : IBidderService
    {
        private readonly IAuctionItemService _auctionItemService;
        private readonly IAuctionListService _auctionListService;
        private readonly IDateTime _dateTimeService;
        private readonly IDbContext _dbContext;

        public BidderService(IAuctionItemService auctionItemService, IAuctionListService auctionListService, IDateTime dateTimeService, IDbContext dbContext)
        {
            this._auctionItemService = auctionItemService;
            this._auctionListService = auctionListService;
            this._dateTimeService = dateTimeService;
            this._dbContext = dbContext;
        }

        public Bidder GetBidder(int id)
        {
            return new Bidder(_dbContext.GetBidder(id));
        }

        public bool NewBid(AuctionItem obj)
        {
            var currentItem = _auctionItemService.Get(obj.Id);

            if (currentItem.Bid > obj.Bid)
                return false;

            _auctionItemService.Update(obj);

            return true;
        }

        public bool IsBiddingActive(AuctionList obj)
        {
            var currentList = _auctionListService.Get(obj.Id);
            return currentList.StartDate <= _dateTimeService.Now && currentList.EndDate >= _dateTimeService.Now;
        }
    }
}
