using Data.domainModels;
using DataLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IEmployeeRepository
    {
        Task SaveEmloyee(EmployeeDTO dto);

        Task<List<EmployeeDTO>> GetAllEmloyees();
    }
}
