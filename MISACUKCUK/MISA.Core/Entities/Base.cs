using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Base
    {

        /// <summary>
        /// Người thêm vào.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày thêm vào.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa lần cuối.
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa lần cuối.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
