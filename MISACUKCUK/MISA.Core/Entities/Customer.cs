using MISA.Core.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{

    /// <summary>
    /// Thông tin khách khách
    /// </summary>
    /// CreatedBy: NVDat ()
    public class Customer: Base
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequired(name: "Mã khách hàng")]
        [MISAMaxLength(20, msg: "Mã khách hàng không dài quá 20 kí tự")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>

        [MISARequired]
        public string FullName { get; set; }
        /// <summary>
        /// Ngay sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gioi tinh </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// ma thanh vien
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Khoa ngoai
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// So dien thoai
        /// </summary>

        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress]

        public string Email { get; set; }
        /// <summary>
        /// Ten cong ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Ma cong ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Dia chi
        /// </summary>
        public string Address { get; set; }
        public string Note { get; set; }
    }
}
