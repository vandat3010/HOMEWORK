using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repositories
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        /// <summary>
        /// check mã khách hàng tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        bool CheckCustomerExists(string customerCode);

        /// <summary>
        /// Kiểm tra trùng số điện thoại
        // Created By : TMQuy
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <returns>true or false</returns>
        bool CheckPhoneNumberExists(string phoneNumber);

        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <returns>Dữ liệu phân trang</returns>
        ///Created By : NVDAT
        Pagging<Customer> GetCustomers(CustomerFilter filter);
    }
}
