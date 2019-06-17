using System;
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
