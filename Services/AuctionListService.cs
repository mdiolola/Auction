using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Data.Interfaces;
using Auction.Models;
using Auction.Services.Interfaces;

namespace Auction.Services
{
    public class AuctionListService : IAuctionListService
    {
        private readonly IDbContext _dbContext;

        public AuctionListService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(AuctionList obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(AuctionList obj)
        {
            throw new NotImplementedException();
        }

        public AuctionList Get(int id)
        {
            return new AuctionList(_dbContext.GetAuctionList(id));
        }

        public IList<AuctionList> GetAll()
        {
            var result = new List<AuctionList> { };
            var entities = _dbContext.GetAllAuctionLists();
            foreach (var entity in entities)
                result.Add(new AuctionList(entity));

            return result;
        }

        public void Update(AuctionList obj)
        {
            throw new NotImplementedException();
        }
    }
}
