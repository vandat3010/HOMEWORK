using MISA.Core.CustomExceptions;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Lay danh sach khach hang co loc
        /// </summary>
        /// <param name="filter">Điều kiện lọc</param>
        /// <returns>danh sách khách hàng</returns>
        public Pagging<Customer> GetCustomers(CustomerFilter filter)
        {
            return _customerRepository.GetCustomers(filter);
        }

        protected override void CustomValidate(Customer entity)
        {
            //Xác định xem property nào sẽ thực hiện validate check bắt buộc nhập

            var customer = entity as Customer;

            /*var isExits = _customerRepository.CheckCustomerExists(customer.CustomerCode);
            if (isExits == true)
            {
                throw new Exception("Mã khác hàng đã tồn tại trên hệ thống");
            }*/
            var isPhoneExits = _customerRepository.CheckPhoneNumberExists(customer.PhoneNumber);
            if (isPhoneExits == true)
            {
                throw new EntityException("Số điện thoại đã tồn tại trên hệ thống");
            }
        }
    }
}
