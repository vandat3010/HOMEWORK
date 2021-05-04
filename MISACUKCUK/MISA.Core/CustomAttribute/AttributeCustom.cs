using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string MsgError = string.Empty;
        public string Name = string.Empty;

        public MISARequired(string msgError = "", string name = "")
        {
            MsgError = msgError;
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;
        public string MsgError = string.Empty;
        public MISAMaxLength(int maxLength = 0, string msg = "")
        {
            MaxLength = maxLength;
            MsgError = msg;
        }
    }
}
