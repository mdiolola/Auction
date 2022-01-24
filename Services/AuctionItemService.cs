using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Models;
using Auction.Services.Interfaces;
using Auction.Data;
using Auction.Data.Interfaces;

namespace Auction.Services
{
    public class AuctionItemService : IAuctionItemService
    {
        private readonly IDbContext _dbContext;

        public AuctionItemService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(AuctionItem obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(AuctionItem obj)
        {
            throw new NotImplementedException();
        }

        public AuctionItem Get(int id)
        {
            return new AuctionItem (_dbContext.GetAuctionItem(id));
        }

        public IList<AuctionItem> GetAll()
        {
            var result = new List<AuctionItem> { };
            var entities = _dbContext.GetAllAuctionItem();
            foreach(var entity in entities)
                result.Add(new AuctionItem(entity));

            return result;
        }

        public void Update(AuctionItem obj)
        {
            _dbContext.UpdateAuctionItem(obj.ToEntity());
        }
    }
}
