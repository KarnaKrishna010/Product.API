using Product.Models.Employee;

namespace Product.Repository.Interface
{
    public interface IEmployee
    {
        EmployeeDTOResponse List(string username);

        EmployeeDTOResponse DeletedList(string username);

        EmployeeDTOResponse GetByCode(int employeeId, string username);

        EmployeeDTOResponse Insert(EmployeeAddDTO employeeAddDTO);

        EmployeeDTOResponse Update(EmployeeEditDTO employeeEditDTO);

        EmployeeDTOResponse Delete(int employeeId, string deletedBy, string deletedByIpAddress);
    }
}
