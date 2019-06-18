using System.IO;
using System.Linq;
using System.Text;


namespace EdinLib.Dto
{
    public abstract class BaseModel
    {
        protected BaseModel(string xml)
        {
            Xml = xml;
            MemoryStream MemStream = new MemoryStream();
            byte[] b = Encoding.UTF8.GetBytes(Xml);

            string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (Xml.StartsWith(_byteOrderMarkUtf8))
            {
                Xml = Xml.Remove(0, _byteOrderMarkUtf8.Length);
            }
        }

        public string Xml { get; protected set; }
    }
}
