using EdinLib.Enum;
using System;
using System.Collections.Generic;
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
    }
}
