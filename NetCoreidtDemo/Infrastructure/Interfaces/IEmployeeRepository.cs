using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<TravelHubTileCaptions>> GetEmployees();
    }
}
