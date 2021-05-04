using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{

    /// <summary>
    /// Phân trang và lọc khách hàng
    /// </summary>
    public class CustomerFilter
    {
        /// <summary>
        /// Số thứ tự bản ghi
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Số lượng bản ghi có trong Page
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Lọc theo PhoneNumber hay FullName
        /// </summary>
        public string filter { get; set; } = null;

        /// <summary>
        /// Lọc theo mã ID của nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; } = null;
    }
}
