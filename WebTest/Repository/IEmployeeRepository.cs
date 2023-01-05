using System.Threading.Tasks;
using WebTest.Models;
using WebTest.Paging;

namespace WebTest.Repository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameters);
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
