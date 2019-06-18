﻿using EdinLib.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdinLib.Dto
{
    public class EdinOrder : EdinDocBase
    {
        public OrderModel Order { get; private set;}
        public EdinOrder(string name, string body) : base(name, body)
        {
        }

        protected override void IdentifyDocType()
        {
            string orderFileName = EdinDocBase.GetDocTypeDescription(EdinDocTypes.Order);
            if (this.DocName.ToLower().Contains(orderFileName))
            {
                this.DocIdentified = true;
                this.DocType = EdinDocTypes.Order;
                return;
            }
        }

        protected override void ParseDoc()
        {
            Order = new OrderModel(this.DocBody);
        }
    }
}
