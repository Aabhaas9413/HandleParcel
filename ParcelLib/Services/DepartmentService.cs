using ParcelLib.Models;
using ParcelLib.Services.IServices;
using System.Collections.Immutable;

namespace ParcelLib.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> _departments = new List<Department>();
        public DepartmentService(List<Department> departments)
        {
            _departments = departments.OrderBy(department => department.WeightThreshold).ToList();           
        }

        public List<Department> GetDepartments()
        {
            return _departments;
        }
        public List<Department> AddDepartment(string name, double weightThreshold)
        {
            _departments.Add(new Department(name, weightThreshold));
            _departments = _departments.OrderBy(department => department.WeightThreshold).ToList();
            return _departments;
        }

        public List<Department> RemoveDepartment(string name)
        {
            _departments.RemoveAll(d => d.Name.Equals(name));
            return _departments;
        }
    }
}
