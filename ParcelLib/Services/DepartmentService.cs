using ParcelLib.Models;
using ParcelLib.Services.IServices;
using System.Collections.Immutable;

namespace ParcelLib.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> departments = new List<Department>();
        public DepartmentService(List<Department> departments)
        {
            departments = departments.OrderBy(department => department.WeightThreshold).ToList();
            this.departments = departments;
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }
        public List<Department> AddDepartment(string name, double weightThreshold)
        {
            departments.Add(new Department(name, weightThreshold));
            return departments.OrderBy(department => department.WeightThreshold).ToList();
        }

        public List<Department> RemoveDepartment(string name)
        {
            departments.RemoveAll(d => d.Name.Equals(name));
            return departments;
        }
    }
}
