using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace EdinLib.Dto
{
    public class OrderModel : BaseModel
    {
        public OrderModel(string xml): base(xml)
        {
            Order = Deserialize(Xml);
        }

        public EdinOrder Order { get; set; }

        [Serializable()]
        [XmlRoot("ORDER")]
        public class EdinOrder
        {
            [XmlElement(ElementName = "DOCUMENTNAME")]
            public string DocumentName { get; set; }
            [XmlElement(ElementName = "NUMBER")]
            public string Number { get; set; }
            [XmlElement(ElementName = "DATE")]
            public string Date { get; set; }
            [XmlElement(ElementName = "DELIVERYDATE")]
            public string DeliveryDate { get; set; }
            [XmlElement(ElementName = "DELIVERYTIME")]
            public string DeliveryTime { get; set; }
            [XmlElement(ElementName = "CURRENCY")]
            public string Currency { get; set; }
            [XmlElement(ElementName = "VAT")]
            public double Vat { get; set; }
            [XmlElement(ElementName = "HEAD")]
            public EdinOrderHead Head { get; set; }
        }

        [Serializable()]
        //[XmlRoot("HEAD")]
        public class EdinOrderHead
        {
            [XmlElement(ElementName = "SUPPLIER")]
            public string Supplier { get; set; }
            [XmlElement(ElementName = "BUYER")]
            public string Buyer { get; set; }
            [XmlElement(ElementName = "DELIVERYPLACE")]
            public string DeliveryPlace { get; set; }
            [XmlElement(ElementName = "INVOICEPARTNER")]
            public string InvoicePartner { get; set; }
            [XmlElement(ElementName = "SENDER")]
            public string Sender { get; set; }
            [XmlElement(ElementName = "FINALRECIPIENT")]
            public string FinalRecipient { get; set; }
            [XmlElement(ElementName = "RECIPIENT")]
            public string Recipient { get; set; }
            [XmlElement(ElementName = "EDIINTERCHANGEID")]
            public string EdiInterChangeId { get; set; }
            [XmlElement(ElementName = "POSITION")]
            public List<OrderPosition> Positions { get; set; }

        }

        [Serializable()]
        public class OrderPosition
        {
            [XmlElement(ElementName = "POSITIONNUMBER")]
            public string PositionNumber { get; set; }
            [XmlElement(ElementName = "PRODUCT")]
            public string Product { get; set; }
            [XmlElement(ElementName = "PRODUCTIDBUYER")]
            public string ProductIdBuyer { get; set; }
            [XmlElement(ElementName = "ORDEREDQUANTITY")]
            public double OrderQuantity { get; set; }
            [XmlElement(ElementName = "ORDERUNIT")]
            public string OrderUnit { get; set; }
            [XmlElement(ElementName = "ORDERPRICE")]
            public double OrderPrice { get; set; }
            [XmlElement(ElementName = "PRICEWITHVAT")]
            public double PriceWithVAT { get; set; }
            [XmlElement(ElementName = "ORDERPRICEUNIT")]
            public string OrderPriceUnit { get; set; }
            [XmlElement(ElementName = "CHARACTERISTIC")]
            public Characteristic Characteristic;
        }

        [Serializable()]
        public class Characteristic
        {
            [XmlElement(ElementName = "DESCRIPTION")]
            public string Description { get; set; }
        }

        private EdinOrder Deserialize(string serializedObj)
        {
            var serializer = new XmlSerializer(typeof(EdinOrder));
            using (var stringReader = new StringReader(serializedObj))
            using (var xmlTextReader = new XmlTextReader(stringReader))
            {
                object obj = serializer.Deserialize(xmlTextReader);
                return obj  as EdinOrder;
            }
        }
    }
}
