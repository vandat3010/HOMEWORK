using MISA.Core.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// </summary>
    public class CustomerGroup: Base
    {
        /// <summary>
        /// Id nhóm khách hàng.
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng.
        /// </summary>
        [MISARequired("Tên nhóm khách hàng không được phép để trống")]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Id của nhóm khách hàng chứa nhóm khách hàng hiên tại.
        /// </summary>
        /*public Guid? ParentId { get; set; }*/

        /// <summary>
        /// Mô tả.
        /// </summary>
        public string Description { get; set; }
    }
}
