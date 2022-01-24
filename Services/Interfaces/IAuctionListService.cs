using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Models;

namespace Auction.Services.Interfaces
{
    public interface IAuctionListService
    {
        #region "Command"

        public void Create(AuctionList obj);

        public void Update(AuctionList obj);

        public void Delete(AuctionList obj);

        #endregion

        #region "Query"

        public AuctionList Get(int id);

        public IList<AuctionList> GetAll();

        #endregion
    }
}
