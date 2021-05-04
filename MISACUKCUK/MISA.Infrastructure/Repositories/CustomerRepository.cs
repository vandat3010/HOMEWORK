﻿using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
               
        }
        /// <summary>
        /// Check mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>trả về đâ tồn tại hay chưa tồn tại</returns>
        public bool CheckCustomerExists(string customerCode)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@customerCode", customerCode);
                dynamicParameters.Add("@customerId", null);
                var res = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Check SĐT đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber">SĐT</param>
        /// <returns>trả về đâ tồn tại hay chưa tồn tại</returns>
        public bool CheckPhoneNumberExists(string phoneNumber)
        {
            return false;
        }
        /// <summary>
        /// Lọc dữ liệu phân trang
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagging<Customer> GetCustomers(CustomerFilter filter)
        {
            Pagging<Customer> pageNew = new Pagging<Customer>();

            var sqlCommand = "Proc_PaggingCustomers";
            var customers = dbConnection.Query<Customer>(sqlCommand, param: filter, commandType: CommandType.StoredProcedure);
            var totalPages = 1;
            if (customers.Count() % 10 == 0)
            {
                totalPages = customers.Count() / 10;
            }
            else
            {
                totalPages = (customers.Count() / 10) + 1;
            }
            pageNew = new Pagging<Customer>
            {
                totalRecord = customers.Count(),
                totalPages = totalPages,
                pageIndex = filter.Page,
                data = customers,
                pageSize = filter.PageSize
            };
            pageNew.data = customers;
            return pageNew;
        }
    }
}
