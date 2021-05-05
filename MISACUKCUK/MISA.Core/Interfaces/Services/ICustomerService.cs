using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// Lấy dữ liệu bảng ghi phân trang và lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Pagging<Customer> GetCustomers(CustomerFilter filter);
    }
}
