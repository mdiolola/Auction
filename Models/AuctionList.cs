using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.Models
{
    public class AuctionList:BaseModel <AuctionListEntity>
    {
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<AuctionItem> AuctionItemList { get; private set; } = new List<AuctionItem> { };

        public AuctionList(AuctionListEntity ent)
        {
            this.Id = ent.Id;
            this.Title = ent.Title;
            this.StartDate = ent.StartDate;
            this.EndDate = ent.EndDate;
            this.AuctionItemList = this.ToModel(ent.AuctionItemList);
        }

        public override AuctionListEntity ToEntity()
        {
            return new AuctionListEntity
            {
               Id = this.Id,
               Title = this.Title,
               StartDate = this.StartDate,
               EndDate = this.EndDate,
               AuctionItemList = this.ToEntity(this.AuctionItemList)
            };
        }

        private List<AuctionItem> ToModel(IList<AuctionItemEntity> list)
        {
            var auctionList = new List<AuctionItem> { };

            foreach(var l in list)
                auctionList.Add(new AuctionItem(l));

            return auctionList;
        }

        private List<AuctionItemEntity> ToEntity(IList<AuctionItem> list)
        {
            var auctionListEntity = new List<AuctionItemEntity> { };

            foreach (var l in list)
            {
                auctionListEntity.Add(l.ToEntity());
            }

            return auctionListEntity;
        }
    }
}
