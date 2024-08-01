using Product.Models.Employee;

namespace Product.Repository.Interface
{
    public interface IEmployee
    {
        EmployeeDTOResponse List(string username);

        EmployeeDeletedDTOResponse DeletedList(string username);

        EmployeeDetailDTOResponse GetByCode(int employeeId, string username);

        EmployeeDTOResponse Insert(EmployeeDTOAdd employeeAddDTO);

        EmployeeDTOResponse Update(EmployeeDTOEdit employeeEditDTO);

        EmployeeDTOResponse Delete(int employeeId, string deletedBy, string deletedByIpAddress);
    }
}
