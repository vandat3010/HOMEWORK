using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACUKCUK.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        #region property
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository;
        #endregion

        #region constructor
        public CustomerController(ICustomerService customerService, ICustomerRepository customerRepository) : base(customerService, customerRepository)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }
        #endregion

        #region public Method

        /// <summary>
        /// Lấy danh sách khách hàng theo từng điều kiện lọc
        /// </summary>
        /// <param name="customerFilter">thông tin lọc</param>
        /// <returns>
        /// HTTPStatusCode - 200 : có dữ liệu trả về
        /// HTTPStatusCode - 204 : không có dữ liệu
        /// </returns>

        [HttpGet("Fiter")]
        public IActionResult GetCustomers([FromQuery] CustomerFilter customerFilter)
        {
            var pagging = _customerService.GetCustomers(customerFilter);
            //xử lí kết quả trả về cho client.
            if (pagging.data.Any())
            {
                return Ok(pagging);
            }
            else
            {
                return NoContent();
            }
        }
        #endregion
    }
}
