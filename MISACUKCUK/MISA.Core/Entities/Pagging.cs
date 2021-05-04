using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin phân trang
    /// Created By : NVDAT
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    public class Pagging<TEntity> where TEntity : class
    {
        /// <summary>
        /// Tổng số đối tượng
        /// </summary>
        public int totalRecord { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int totalPages { get; set; }

        /// <summary>
        /// Dữ liệu phân trang
        /// </summary>
        public IEnumerable<TEntity> data { get; set; }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// Kích thước trang : số đối tượng trên 1 trang
        /// </summary>
        public int pageSize { get; set; }
    }
}
