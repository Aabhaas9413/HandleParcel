using ParcelLib.Models;

namespace ParcelLib.Services.IServices
{
    public interface IDepartmentService
    {
        List<Department> AddDepartment(string name, double weightThreshold);
        List<Department> GetDepartments();
        List<Department> RemoveDepartment(string name);
    }
}