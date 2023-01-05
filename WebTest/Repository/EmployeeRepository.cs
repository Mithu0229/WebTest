using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTest.Data;
using WebTest.Models;
using WebTest.Paging;

namespace WebTest.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext context)
            :base(context)
        {

        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            return GetByCondition(e => e.Id == id).FirstOrDefault();
        }

        public Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Employee>.GetPagedList(GetAll().OrderBy(s => s.Id), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
    }
}
