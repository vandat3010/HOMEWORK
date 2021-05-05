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
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        private ICustomerGroupService _customerGroupService;
        private ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupController(ICustomerGroupService customerGroupService, ICustomerGroupRepository customerGroupRepository) : base(customerGroupService, customerGroupRepository)
        {
            _customerGroupService = customerGroupService;
            _customerGroupRepository = customerGroupRepository;
        }
    }
}
