using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.Domain.Interfaces;

namespace TradeCompany.Domain.Model.Base
{
    public abstract class Entity : IEntity
    {
        public virtual int Id { get; set; }

    }
}
