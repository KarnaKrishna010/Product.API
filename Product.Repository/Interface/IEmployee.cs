using Product.Models.Employee;

namespace Product.Repository.Interface
{
    public interface IEmployee
    {
        EmployeeDTOResponse List(string username);
    }
}
