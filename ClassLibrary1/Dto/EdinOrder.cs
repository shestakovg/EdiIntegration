using EdinLib.Enum;
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
            DescriptionAttribute[] attributes = (DescriptionAttribute[])EdinDocTypes.Order
            .GetType()
            .GetField(EdinDocTypes.Order.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
            string orderFileName = attributes.Length > 0 ? attributes[0].Description : string.Empty;
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
