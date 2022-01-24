using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Entities;

namespace Auction.Models
{
    public abstract class BaseModel<TEntity>
    {
        public int Id { get; set; }

        public abstract TEntity ToEntity();
    }
}
