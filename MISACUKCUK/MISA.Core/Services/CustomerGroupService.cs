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
    public class CustomerGroupService: BaseService<CustomerGroup>, ICustomerGroupService
    {
        private ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository): base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
        protected override void CustomValidate(CustomerGroup entity)
        {
            if (string.IsNullOrEmpty(entity.CustomerGroupName))
            {
                throw new Exception("Tên nhóm khách hàng không được để trống");
            }
        }
    }
}
