using EdinLib.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdinLib.Dto
{
    public abstract class EdinDocBase
    {
        public EdinDocTypes DocType { get; protected set; }
        public string DocName { get; protected set; }
        public string DocBody { get; protected set; }
        public bool DocIdentified { get; protected set; } = false;
        public EdinDocBase(string name, string body)
        {
            this.DocType = EdinDocTypes.Unknown;
            this.DocName = name;
            this.DocBody = body;
            this.IdentifyDocType();
            if (this.DocIdentified)
            {
                this.ParseDoc();
            }
        }

        protected abstract void IdentifyDocType();
        protected abstract void ParseDoc();

        public static string GetDocTypeDescription(EdinDocTypes docType)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])docType
                .GetType()
                .GetField(EdinDocTypes.Order.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
