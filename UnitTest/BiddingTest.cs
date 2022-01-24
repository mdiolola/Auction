using NUnit.Framework;
using Auction.Services;
using Auction.Services.Interfaces;
using Auction.Data;
using Auction.Data.Interfaces;
using Auction.Models;
using Auction.Models.Common;
using System;
using Shouldly;

namespace Auction.BiddingTest
{
    public class Tests
    {

        private IBidderService _bidderService;
        private IAuctionItemService _auctionItemService;
        private IAuctionListService _auctionListService;
        private IDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new DbContext();
            _auctionItemService = new AuctionItemService(_dbContext);
            _auctionListService = new AuctionListService(_dbContext);
            _bidderService = new BidderService(_auctionItemService, _auctionListService, new DateTimeTest(), _dbContext);
        }

        [Test]
        public void NewBidIsEqualOrLower()
        {
            var auctionItem = _auctionItemService.Get(1);

            auctionItem.Bid = auctionItem.Bid - 1;

            var result = _bidderService.NewBid(auctionItem);

            result.ShouldBeFalse();
        }

        [Test]
        public void NewBidIsHigher()
        {
            var auctionItem = _auctionItemService.Get(1);

            var bidder = _bidderService.GetBidder(1);

            var newBid = auctionItem.Bid + 1;

            auctionItem.Bid = newBid;
            auctionItem.Bidder = bidder;

            var result = _bidderService.NewBid(auctionItem);

            result.ShouldBeTrue();

            // check if data is updated
            auctionItem = _auctionItemService.Get(1);

            auctionItem.Bid.ShouldBe(newBid);
            auctionItem.Bidder.Id.ShouldBe(bidder.Id);
        }

        [Test]
        public void AuctionIsActive()
        {
            var auctionList = _auctionListService.Get(1);

            var adjustedTimeBidder = new BidderService(_auctionItemService, _auctionListService, new DateTimeTest(1), _dbContext);

            var result = adjustedTimeBidder.IsBiddingActive(auctionList);

            result.ShouldBeTrue();
        }

        [Test]
        public void AuctionIsExpired()
        {
            var auctionList = _auctionListService.Get(1);

            var adjustedTimeBidder = new BidderService(_auctionItemService, _auctionListService, new DateTimeTest(8), _dbContext);

            var result = adjustedTimeBidder.IsBiddingActive(auctionList);

            result.ShouldBeFalse();
        }

        private class DateTimeTest : IDateTime
        {
            private int _days = 0;
            public DateTimeTest(int days = 0)
            {
                _days = days;
            }

            public DateTime Now => DateTime.Now.AddDays(_days);
        }
    }
}