using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Models;

namespace Auction.Services.Interfaces
{
    public interface IAuctionItemService
    {
        #region "Command"

        public void Create(AuctionItem obj);

        public void Update(AuctionItem obj);

        public void Delete(AuctionItem obj);

        #endregion

        #region "Query"

        public AuctionItem Get(int id);

        public IList<AuctionItem> GetAll();

        #endregion

    }
}
